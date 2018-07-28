using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManagerUtility : MonoBehaviour 
{

	bool _lerp = false;

	void Start(){
		Camera.main.gameObject.transform.position = new Vector3 (545, 425, -614);
	}


	public void SceneTransist(){
		_lerp = true;
//		Camera.main.gameObject.transform.position = Vector3.Lerp (new Vector3 (545, 425, -614), new Vector3 (3050, 425, -614), Mathf.Sin(Time.time)/2+.5f);
		StartCoroutine (rotatecamera (1));
		GetComponent <GameManager> ().enabled = true;
		_lerp = false;
	}

	void FixedUpdate(){
		if(_lerp){
		}
	}

	IEnumerator rotatecamera(int x){
		for (int i = 0; i < 90; i+= 1) {
			Camera.main.transform.position += new Vector3 (x * 27.7f, 0, 0);
			yield return new WaitForSeconds (Time.deltaTime);
		}

	}
}
