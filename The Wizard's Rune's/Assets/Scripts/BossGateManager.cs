using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGateManager : MonoBehaviour

{
    [SerializeField] TotemsTrigger antorcha3;
    [SerializeField] TotemsTrigger antorcha4;
    [SerializeField] TotemsTrigger antorcha5;

    [SerializeField] Animator bossGateAnimVibration;

    [SerializeField] GameObject bossGateVSF;

    public bool canTriggerBossAnim = false;
    public bool isClosed2 = false;
    public bool isBossGateClosedSound = false;
    public bool isBossGateClosed = false;
    [SerializeField] AudioSource bossGateClosedSound;

    // Start is called before the first frame update
    void Start()
    {
        bossGateAnimVibration = GetComponent<Animator>();
        bossGateClosedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BossGateAnim();
        StopBossGateAnimVibr();
        if (isBossGateClosedSound)
        {
            bossGateClosedSound.Play();
            isBossGateClosedSound = false;
        }
    
    }
    void BossGateAnim(){

        if (antorcha3.fireOn && antorcha4.fireOn && antorcha5.fireOn && !isClosed2)
        {
            bossGateVSF.SetActive(true);
            bossGateAnimVibration.SetBool("isBossGate", true);
            Debug.Log("AbrirBossGate");
            canTriggerBossAnim = true;


        }
    }

    void StopBossGateAnimVibr()
    {
        if (isClosed2)
        {
            bossGateAnimVibration.enabled = false;
            bossGateVSF.SetActive(false);
            
        }

        
    }
}
