using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] int bossHP = 5;
    [SerializeField] Animator bossAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("FireBall")){

            
            Destroy(other.gameObject);
            bossHP --;
            if(bossHP < 1 ){
                
                Destroy(gameObject);
            }
        }
    }
}
