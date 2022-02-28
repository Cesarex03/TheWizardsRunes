using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGateTriggerAnim : MonoBehaviour
{

    [SerializeField] BossGateManager bossGateParentScript;
    [SerializeField] Animator bossGateMoveAnim;
    [SerializeField] AudioSource bossGateMovingSound;



    // Start is called before the first frame update
    void Start()
    {

        bossGateMoveAnim = GetComponent<Animator>();
        bossGateMovingSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayAnimBossGateMove();
    }
    void PlayAnimBossGateMove()
    {
        if (bossGateParentScript.canTriggerBossAnim)
        {
            bossGateMoveAnim.SetBool("isBossGate", true);

        }
    }
    //ESTE SONIDO ESTA SIENDO LLAMADO DESDE UN EVENT EN LA ANIMACION!
    void RockSlideSound()
    {
        bossGateMovingSound.Play();
    }

    void StopBossGateAnimation()
    {

        bossGateParentScript.isClosed2 = true;
        bossGateMoveAnim.enabled = false;
        bossGateMovingSound.Stop();
        bossGateParentScript.isBossGateClosedSound = true;

    }
}