using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedofMove = 0f;
    private Camera mainCamera;
    private Vector3 pointToLookAt;
    private float rayLenght;
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
        }
        if (Input.GetKey(KeyCode.S))
        {

            Move(Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {

            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.D))
        {

            Move(Vector3.right);
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
             transform.LookAt(new Vector3(pointToLookAt.x, transform.position.y,pointToLookAt.z));

        }

    }


}
