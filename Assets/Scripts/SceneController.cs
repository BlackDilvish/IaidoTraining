using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class OnResetEvent : UnityEvent { }

public class SceneController : MonoBehaviour
{
    [SerializeField] 
    private InputController inputController;
    private bool wasRestartPressed = false;

    [SerializeField] 
    public OnResetEvent onResetEvent;

    [SerializeField] 
    private GameObject dummyObject;
    [SerializeField] 
    private Transform spawnLocation;

    private IList<GameObject> spawnedDummies = new List<GameObject>();

    void Update()
    {
        if (ShouldRestartScene())
        {
            Debug.Log("Restarting the scene...");
            onResetEvent.Invoke();
        }
    }

    private bool ShouldRestartScene()
    {
        if (inputController.isRestartPressed && !this.wasRestartPressed)
        {
            this.wasRestartPressed = true;
            return true;
        }
        else if (!inputController.isRestartPressed && this.wasRestartPressed)
        {
            this.wasRestartPressed = false;
        }

        return false;
    }

    public void RestartScene()
    {
        foreach (var dummy in this.spawnedDummies)
        {
            Destroy(dummy);
        }
        spawnedDummies.Clear();

        spawnedDummies.Add(Instantiate(dummyObject, spawnLocation.position, spawnLocation.rotation));
    }
}
