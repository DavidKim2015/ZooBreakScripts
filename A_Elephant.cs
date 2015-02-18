using UnityEngine;
using System.Collections;

public class A_Elephant : MonoBehaviour {

    //public ClickToMove clickManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if ( ClickToMove.selectedAnimalName == "A_Elephant" )
        {
            HandleAction();
        }
	}

    void HandleAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("elephant spac");
            //transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("elephant collider");
        if ( col.gameObject.name.Contains("Moveable") )
        {
            //float animalLookingAt = transform.eulerAngles.y;

            col.gameObject.transform.position += transform.right * 1;
            //col.gameObject.transform.position += transform.forward * Time.deltaTime * 100;

            //Quaternion q = Quaternion.Euler(0, animalLookingAt, 0);
            //col.gameObject.transform.position += q * (-Vector3.forward * 10);
        }
    }
}
