using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private bool inReach;

    public GameObject pickUpText;
    private GameObject flashlight;

    public AudioSource pickUpSound;
    string reachTag = "Reach";
    string flashlightOB = "Flashlight";

    string interactKey = "Interact";

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        flashlight = GameObject.Find(flashlightOB);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = true;
            pickUpText.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }




    void Update()
    {
        if (Input.GetButtonDown(interactKey) && inReach)
        {
            flashlight.GetComponent<Flashlight>().batteries += 1;
            pickUpSound.Play();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject);
        }

    }
}
