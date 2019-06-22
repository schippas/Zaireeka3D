using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Class is used for objecs, where the regular MoveObject
//class does not work properly. I think I know why this works,
//but I need to verify it. Workaround for now.
//TODO: Find out why this actually works, and fix it.
public class MoveObjectSafe : MonoBehaviour
{

    Vector3 position;
    Vector2 center;
    float distance;
    float maxDistance = 12;
    float force = 5000;
        
    bool hold = false;
    public GameObject item;
    public GameObject player;
    public GameObject view;
    Camera cam;

    RaycastHit hit;

    Ray ray;

    private void Start()
    {
        cam = view.GetComponent<Camera>();
        center = new Vector3(0.5f, 0.5f);
        ray = cam.ViewportPointToRay((new Vector3(.5f, .5f, 0)));
    }

    // Update is called once per frame
    void Update()
    {
        if (hold == true)
        {
            distance = Vector3.Distance(item.transform.position, player.transform.position);
            if (distance > maxDistance)
            {
                DropObject();
            }

            if (Input.GetMouseButtonDown(1))
            {
                ThrowObject();
            }

            //item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(view.transform);
            //item.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
            //item.GetComponent<Rigidbody>().AddForce(view.transform.forward * force);
            //item.GetComponent<Rigidbody>().angularVelocity = player.GetComponent<Rigidbody>().angularVelocity;

            Vector2 viewPos = cam.WorldToViewportPoint(item.transform.position);
            if ((Vector2.Distance(viewPos, center) > 1) && (!(Physics.Raycast(ray, out hit))) || ((Physics.Raycast(ray, out hit)) && (hit.collider != item.GetComponent<Collider>())))
            {
                DropObject();
            }
        }
        else
        {
            position = item.transform.position;
            item.transform.SetParent(null);
            item.transform.position = position;
        }
    }

    private void OnMouseDown()
    {
        if((Input.GetMouseButtonDown(0)) && (hold == false) && (distance <= maxDistance)){
            GrabObject();
        }else if((Input.GetMouseButtonDown(0)) && (hold == true))
        {
            DropObject();
        }
    }

    void GrabObject()
    {
        hold = true;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().useGravity = false;
    }

    void DropObject()
    {
        hold = false;
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void ThrowObject()
    {
        item.GetComponent<Rigidbody>().AddForce(view.transform.forward * force);
        hold = false;
        item.GetComponent<Rigidbody>().useGravity = true;
    }
}
