using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] float enemyRotationSpeed = 5f;
    [SerializeField] int enemyHP = 3;
    private float minimunDistance = 1f;
    private int currentWaypoint;
    private bool goback = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveOnWaypoints();
    }
    void MoveOnWaypoints()
    {

        Vector3 deltaVector = waypoints[currentWaypoint].position - transform.position;
        Vector3 direction = deltaVector.normalized;
        transform.forward = Vector3.Lerp(transform.forward, direction, enemyRotationSpeed * Time.deltaTime);
        transform.position += transform.forward * enemySpeed * Time.deltaTime;

        if (deltaVector.magnitude <= minimunDistance)
        {

            if (currentWaypoint >= waypoints.Length - 1)
            {

                goback = true;

            }
            else if (currentWaypoint <= 0)
            {
                goback = false;
            }
            if (goback)
            {

                currentWaypoint--;
            }

            else currentWaypoint++;
        }

    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("FireBall")){

            
            Destroy(other.gameObject);
            enemyHP --;
            if(enemyHP < 1 ){
                Destroy(gameObject);
            }
        }
    }
}
