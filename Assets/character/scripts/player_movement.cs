using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Vector3 moveDirection;
    private float gravityacceleration = 20f;
    private float zvelocity = 0f;
    public float speed = 1f;

    //character camera
    public Camera playerCam;    

    private CharacterController controller;

    //children object
    private GameObject mesh;

    // Start is called before the first frame update\
    void Start()
    {
        //set up the children object
        mesh = transform.GetChild(0).gameObject;

        //set up character controller
        controller = GetComponent<CharacterController>();
        //set up camera
        playerCam = GetComponentInChildren<Camera>();
        playerCam.enabled = true;   

    }
    // Update is called once per frame
    void Update()
    {
        
        //associate x,z with the horizontal and vertical axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //set the move direction for x and z
        moveDirection = new Vector3(x, 0, z);

        //take into account the camera rotation
        moveDirection = playerCam.transform.TransformDirection(moveDirection);

        //only move on the x and z axis
        moveDirection.y = 0;

        //update the rotation of the mesh if is not 0 with lerping
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            mesh.transform.rotation = Quaternion.Lerp(mesh.transform.rotation, newRotation, Time.deltaTime * 10f);
        }
       
        //set the speed
        moveDirection *= speed;

       //move down at a constant speed
        zvelocity -= gravityacceleration * Time.deltaTime; 
        
        if(controller.isGrounded && zvelocity < 0)
        {
            zvelocity = -2f;
        }
        moveDirection.y = zvelocity;

        Debug.Log(-moveDirection.y);

        //movee the player
        controller.Move(moveDirection * Time.deltaTime);
        //associate jump with the jump axis
        if(Input.GetButtonDown("Jump"))
        {
            jump();
        }
        
    }

    private void jump()
    {
        if(controller.isGrounded)
        {
        //add a vertical force to the player
        zvelocity = 5f;
        }

    }

}
