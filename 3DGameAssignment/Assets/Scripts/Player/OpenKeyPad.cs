using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public GameObject keypadOB;
    public GameObject keypadText;

    public bool inReach;
    string reachTag = "Reach";
    string interactKey = "Interact";

 
 
    public AudioSource dialogueSound;

    public GameObject textOB;
    public string dialogue = "Dialogue";
    public TMP_Text itemCountText;






    void Start()
    {
   
        inReach = false;
     
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = true;
            keypadText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = false;
            keypadText.SetActive(false);

        }
    }




    void Update()
    {
        if (Input.GetButtonDown(interactKey) && inReach)
        {
            if (itemCountText.text == "All Items Found!")
            {
                keypadOB.SetActive(true);

            }
            else
            {
                textOB.SetActive(true);
                textOB.GetComponent<TMP_Text>().text = dialogue.ToString();
                dialogueSound.Play();
            }


        }

      
     


       


    }
}
