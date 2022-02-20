using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedofMove = 0f;
    [SerializeField] float speedofRunFast = 0f;
    private Camera mainCamera;
    private Vector3 pointToLookAt;
    private float rayLenght;
    [SerializeField] private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        PlayerLookAtMousePos();
    }
    void Inputs()
    {

        if (Input.GetKey(KeyCode.W))
        {

            Move(Vector3.forward);
            playerAnimator.SetBool("isRun", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Move(Vector3.forward * speedofRunFast);

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

        if (Input.GetKey(KeyCode.S))
        {

            Move(Vector3.back);
            playerAnimator.SetBool("isRunBack", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            playerAnimator.SetBool("isRunBack", false);
        }
        if (Input.GetKey(KeyCode.A))
        {

            Move(Vector3.left);
            playerAnimator.SetBool("isRunLeft", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            playerAnimator.SetBool("isRunLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {

            Move(Vector3.right);
            playerAnimator.SetBool("isRunRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            playerAnimator.SetBool("isRunRight", false);
        }
    }
    void Move(Vector3 direction)
    {

        transform.Translate(direction * speedofMove * Time.deltaTime);
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


}
