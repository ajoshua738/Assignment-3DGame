using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoDisableText : MonoBehaviour
{
    public float timer;
    //public TMP_Text textOB;
    public GameObject textOB;
    
    // Start is called before the first frame update
    void Start()
    {
       


    }

    private void Update()
    {
        if (textOB.activeInHierarchy)
        {
          
            StartCoroutine(DisableText());
        }


    }




    IEnumerator DisableText()
    {
        timer = 4;
        yield return new WaitForSeconds(timer);
        textOB.SetActive(false);
       
   

    }
}
