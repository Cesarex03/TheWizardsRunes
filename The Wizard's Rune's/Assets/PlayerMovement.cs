using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedOfMove = 2f;
    [SerializeField] float speedOfRunFast = 2.5f;
    private Camera mainCamera;
    private CharacterController ccplayer;
    private Vector3 pointToLookAt;
    private float rayLenght;
    [SerializeField] private Animator playerAnimator;
    private float gravity = -9.81f;
    private float height = 5f;
    private bool isGrounded = true;

    private Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        ccplayer = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        PlayerLookAtMousePos();
        Gravedad();
        Debug.Log(isGrounded);
    }
    void Gravedad()
    {
        speed.y += gravity * Time.deltaTime;
        ccplayer.Move(speed * Time.deltaTime);
        //Debug.Log(ccplayer.isGrounded);
        playerAnimator.SetBool("isJump", !ccplayer.isGrounded);
    }

    void Inputs()
    {
        //MOVERSE HACIA ADELANTE Y CORRER!
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            playerAnimator.SetBool("isRun", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move(Vector3.forward * speedOfRunFast);
                playerAnimator.SetBool("isRunFast", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerAnimator.SetBool("isRunFast", false);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("isRun", false);
        }
        //MOVERSE HACIA ATRAS!
        if (Input.GetKey(KeyCode.S))
        {

            Move(Vector3.back);
            playerAnimator.SetBool("isRunBack", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            playerAnimator.SetBool("isRunBack", false);
        }
        //MOVERSE HACIA LA IZQ!
        if (Input.GetKey(KeyCode.A))
        {

            Move(Vector3.left);
            playerAnimator.SetBool("isRunLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            playerAnimator.SetBool("isRunLeft", false);
        }
        //MOVERSE HACIA LA DERECHA!
        if (Input.GetKey(KeyCode.D))
        {

            Move(Vector3.right);
            playerAnimator.SetBool("isRunRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            playerAnimator.SetBool("isRunRight", false);
        }
        //SALTAR
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            speed.y = Mathf.Sqrt(-height * gravity);
            playerAnimator.SetTrigger("Jump");


        }
    }
    void Move(Vector3 direction)
    {

        ccplayer.Move(transform.TransformDirection(direction) * speedOfMove * Time.deltaTime);
    }
    void PlayerLookAtMousePos()
    {

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            pointToLookAt = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLookAt, Color.cyan);
            transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z));

        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 31)
        {

            isGrounded = true;
        }


    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 31)
        {

            isGrounded = false;
        }


    }

}
