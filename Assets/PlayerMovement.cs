using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour 
{
	public Transform target;
	public float speed;
	public bool gazeAt;
	public bool gazeAtGreen;
	public bool gazeAtPurple;
	public Text pointerText;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;

	public Renderer cubeGreen;

	//3dtext

	public GameObject hudPurpletext;
	public GameObject hudGreentext;




	void Update()
	{
		if (gazeAt) 
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}

		if(gazeAtPurple)
		{
			Spin.instance.RotateCube ();	
		}

		if (this.transform.position == target.transform.position) 
		{
			print ("Hey");
			Teleport.instance.TeleportRandomly ();
		}
	}

	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			cubeGreen.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
		cubeGreen.material.color = gazedAt ? Color.green : Color.blue;
	}

	public	 void PointerEnter() 
	{
		gazeAt = true;
		pointerText.gameObject.SetActive (false);

	}

	public void PointerEnterGreen()
	{
		gazeAtGreen = true;
		hudGreentext.SetActive (true);
		SetGazedAt (true);
	}

	public void PointerExitGreen()
	{
		gazeAtGreen = false;
		hudGreentext.SetActive (false);
		cubeGreen.material.color = Color.green;
	}

	public void PointerEnterPurple()
	{
		gazeAtPurple = true;
		hudPurpletext.SetActive (true);

	}

	public void PointerExitPurple()
	{
		gazeAtPurple = false;
		hudPurpletext.SetActive (false);

	}


	public void PointerExit()
	{
		gazeAt = false;
	}


}
