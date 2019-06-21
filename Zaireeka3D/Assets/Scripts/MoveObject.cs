using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    Vector3 position;
    float distance;
    float force = 100;
        
    public bool hold = false;
    public GameObject item;
    public GameObject player;
    public GameObject view;
    public Camera cam;

    private void Start()
    {
        cam = view.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hold == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(view.transform);
            item.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
            item.GetComponent<Rigidbody>().angularVelocity = player.GetComponent<Rigidbody>().angularVelocity;

            Ray ray = cam.ViewportPointToRay((new Vector3(.5f, .5f, 0)));
            RaycastHit hit;
            Vector2 viewPos = cam.WorldToViewportPoint(item.transform.position);
            Vector2 center = new Vector3(0.5f,0.5f);
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
        if((Input.GetMouseButtonDown(0)) && (hold == false)){
            GrabObject();
        }else if((Input.GetMouseButtonDown(0)) && (hold == true))
        {
            DropObject();
        }
        if((Input.GetMouseButtonDown(1)) && (hold == true))
        {
            ThrowObject();
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
        hold = false;
        item.GetComponent<Rigidbody>().useGravity = true;
    }
}
