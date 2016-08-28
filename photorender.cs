void Start()
{
    byte[] imageData = File.ReadAllBytes(Application.dataPath + "/Erin-T-Siggraph.png");
//WatsonVRHack/Erin-T-Siggraph.png/
    VisualRecognition m_visualrecognition = new VisualRecognition();

    string img_url = "/Erin-T-Siggraph.png";
    StartCoroutine(DownloadImage(img_url, targetMaterial));

    m_visualrecognition.Classify(OnImageClassify, img_url);

    Texture2D tex = new Texture2D(m_WebCamWidget.WebCamTexture.width, m_WebCamWidget.WebCamTexture.height, TextureFormat.RGB24, false);
    tex.LoadRawTextureData(imageData);
}

private IEnumerator DownloadImage(string url, Material targetMaterial)
{
    WWW www = new WWW(path);
    yield return www;

    targetMaterial.mainTexture = www.texture;
}