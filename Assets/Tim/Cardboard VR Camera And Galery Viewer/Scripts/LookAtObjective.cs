using UnityEngine;
using System.Collections;

public class LookAtObjective : MonoBehaviour {

	public Transform Objective;
	public int Zangle;


	// This function is used to make the gamobject's tranform look towars a given objectuve.
	void Start () 
	{
		transform.LookAt(2*transform.position-Objective.position);
			
		transform.rotation=Quaternion.Euler(0,transform.rotation.eulerAngles[1],Zangle);

	}
	

}
