using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Botones : MonoBehaviour {

    public GameObject Modelo;
    public GameObject objVideo;


    public void Video()
    {
        Modelo.SetActive(false);
        objVideo.SetActive(true);
        objVideo.GetComponent<VideoPlayer>().Play();
    }

    public void Model()
    {
        Modelo.SetActive(true);
        objVideo.SetActive(false);
    }


}
