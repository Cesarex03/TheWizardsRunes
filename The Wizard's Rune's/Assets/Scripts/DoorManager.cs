using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] TotemsTrigger antorcha1;
    [SerializeField] TotemsTrigger antorcha2;
    [SerializeField] Animator rockGateAnimVibration;
    [SerializeField] GameObject gateVSF;
    public bool canTriggerOtherAnim = false;
    public bool isClosed = false;
    public bool isClosedSound = false;
    [SerializeField] AudioSource rockGateClosedSound;
    // Start is called before the first frame update
    void Start()
    {
        rockGateAnimVibration = GetComponent<Animator>();
        rockGateClosedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RockGateAnimations();
        StopAnimVibr();
        if (isClosedSound)
        {
            rockGateClosedSound.Play();
            isClosedSound = false;
        }

    }
    void RockGateAnimations()
    {
        if (antorcha1.fireOn && antorcha2.fireOn && !isClosed)
        {
            gateVSF.SetActive(true);
            rockGateAnimVibration.SetBool("isStop", true);
            Debug.Log("Abrir");
            canTriggerOtherAnim = true;


        }

    }
    void StopAnimVibr()
    {
        if (isClosed)
        {
            rockGateAnimVibration.enabled = false;
            gateVSF.SetActive(false);

        }


    }
}
