using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControler : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;
    [SerializeField] Transform shootTransform;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] bool canShoot = true;
    //[SerializeField] bool shootwithAnim = false;
    [SerializeField] float timpePass = 0f;
    [SerializeField] float ShootTimeDelay = 0f;

    [SerializeField] float cooldownBetweenProjectiles = 2f;
   // [SerializeField] float delayofAtackAnim = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProjectileInputs();
    }
    void ShootProjectile()
    {

        Instantiate(projectiles[0], shootTransform.position, shootTransform.rotation);
    }
    void ProjectileInputs()
    {
        TimerBetweenProjectiles();


        if (Input.GetMouseButton(0) && canShoot)
        {
            playerAnimator.SetTrigger("isShoot");
            ShootProjectile();
            /*shootwithAnim = true;
            if (shootwithAnim)
            {
                ShootTimeDelay += Time.deltaTime;
            }
            if (ShootTimeDelay >= delayofAtackAnim)
            {
                ShootProjectile();
                ShootTimeDelay = 0f;
                shootwithAnim = false;
            }*/
            



        }
        if (Input.GetMouseButtonUp(0))
        {

            playerAnimator.SetBool("isShoot", false);
            canShoot = false;

        }
    }
    void TimerBetweenProjectiles()
    {
        if (!canShoot)
        {
            timpePass += Time.deltaTime;
        }
        if (timpePass > cooldownBetweenProjectiles)
        {
            timpePass = 0;
            canShoot = true;
        }

    }
}
