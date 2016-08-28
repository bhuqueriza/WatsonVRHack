using UnityEngine;
using System.Collections;

public class PhotoRendr : MonoBehaviour {

    Texture2D[] textures; // declare the array
    int size = 10;
    string[] files;
    string pathPreFix;

    // Use this for initialization
    void Start () {
        textures = new Texture2D[size]; // create the array

        string path = @"C:\Users\X51 R3\Desktop\WatsonVRHack\trunk\Assets\Photos";
        pathPreFix = @"file://";
        files = System.IO.Directory.GetFiles(path, "*.png");
        var gameObj = GameObject.FindGameObjectsWithTag("Pics");
        StartCoroutine(LoadImages());

    }
    private IEnumerator LoadImages()
    {
        //load all images in default folder as textures and apply dynamically to plane game objects.
        //6 pictures per page
        textures = new Texture2D[files.Length];

        int dummy = 0;
        foreach (string tstring in files)
        {

            string pathTemp = pathPreFix + tstring;
            WWW www = new WWW(pathTemp);
            yield return www;
            Texture2D texTmp = new Texture2D(487, 487, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texTmp);

          //  gameObj[dummy].renderer.material.SetTexture("_MainTex", texTmp);
            dummy++;
        }
 
    }
    // Update is called once per frame
    void Update () {
	
	}
}
