using UnityEngine;
using System.Collections;
using System;
using System.IO;


public enum TypeOfStereo{    twoImages,singleImage 	}

public class LoadGallery : MonoBehaviour {

	public string pathL,pathR;

	public string Path;

	public Material panelL,panelR;
	public TypeOfStereo imageType;
	public int Imageindex=0;

	public int maxImageNumber;
	public Texture2D stereoIm;

	public Texture2D[] textL,textR;

	void Start () 
	{

		
		 //decide if single or double
		if(imageType==TypeOfStereo.singleImage)
		{

			/*

			     ***loading images****

			     This is the line you have to modify for Android

			      --> DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + Path); <--
			      					/storage/extSDcard/
			                 (you will have to create the same folder Structure)

			*/
			DirectoryInfo info = new DirectoryInfo(Application.dataPath + Path + "/STEREOsingle/");

		 	FileInfo[] fileInfo = info.GetFiles();

			maxImageNumber=fileInfo.Length;

			//initialize textures
			textL=new Texture2D[maxImageNumber];
			textR=new Texture2D[maxImageNumber];

			int counter=0;

			for (int ii=0 ; ii<maxImageNumber ; ii++ )
			 {

			 	//errase metadata from search
				if(fileInfo[ii].Extension!=".meta")
				{
					Debug.Log("Loaded:" + fileInfo[ii].Name);

					textL[counter]=new Texture2D(2,2,TextureFormat.BGRA32,false);
					textR[counter]=new Texture2D(2,2,TextureFormat.BGRA32,false);
					textL[counter].LoadImage(File.ReadAllBytes(fileInfo[ii].FullName ));
					textR[counter].LoadImage( File.ReadAllBytes(fileInfo[ii].FullName ));

					counter+=1;
				}
			
			 }

			maxImageNumber=counter;

		}
		else
		{


	


			//loading images
		 	DirectoryInfo infoL = new DirectoryInfo(Application.dataPath + Path + "/LEFT/");
			DirectoryInfo infoR = new DirectoryInfo(Application.dataPath + Path+ "/RIGHT/");



		 	FileInfo[] fileInfoL = infoL.GetFiles();
			FileInfo[] fileInfoR = infoR.GetFiles();



			//check errros
			if(fileInfoL.Length!=fileInfoR.Length)
			{
				Debug.Log("error");
				return;
			}


			maxImageNumber=fileInfoL.Length;



			//set textures
			textL=new Texture2D[maxImageNumber];
			textR=new Texture2D[maxImageNumber];


			int counter=0;

			for (int ii=0 ; ii<maxImageNumber ; ii++ )
			 {
			 	//errase metadata from search
				if(fileInfoR[ii].Extension!=".meta")
				{

					textL[counter]=new Texture2D(2,2,TextureFormat.BGRA32,false);
					textR[counter]=new Texture2D(2,2,TextureFormat.BGRA32,false);

					textL[counter].LoadImage(File.ReadAllBytes(fileInfoL[ii].FullName ));
					textR[counter].LoadImage( File.ReadAllBytes(fileInfoR[ii].FullName ));



					Debug.Log("Loaded: "+fileInfoL[ii].Name);
					counter+=1;
				}
			}
			

		
		}


		//display first image
		loadImageEstereo(0);
		Debug.Log("Showing image");
	}
	

	//public load images
	public void loadImageEstereo(int x)
	{

		panelL.mainTexture=textL[x];
		panelR.mainTexture=textR[x];

		// we need to adapt the size and offset in the case of two images
		if(imageType==TypeOfStereo.singleImage)
		{
			panelL.mainTextureScale=new Vector2(0.5f,1);
			panelL.mainTextureOffset=new Vector2(-0.5f,0);
			panelR.mainTextureScale=new Vector2(0.5f,1);
			panelR.mainTextureOffset=new Vector2(0,0);
		}
		else
		{
			panelL.mainTextureScale=new Vector2(1,1);
			panelL.mainTextureOffset=new Vector2(0,0);
			panelR.mainTextureScale=new Vector2(1,1);
			panelR.mainTextureOffset=new Vector2(0,0);
		}


	}

	//this is a prototype funciton for splitting images
	public void SplitImage(string name, int ii)
	{

		stereoIm =new Texture2D(2,2,TextureFormat.BGRA32,false);
		stereoIm.LoadImage(File.ReadAllBytes(name));
		stereoIm.Apply();

		int w= stereoIm.width;
		int h= stereoIm.height;


		textL[ii]= new Texture2D((int)w/2,h,TextureFormat.BGRA32,false);
		textR[ii]= new Texture2D((int)w/2,h,TextureFormat.BGRA32,false);

		int ww=0;
		int hh=0;

		while(ww<w)
		{
			hh=0;
			while(hh<h)
			{
				if(ww<(int)w/2)
				{
					textL[ii].SetPixel(ww,hh,stereoIm.GetPixel(ww,hh));
					Debug.Log(stereoIm.GetPixel(ww,hh)+"  jj"+ww+"  kk"+hh);

				}
				else
				{
					textR[ii].SetPixel(ww-w/2,hh,stereoIm.GetPixel(ww,hh));
				}

				hh+=1;
			}

			ww=ww+11;
		}

		textL[ii].Apply();
		textR[ii].Apply();




	}



	// called when right arrow pressed 
	public void nextImage()
	{
		Imageindex+=1;
		if(Imageindex>maxImageNumber-1)
		{
			Imageindex=0;
		}

		loadImageEstereo( Imageindex );

	}


	// called when left arrow pressed
	public void previousImage()
	{
		Imageindex-=1;
		if(Imageindex<0)
		{
			Imageindex=maxImageNumber-1;
		}

		loadImageEstereo( Imageindex );

	}



}
