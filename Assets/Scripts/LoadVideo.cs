using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
    [SerializeField]
    string videoName;

    void Start()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = Application.streamingAssetsPath + "/" + videoName;
    }
}
