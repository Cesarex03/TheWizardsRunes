using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemsTrigger : MonoBehaviour
{
    [SerializeField] GameObject FireMobile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("FireMobile")){

        FireMobile.SetActive(true);
        FireMobile.SetActive(true);
        }
    }
}
