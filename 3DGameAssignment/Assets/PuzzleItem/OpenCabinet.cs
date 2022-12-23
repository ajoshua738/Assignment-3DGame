using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCabinet : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator cabinet;
    public GameObject openText;

    public AudioSource cabinetSound;


    public bool inReach;

    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            CabinetOpens();
        }

        else
        {
            CabinetCloses();
        }
    }

    void CabinetOpens()
    {
        Debug.Log("It Opens");
        cabinet.SetBool("Open", true);
        cabinet.SetBool("Closed", false);
        cabinetSound.Play();
     

    }

    void CabinetCloses()
    {
        //Debug.Log("It Closes");
        cabinet.SetBool("Open", false);
        cabinet.SetBool("Closed", true);
    }

}
