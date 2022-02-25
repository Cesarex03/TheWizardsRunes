using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimTrigger : MonoBehaviour
{

    [SerializeField] DoorManager gateParent;
    [SerializeField] Animator moveAnim;
    [SerializeField] AudioSource rockGateMovingSound;


    // Start is called before the first frame update
    void Start()
    {
        moveAnim = GetComponent<Animator>();
        rockGateMovingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gateParent.canTriggerOtherAnim)
        {
            moveAnim.SetTrigger("ChildrenGate");

        }
    }
    void RockSlideSound()
    {

        rockGateMovingSound.Play();
    }
}
