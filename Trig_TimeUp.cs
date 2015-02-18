using UnityEngine;
using System.Collections;

public class Trig_TimeUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("item:'time up' triggered");

        //Activate item and destroy
        Destroy(gameObject); 

    }
}
