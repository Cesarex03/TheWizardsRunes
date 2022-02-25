using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSounds : MonoBehaviour
{
    [SerializeField] AudioSource footSteep1; 
    [SerializeField] AudioSource footSteep2;
    [SerializeField] AudioSource jumpSteepOn; 
    [SerializeField] AudioSource jumpSteepOf;  
    // Start is called before the first frame update
    void Start()
    {
        footSteep1 = GetComponent<AudioSource>();
        footSteep2 = GetComponent<AudioSource>();
        jumpSteepOn = GetComponent<AudioSource>();
        jumpSteepOf = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FootSteepSound1(){

        footSteep1.Play();
    }
    void FootSteepSound2(){

        footSteep2.Play();
    }
    void jumpSteepOnGround(){

        jumpSteepOn.Play();
    }
    void jumpSteepOfGround(){

        jumpSteepOf.Play();
    }
}
