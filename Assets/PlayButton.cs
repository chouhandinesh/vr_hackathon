using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour 
{

	public List<GameObject> cubes;

	public Text pointerText;
	public Button PlayBtn;

	//this is the event which will activate the cuberoom..
	public void PointerEnter()
	{
		
		print ("You have pointed the Play Button");
		StartCoroutine ("DisableButton");
	
	}

	IEnumerator DisableButton()
	{
		yield return new WaitForSeconds (1f);
		pointerText.text ="Point Gaze on cubes to \n perform different actions";
		PlayBtn.gameObject.SetActive (false);
		StartCoroutine ("EnableRoom");
	}

	IEnumerator EnableRoom()
	{
		yield return new WaitForSeconds (.5f);
		for (int i = 0; i < cubes.Count; i++) 
		{
			cubes [i].gameObject.SetActive (true);
		}

	

	}



}
