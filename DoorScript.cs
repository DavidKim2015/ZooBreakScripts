using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	/*
	 * Boolean isClosed defines whether door has collision, or has been 
	 *"opened" by Monkey.
	 */
	private bool isClosed = true;

	// Use this for initialization
	void Start () {
		isClosed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isClosed){
			//TODO: Move door down through floor. Destroy it?
		}
	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Door collsion with" + col.gameObject.name);
		if (IsAMonkey(col)){
			Close();
		}
	}

	void Close(){
		isClosed = false;
		//TODO: Animate door down so it moves down slowly
		transform.Translate( new Vector3(0f, -5f, 0f));
	}

	bool IsAMonkey(Collider col){
		if( isClosed &&
			col.gameObject.GetComponent<MonkeyScript>() != null){
				Debug.Log("LOL MONKEY");
				return true;
		}
		else{ 
			return false;
		}
	}
}
