using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    int page = 0;
    int numberOfPages = 6;
    AudioSource audioSource;
    private IEnumerator coroutine;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        refreshInterface();
        playExplanation();
    }

    public void onLeft()
    {
        Debug.Log("onLeft");
        Debug.Log("page is:" + page);
        page = page - 1;
        if(page < 0)
        {
            Debug.Log("underflow");
            page = 0;
        }
        refreshInterface();
        playExplanation();
    }

    public void onRight()
    {
        Debug.Log("onRight");
        page = page + 1;
        StopCoroutine(coroutine);
        if (page >= numberOfPages)
        {
            page = numberOfPages - 1;
        }
        refreshInterface();
        playExplanation();
    }

    public void refreshInterface()
    {
        Debug.Log("page:" + page);
        //navigation buttons
        if (page == 0)
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = false;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = true;
        }
        else if(page == numberOfPages - 1)
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = true;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("LeftTutorial").GetComponent<Button>().interactable = true;
            GameObject.Find("RightTutorial").GetComponent<Button>().interactable = true;
        }
        //if (page == 2)
        //{
         //   GameObject.Find("background").GetComponent<VideoPlayer>().Stop();
          //  GameObject.Find("background").GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load("parentTutorial");
           // GameObject.Find("background").GetComponent<VideoPlayer>().Play();
        //}
        /*else*/ if (page == 2)
        {
            GameObject.Find("background").GetComponent<VideoPlayer>().Stop();
            GameObject.Find("background").GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load("colorGameTutorial");
            GameObject.Find("background").GetComponent<VideoPlayer>().Play();

        }
        else if (page == 3)
        {
            GameObject.Find("background").GetComponent<VideoPlayer>().Stop();
            GameObject.Find("background").GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load("shapeGameTutorial");
            GameObject.Find("background").GetComponent<VideoPlayer>().Play();
        }
        else if (page == 4)
        {
            GameObject.Find("background").GetComponent<VideoPlayer>().Stop();
            GameObject.Find("background").GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load("parentTutorial");
            GameObject.Find("background").GetComponent<VideoPlayer>().Play();
        }
        else if (page == 5)
        {
            SceneManager.LoadScene("LevelPractice");
        }
        else
        {
            GameObject.Find("background").GetComponent<VideoPlayer>().Stop();
            GameObject.Find("background").GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load("introductionVideo");
            GameObject.Find("background").GetComponent<VideoPlayer>().Play();
        }
    }

    public void playExplanation()
    {
        resetRightTutorialButton();
        if (page == 0)
        {
            var clip = Resources.Load("leo") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            coroutine = StartMethod(20.0f);
            StartCoroutine(coroutine);
        }
        if (page == 1)
        {
            var clip = Resources.Load("leo2") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            coroutine = StartMethod(24.0f);
            StartCoroutine(coroutine);
        }
        if(page == 2)
        {
            var clip = Resources.Load("color_game_tutorial") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            coroutine = StartMethod(66.0f);
            StartCoroutine(coroutine);
        }
        if(page == 3)
        {
            var clip = Resources.Load("shape_game_tutorial") as AudioClip;
            audioSource.clip = clip;
            audioSource.Play();
            coroutine = StartMethod(33.0f);
            StartCoroutine(coroutine);
        }
        if(page == 4)
        {
            audioSource.Stop();
            coroutine = StartMethod(18.5f);
            StartCoroutine(coroutine);
        }
    }

    private void resetRightTutorialButton()
    {
        GameObject.Find("RightTutorial").GetComponent<Animation>().Stop();
        GameObject.Find("RightTutorial").transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private IEnumerator StartMethod(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        playAnimation();
    }

    private void playAnimation()
    {
        GameObject.Find("RightTutorial").GetComponent<Animation>().Play();
    }

    private void videoColorGame()
    {
        Debug.Log("video");
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        videoPlayer.targetCameraAlpha = 0.5F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        //videoPlayer.url = Resources.Load<();

        // Skip the first 100 frames.
        videoPlayer.frame = 10;

        // Restart from beginning when done.
        videoPlayer.isLooping = true;

        // Each time we reach the end, we slow down the playback by a factor of 10.
        videoPlayer.loopPointReached += EndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
