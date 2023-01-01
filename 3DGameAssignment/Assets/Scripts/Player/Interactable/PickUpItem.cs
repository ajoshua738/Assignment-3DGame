using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItem : MonoBehaviour
{
    public GameObject itemOB;
    public GameObject invOB;

    public GameObject pickUpText;
    public AudioSource pickUpSound;

    public bool inReach;

    //public TMP_Text textOB;
    public GameObject textOB;
    public string dialogue = "Dialogue";
    public AudioSource dialogueSound;

    string reachTag = "Reach";
    string interactKey = "Interact";

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        //textOB.GetComponent<TMP_Text>().enabled = false;
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);

     
     
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown(interactKey))
        {

           
            pickUpSound.Play();
            invOB.SetActive(true);
            pickUpText.SetActive(false);

            textOB.SetActive(true);
            textOB.GetComponent<TMP_Text>().text = dialogue.ToString();
            dialogueSound.Play();
            Destroy(itemOB);
            //StartCoroutine(DisableText());
        }
    }

   /* IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.GetComponent<TMP_Text>().enabled = false;
       


    }*/

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
}
