using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCabinet : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator cabinet;
    public GameObject openText;
    public GameObject lootItem;
    public AudioSource cabinetSound;
    public GameObject invOB;


    public bool inReach;

    void Start()
    {
        lootItem.SetActive(false);
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

        if (!invOB.activeInHierarchy)
        {
            lootItem.SetActive(true);
        }
        cabinet.SetBool("Open", true);
        cabinet.SetBool("Closed", false);
        cabinetSound.Play();
        


    }

    void CabinetCloses()
    {

        cabinet.SetBool("Open", false);
        cabinet.SetBool("Closed", true);
    }

}
