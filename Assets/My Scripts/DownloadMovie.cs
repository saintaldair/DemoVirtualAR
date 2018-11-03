using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DownloadMovie : MonoBehaviour
{
    void Start()
    {
        var vp = gameObject.AddComponent<VideoPlayer>();
        vp.url = "http://myserver.com/mymovie.mp4";

        vp.isLooping = true;
        vp.renderMode = VideoRenderMode.MaterialOverride;
        vp.targetMaterialRenderer = GetComponent<Renderer>();
        vp.targetMaterialProperty = "_MainTex";

        vp.Play();
    }
}