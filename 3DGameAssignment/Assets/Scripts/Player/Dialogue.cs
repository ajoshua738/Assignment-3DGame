using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    //public TMP_Text textOB;
    public GameObject textOB;
    public AudioSource dialogueSound;
    public GameObject Activator;
    public string dialogue = "Dialogue";
    //bool isCollided = false;

    string playerTag = "Player";

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        //textOB.GetComponent<TMP_Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == playerTag)
        {
            //isCollided = true;
            textOB.SetActive(true);
            textOB.GetComponent<TMP_Text>().text = dialogue.ToString();
            dialogueSound.Play();
            Destroy(Activator);
        
            //StartCoroutine(DisableText());
        }
    }

   /* IEnumerator DisableText()
    {
        yield return new WaitForSeconds(timer);
        textOB.GetComponent<TMP_Text>().enabled = false;

    }*/
}
