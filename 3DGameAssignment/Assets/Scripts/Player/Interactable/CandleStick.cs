using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleStick : MonoBehaviour
{
    public GameObject lighterOB;
    public GameObject flame;
    public GameObject lightText;
    public AudioSource candleSound;


    public bool unlit;
    public bool inReach;
    string reachTag = "Reach";
    string interactKey = "Interact";
    // Start is called before the first frame update
    void Start()
    {
        unlit = true;
        flame.SetActive(false);
        lightText.SetActive(false);
        inReach = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(lighterOB.activeInHierarchy && inReach && Input.GetButtonDown(interactKey))
        {
            flame.SetActive(true);
            lightText.SetActive(true);
            unlit = false;
            candleSound.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == reachTag && unlit)
        {
            inReach = true;
            lightText.SetActive(true);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == reachTag)
        {
            inReach = false;
            lightText.SetActive(false);
        }


    }
}
