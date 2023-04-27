using UnityEngine;
using EzySlice;

public class Slicer : MonoBehaviour
{
    [SerializeField] private Transform beginSlicePoint;
    [SerializeField] private Transform endSlicePoint;

    [SerializeField] private Material sliceTraceMaterial;
    [SerializeField] private VelocityEstimator velocityEstimator;

    [SerializeField] private LayerMask sliceableLayer;

    void FixedUpdate()
    {
        bool isHit = Physics.Linecast(beginSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (isHit)
        {
            GameObject target = hit.transform.gameObject;
            this.Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - beginSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, sliceTraceMaterial);
            this.SetupSlicedObject(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, sliceTraceMaterial);
            this.SetupSlicedObject(lowerHull);

            Destroy(target);
        }
    }

    private void SetupSlicedObject(GameObject obj)
    {
        Rigidbody rigidbody = obj.AddComponent<Rigidbody>();
        MeshCollider collider = obj.AddComponent<MeshCollider>();
        collider.convex = true;
        obj.layer = Mathf.RoundToInt(Mathf.Log(sliceableLayer.value, 2));
    }
}
