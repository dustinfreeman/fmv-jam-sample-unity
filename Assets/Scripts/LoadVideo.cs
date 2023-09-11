using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
    [SerializeField]
    protected string videoName;
    [SerializeField]
    protected int videoWidth = 512;
    [SerializeField]
    protected int videoHeight = 512;

    protected VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        var meshRenderer = GetComponent<MeshRenderer>();

        var renderTexture = new RenderTexture(videoWidth, videoHeight, 32);
        videoPlayer.targetTexture = renderTexture;

        //copying the material here, since if you want to play multiple videos, you don't want them all writing to the same material.
        meshRenderer.material = new Material(meshRenderer.material);
        meshRenderer.material.mainTexture = renderTexture;

        videoPlayer.url = Application.streamingAssetsPath + "/" + videoName;
    }

    public void SwitchToVideo(string newVideoName) 
    {
        //HACK: would love to do this in a single-line setter
        videoName = newVideoName;
        videoPlayer.url = Application.streamingAssetsPath + "/" + videoName;
    }
}
