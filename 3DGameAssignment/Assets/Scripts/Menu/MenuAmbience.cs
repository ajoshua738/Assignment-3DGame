using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAmbience : MonoBehaviour
{

    public AudioSource menuAmbience;

    public float minTime = 15;
    public float maxTime = 45;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
     
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
          menuAmbience.Play();

            timer = Random.Range(minTime, maxTime);

        }
    }
}
