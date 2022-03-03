using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject fireMobile;

    public bool fireOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("FireBall"))
        {
            fireMobile.SetActive(true);
            Destroy(other.gameObject);
            fireOn = true;
        }
    }
}
