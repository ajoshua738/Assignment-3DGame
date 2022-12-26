using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayScarySound : MonoBehaviour
{

    public AudioSource scarySound;
    public GameObject soundTrigger;

    string playerTag = "Player";

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
          scarySound.Play();
      
          soundTrigger.SetActive(false);

        }
    }

}
