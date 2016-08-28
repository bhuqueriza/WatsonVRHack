using UnityEngine;
using System.Collections;

public class ChangeMask : MonoBehaviour {

	// Use this for initialization
	//public  letPanel,rightPanel;
	public LayerMask leftMask;
	public LayerMask rightMask;

	public Camera leftCam,rigthCam;
	float elapsed=0;

	void Start () 
	{
		Invoke("changeParam",1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		elapsed+=Time.fixedDeltaTime;

		if(elapsed>3)		
		{
			changeParam();
			elapsed=0;
		}


		if (Input.GetKeyDown(KeyCode.Escape))
         {
                Application.Quit();
 
                return;
        }


	}



	// cahnges te culling of the cameras to simulate stereo images
	public void changeParam()
	{
		leftCam.cullingMask=leftMask ;
		rigthCam.cullingMask=rightMask;
	}
}
