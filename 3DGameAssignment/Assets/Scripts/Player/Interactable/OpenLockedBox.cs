using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedBox : MonoBehaviour
{
    public Animator boxOB;
    public GameObject keyOBNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public GameObject lootItem;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;

    string reachTag = "Reach";
    string interactKey = "Interact";
  


    void Start()
    {
        lootItem.SetActive(false);
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = true;
            openText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }


    void Update()
    {
        if (keyOBNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown(interactKey))
        {
            keyOBNeeded.SetActive(false);
            openSound.Play();
            boxOB.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
        }

        else if (keyOBNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown(interactKey))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            boxOB.GetComponent<BoxCollider>().enabled = false;
            boxOB.GetComponent<OpenLockedBox>().enabled = false;
            lootItem.SetActive(true);
        }
    }
}
