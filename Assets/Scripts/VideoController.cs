using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    [SerializeField]
    private GameObject videoTexture;

    private List<(float startTime, float duration)> tutorialTimestamps = new List<(float startTime, float duration)>
    {
        (0f, 40f),
        (40f, 45f),
        (87f, 40f),
        (127f, 34f),
        (162f, 33f),
        (195f, 33f),
        (228f, 26f),
        (254f, 23f),
        (278f, 26f),
        (305f, 35f)
    };

    public void RunTutorialVideo(int tutorialId)
    {
        this.StopAllCoroutines();
        this.DisableVideoPlay();

        if (tutorialId < 1 || tutorialId > this.tutorialTimestamps.Count)
        {
            Debug.LogError("Not supported tutorial type");
            return;
        }

        var timestamps = this.tutorialTimestamps[tutorialId - 1];
        this.StartVideo(timestamps.startTime);
        this.StartCoroutine(StopVideoAfterDuration(timestamps.duration));
    }

    private void StartVideo(float timeStamp)
    {
        this.videoTexture.SetActive(true);
        this.videoPlayer.Play();
        this.videoPlayer.time = timeStamp;
    }

    private IEnumerator StopVideoAfterDuration(float stopTime)
    {
        yield return new WaitForSeconds(stopTime);
        this.DisableVideoPlay();
    }

    private void DisableVideoPlay()
    {
        this.videoPlayer.Stop();
        this.videoTexture.SetActive(false);
    }
}
