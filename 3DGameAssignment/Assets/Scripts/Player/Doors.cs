using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Animator door;
    public GameObject lockOB;
    public GameObject keyOB;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;
    public AudioSource dialogueSound;
    //public TMP_Text textOB;
    public GameObject textOB;
    public string dialogue = "The door is locked. I need to find a Key";

    private bool inReach;
    private bool doorisOpen;
    private bool doorisClosed;
    public bool locked;
    public bool unlocked;

    public float timer;

    string reachTag = "Reach";

    string interactKey = "Interact";
    //To show hint text UI
    void OnTriggerEnter(Collider other)
    {
        //if player collide with door knob and the door is closed.
        if (other.gameObject.tag == reachTag && doorisClosed)
        {
            inReach = true;
            openText.SetActive(true); //Open Door [E]
        }

        //if player collide with door knob and the door is open.
        if (other.gameObject.tag == reachTag && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);//Close Door [E]
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
        //textOB.GetComponent<TMP_Text>().enabled = false;
        inReach = false;
        doorisClosed = true;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
        keyOB.SetActive(false);
    }




    void Update()
    {
        //if it has a lock
        if (lockOB.activeInHierarchy)
        {
            locked = true;
            unlocked = false;
        }
        //if it does not
        else
        {
            unlocked = true;
            locked = false;
        }

        //if theres a key
        if (inReach && keyOB.activeInHierarchy && Input.GetButtonDown(interactKey))
        {
            lockOB.SetActive(false);    
            unlockedSound.Play();
            locked = false;
            keyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }

        //no key no lock
        if (inReach && doorisClosed && unlocked && Input.GetButtonDown(interactKey))
        {
            door.SetBool("Open", true);
            door.SetBool("Closed", false);
            openText.SetActive(false);
            openSound.Play();
            doorisOpen = true;
            doorisClosed = false;
        }

        else if (inReach && doorisOpen && unlocked && Input.GetButtonDown(interactKey))
        {
            door.SetBool("Open", false);
            door.SetBool("Closed", true);
            closeText.SetActive(false);
            closeSound.Play();
            doorisClosed = true;
            doorisOpen = false;
        }

        if (inReach && locked && Input.GetButtonDown(interactKey))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            lockedSound.Play();

            textOB.SetActive(true);
            textOB.GetComponent<TMP_Text>().text = dialogue.ToString();
            dialogueSound.Play();
            //StartCoroutine(DisableText());
        }

    }

   /* IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.GetComponent<TMP_Text>().enabled = false;
      

    }*/


    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {

            unlocked = true;
            lockOB.SetActive(false);
        }
    }




}
