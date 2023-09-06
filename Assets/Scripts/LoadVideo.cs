using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
    void Start()
    {
        const string assetName = "mansmall.mp4";

        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = Application.streamingAssetsPath + "/" + assetName;

        //videoPlayer.url = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4";

    }

}
