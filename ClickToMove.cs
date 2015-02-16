using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {

    //selection
    static string selectedAnimalName = "";

    //movement to cursor
    public float speed = 10;
    public CharacterController controller;
    private Vector3 targetPosition;
    private Vector3 prevPosition;

    public AnimationClip run;
    public AnimationClip idle;

    public static bool attack;
    public static bool die;

    public static Vector3 cursorPosition;

    public static bool busy;




    // Use this for initialization
    void Start()
    {
        targetPosition = transform.position;
        busy = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!busy)
        {
            //locateCursor();
            //if (!attack && !die)
            if ( selectedAnimalName == gameObject.name )
            {
                if (Input.GetMouseButton(1))
                {
                    //Locate where the player clicked on the terrain
                    locatePosition();
                }

                //Move the player to the position
                moveToPosition();
            }
            else
            {
                gameObject.renderer.material.color = Color.white;
            }
        }
        targetPosition.y = renderer.bounds.extents.y;
    }

    void FixedUpdate()
    {
        prevPosition = transform.position;
    }

    void OnMouseDown()
    {
        gameObject.renderer.material.color = Color.green;
        selectedAnimalName = gameObject.name;
        Debug.Log("[Zoo Break] Selected:"+gameObject.name);
    }

    void locatePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
            {
                targetPosition = hit.point;
                targetPosition.y += renderer.bounds.extents.y; //prevent sinking of animal
                //Debug.Log(position);

            }
        }
    }

    void locateCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            cursorPosition = hit.point;
            //cursorPosition.y += 0.5f;
        }
    }

    void moveToPosition()
    {
        //Game Object is moving
        if (Vector3.Distance(transform.position, targetPosition) > 1)
        {
            //note: rotations are defined by quaternions (recall CS Into to Graphics)
            //Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            ////prevent rotations in x and z axes
            //newRotation.x = 0f;
            //newRotation.z = 0f;

            ////transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 1);
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1);
            //controller.SimpleMove(transform.forward * speed);

            //transform.position = Vector3.Lerp(transform.position, targetPosition, 2 * Time.deltaTime);

            Vector3 diff = targetPosition - transform.position;
            rigidbody.velocity = speed * diff/diff.magnitude;
            transform.rotation = Quaternion.LookRotation(-diff);
            transform.Rotate(0,90,0);


            //animation.CrossFade(run.name);
        }
        //Game Object is not moving
        else
        {
            rigidbody.velocity = new Vector3(0,0,0);
        }

        Vector3 temp = transform.position;
        temp.y = renderer.bounds.extents.y;
        transform.position = temp;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Guard"))
        {
            Destroy(gameObject);
            Debug.Log("[Zoo Break] Animal touched guard");
        }
        else {
            targetPosition = prevPosition;
            transform.position = prevPosition;
            Debug.Log("prev Position");
            rigidbody.velocity = new Vector3(0,0,0);
        }
        
    }
}
