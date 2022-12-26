using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableExit : MonoBehaviour
{

    public GameObject barrier;
    public GameObject keyOBNeeded;
    public GameObject textOB;
    public AudioSource dialogueSound;
    public string dialogue = "Dialogue";
    public float timer;
    bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(true);
        //textOB.GetComponent<TMP_Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyOBNeeded.activeInHierarchy && !isPlayed)
        {
            isPlayed = true;
            barrier.SetActive(false);
            textOB.SetActive(true);
            textOB.GetComponent<TMP_Text>().text = dialogue.ToString();
            dialogueSound.Play();
            //StartCoroutine(DisableText());
        }
    }

  /*  IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.GetComponent<TMP_Text>().enabled = false;
       

    }*/
}
