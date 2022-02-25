using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimTrigger : MonoBehaviour
{

    [SerializeField] DoorManager gateParentScript;
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
        if (gateParentScript.canTriggerOtherAnim)
        {
            moveAnim.SetBool("isStop", true);

        }

    }
    //ESTE SONIDO ESTA SIENDO LLAMADO DESDE UN EVENT EN LA ANIMACION!
    void RockSlideSound()
    {
        rockGateMovingSound.Play();
    }

    void StopAnimation()
    {
        gateParentScript.isClosed = true;
        moveAnim.enabled = false;
        rockGateMovingSound.Stop();
        gateParentScript.isClosedSound = true;

    }
}
