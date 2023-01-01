using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject lighter;
    public GameObject flames;

    public AudioSource lighterSound;

    public bool isOn;



    void Start()
    {
        isOn = false;
        flames.SetActive(false);
    }




    void Update()
    {
        if(Input.GetButtonDown("Fire1") && lighter.activeInHierarchy && !isOn)
        {
            flames.SetActive(true);
            lighterSound.Play();
            isOn = true;
        }

       

        if (Input.GetButtonDown("Fire2") && lighter.activeInHierarchy && isOn)
        {
            flames.SetActive(false);
            isOn = false;
        }



    }
}
