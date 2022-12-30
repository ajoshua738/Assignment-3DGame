using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSaver : MonoBehaviour
{
    float lf;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        x = SceneManager.GetActiveScene().buildIndex;
        DontDestroyOnLoad(gameObject);
        //lf = GameObject.FindWithTag("Flashlight").GetComponent<Flashlight>().lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lf = GameObject.FindWithTag("Flashlight").GetComponent<Flashlight>().lifetime;
        Debug.Log(lf);
        Debug.Log(x);

        if(x != 2)
        {
            lf = GameObject.FindWithTag("Flashlight").GetComponent<Flashlight>().lifetime;
        }

    }
}
