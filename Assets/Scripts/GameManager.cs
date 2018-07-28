using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text _time;
	public GameObject _prefabe;
	[SerializeField]
	private Vector3 _startPos;
	[SerializeField]
	private int _counter = 0;
	static int _second, _top = -1 , i = 0;
	GameObject[] _list = new GameObject[10];
	Color _color = new Color();

	void Start(){
		_top = -1;
		_startPos = new Vector3 (-900, 0, -45.5f);
		_color = Color.white;
		for (i = 0; i< 10 ; i++){
			GameObject _obj = (GameObject) Instantiate (_prefabe, GameObject.Find ("ParentPrefab").transform);
			_obj.transform.localPosition = _startPos + new Vector3 (_counter, 0, 0);
			_list[i] =  _obj;
			_counter += 200;
			_list [i].SetActive (false);
		}
//		Invoke ("Spawn", 1);

		InvokeRepeating ("Spawn", 4, 1f);
		_counter = 0;
	}


	void Update(){
		StartCoroutine (Tick ());
	}

	IEnumerator Tick(){
		yield return new WaitForSeconds (1.2f);
		_second = int.Parse (DateTime.Now.ToString ("ss"));
		_time.text = DateTime.Now.ToString ("H : mm : ss");


	}

	void Spawn(){
		if (_second % 2 != 0 )
			return;
		else{
			
			_top++;
			_list [_top].SetActive (true);
			_list [_top].GetComponent <Renderer> ().material.color = _color;
			Debug.Log ( "_top = "+ _top);
			if (_top > 8) {
				Debug.Log ("Start Disable");
				_top = -1;
				_color = UnityEngine.Random.ColorHSV(0f, 1f, 1.5f, 1.8f, 0.5f, 1f);
				return;
			}
		
		}


	
	}

	



}
