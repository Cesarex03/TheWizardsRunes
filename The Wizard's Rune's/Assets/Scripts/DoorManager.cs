using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] TotemsTrigger antorcha1;
    [SerializeField] TotemsTrigger antorcha2;
    [SerializeField] Animator rockGateAnimVibration;

    public bool canTriggerOtherAnim = false;


    // Start is called before the first frame update
    void Start()
    {
        rockGateAnimVibration = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RockGateAnimations();
        
    }
    void RockGateAnimations()
    {
        if (antorcha1.fireOn && antorcha2.fireOn)
        {

            rockGateAnimVibration.SetTrigger("ParentGate");
            Debug.Log("Abrir");
            canTriggerOtherAnim = true;

        }

    }
}
