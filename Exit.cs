using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

    public Rect windowRect = new Rect(500, 500, 200, 200);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		other.gameObject.renderer.material.color = Color.cyan;
		won = true;
		Destroy(other.gameObject);
	}
		public bool won = false;
    
    void OnGUI() {
    	if (won) {
        	GUI.Window(0, windowRect, DoMyWindow, "He escaped!");
      	}
    }
    void DoMyWindow(int windowID) {
        if (GUI.Button(new Rect(10, 20, 100, 20), "OK")) {
            won = false;
        }
    }

}

