using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Services.VisualRecognition.v3;

using System;
using System.IO;

public class Images {
    public string url = Application.dataPath + "/Erin-T-Siggraph.png";
    public Material targetMaterial;

    void Start()
    {
        byte[] imageData = System.IO.File.ReadAllBytes(Application.dataPath + "/Photos/Erin-T-Siggraph.png");
        VisualRecognition m_visualrecognition = new VisualRecognition();

        string img_url = "/Photos/Erin-T-Siggraph.png";
        //StartCoroutine(DownloadImage(img_url, targetMaterial));

        m_visualrecognition.Classify(img_url, OnClassify);

        Texture2D tex = new Texture2D(487, 487, TextureFormat.RGB24, false);
        tex.LoadRawTextureData(imageData);
    }

    private void StartCoroutine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }

    private void DownloadImage(string path, Material targetMaterial)
    {

        byte[] fileData = File.ReadAllBytes(path);
        //Texture2D


        //targetMaterial.mainTexture = www.texture;
    }
    private void OnClassify (ClassifyTopLevelMultiple classify, string data)
    {
        //Log.Debug("classnamephot", "classify {0}", classify.);
        Debug.Log("hello");

    }
}