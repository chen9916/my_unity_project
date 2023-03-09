using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_boom : MonoBehaviour
{

    //rotation speed
    public float speed = 1;
    private Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        //get the camera
        playerCam = GetComponentInChildren<Camera>();
        //set playerCam as the main camera
        playerCam.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate around the world y axis with  the mouse x axis
        transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        //rotate around the local x axis with the mouse y axis
        transform.RotateAround(transform.position,-transform.right, Input.GetAxis("Mouse Y") * speed);

        //associate the scroll wheel with the scale of this object
        transform.localScale -= new Vector3(Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"), Input.GetAxis("Mouse ScrollWheel"));
        
        //cap the scale of this object between 0.5 and 2
        if (transform.localScale.x < 0.5f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (transform.localScale.x > 1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
       
    }
}
