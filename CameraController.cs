using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speed = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        //}

        float xAxisValue = Input.GetAxisRaw("Horizontal");
        float zAxisValue = Input.GetAxisRaw("Vertical");
        float localXAxisValue = Input.GetAxis("Mouse Scrollwheel");

        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue), Space.World);
            Camera.current.transform.Translate(new Vector3(localXAxisValue * 100, 0.0f, 0.0f), Space.Self);
        }

	}
}
