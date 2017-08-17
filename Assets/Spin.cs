using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	public float speed = 50f;
	public static Spin instance;

	void Awake()
	{
		instance = this;
	}

	void Update ()
	{
//		RotateCube ();
	}

	public void RotateCube()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}