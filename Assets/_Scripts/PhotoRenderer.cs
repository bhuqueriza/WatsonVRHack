using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Services.VisualRecognition.v3;

using System;
using System.IO;
using IBM.Watson.DeveloperCloud.Logging;
using System.Collections.Generic;

public class PhotoRenderer:MonoBehaviour
{
    public string url;
    public Material targetMaterial;

    void Start()
    {
        LogSystem.InstallDefaultReactors();
        byte[] imageData = File.ReadAllBytes(Application.dataPath + url);
        VisualRecognition m_visualrecognition = new VisualRecognition();

        //Dictionary photoDictionary<float, byte[]> = new Dictionary<>
        Texture2D tex = new Texture2D(47, 47, TextureFormat.RGB24, false);
        tex.LoadImage(imageData);


        //string img_url = "/Photos/Erin-T-Siggraph.png";
        //StartCoroutine(DownloadImage(img_url, targetMaterial));

        m_visualrecognition.Classify(OnClassify, imageData);
        targetMaterial.mainTexture = tex;
        //Texture2D tex = new Texture2D(487, 487, TextureFormat.RGB24, false);
        //tex.LoadRawTextureData(imageData);
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
    private void OnClassify(ClassifyTopLevelMultiple classify, string data)
    {
        //Log.Debug("classnamephot", "classify {0}", classify.);
        Log.Debug("PhotoRenderer", "OnClassify | class: {0}, score: {0}", classify.images[0].classifiers[0].classes[0].m_class, classify.images[0].classifiers[0].classes[0].score);
    }
}