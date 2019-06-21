using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    Vector3 position;
    float distance;
    float force = 100;
        
    public int hold = 0;
    public GameObject item;
    public GameObject temp;

    // Update is called once per frame
    void Update()
    {
        if(hold == 1)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(temp.transform);
        }
        else
        {
            position = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = position;
        }
    }

    private void OnMouseDown()
    {
        if((Input.GetMouseButtonDown(0)) && (hold == 0)){
            GrabObject();
        }else if((Input.GetMouseButtonDown(0)) && (hold == 1))
        {
            DropObject();
        }
        if((Input.GetMouseButtonDown(1)) && (hold == 1))
        {
            ThrowObject();
        }
    }

    void GrabObject()
    {
        hold = 1;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void DropObject()
    {
        hold = 0;
    }

    void ThrowObject()
    {
        hold = 0;
    }
}
