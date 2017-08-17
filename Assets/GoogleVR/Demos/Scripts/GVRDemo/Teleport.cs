// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;

using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  private Vector3 startingPosition;

  public Material inactiveMaterial;
  public Material gazedAtMaterial;

	public	Transform[]  transformPos;
	public int posCount;

	public static Teleport instance;

	public void Awake()
	{
		instance = this;
	}


  void Start() {
//		posCount = -1;
    startingPosition = transform.localPosition;
    SetGazedAt(false);
  }

  public void SetGazedAt(bool gazedAt) {
    if (inactiveMaterial != null && gazedAtMaterial != null) {
      GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
      return;
    }
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void Recenter() {
#if !UNITY_EDITOR
    GvrCardboardHelpers.Recenter();
#else
    GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
    if (emulator == null) {
      return;
    }
    emulator.Recenter();
#endif  // !UNITY_EDITOR
  }

  public bool moveforward = true;


	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.T)) {
//			TeleportRandomly ();
//		}
	}



  public void TeleportRandomly() {
//    Vector3 direction = Random.onUnitSphere;
//    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
//    float distance = 2 * Random.value + 1.5f;
//    transform.localPosition = direction * distance;

	// write new code here to change target position in pattern way not in random way...
		if (moveforward) {
			if (posCount < transformPos.Length-1) {
				posCount++;
				//transform.localPosition = transformPos [posCount].position;
				Debug.Log ("posCount increases");
			} else {
				moveforward = false;
				posCount--;
//				transform.localPosition = transformPos [posCount].position;
			}
		} 
		else if (!moveforward) 
		{
			if (posCount > 0) {
				posCount--;
//				transform.localPosition = transformPos [posCount].position;
			} 
			else 
			{
				moveforward = true;
				posCount++;
//				transform.localPosition = transformPos [posCount].position;
			}
		}
		transform.localPosition = transformPos [posCount].position;
  }


}
