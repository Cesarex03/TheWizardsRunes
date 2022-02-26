using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 5f;
    private GameObject projectilesParent;
    // Start is called before the first frame update
    void Start()
    {
        projectilesParent = GameObject.Find("--PROJECTILESCACHE--");

    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }
    void MoveProjectile()
    {

        transform.Translate(projectileSpeed * Time.deltaTime * Vector3.forward);
    }
}
