using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

    public int patrolRangeZ;
    private Vector3 originPos;
    private Vector3 maxPatrolPos;
    private Vector3 minPatrolPos;
    private bool moveUp = true;

	// Use this for initialization
	void Start () {
        originPos = transform.position;

        maxPatrolPos = originPos;
        maxPatrolPos.z += patrolRangeZ;

        minPatrolPos = originPos;
        minPatrolPos.z -= patrolRangeZ;
	}
	
	// Update is called once per frame
	void Update () {

        //guard constantly moves up and down
        if (moveUp)
        {
            if (Vector3.Distance(transform.position, maxPatrolPos) > 1)
            {

                transform.position = Vector3.Lerp(transform.position, maxPatrolPos, 2 * Time.deltaTime);
            }
            else
                moveUp = !moveUp;
        }
        else
        {
            if (Vector3.Distance(transform.position, minPatrolPos) > 1)
            {
                transform.position = Vector3.Lerp(transform.position, minPatrolPos, 2 * Time.deltaTime);
            }
            else
                moveUp = !moveUp;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("guard:collided with " + col.gameObject.name);
        if (col.gameObject.tag == "Animal")
        {
            //Destroy(gameObject);
            Debug.Log("[Zoo Break] Collision:Animal touched guard. name:"+col.gameObject.name);
        }
        else
        {
            //make guard move the other way if collided
            moveUp = !moveUp;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("guard:triggered with " + col.gameObject.name);
        if (col.gameObject.tag == "Animal")
        {
            Destroy(col.gameObject);
            Debug.Log("[Zoo Break] Trigger:Animal touched guard. name:"+col.gameObject.name);
        }
    }
}
