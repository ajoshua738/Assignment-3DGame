using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Flashlight : MonoBehaviour
{
    public Light light;
    public TMP_Text lifetimeText;

    public TMP_Text batteryText;

    public  float lifetime = 100;

    public float batteries = 0;

    public AudioSource flashON;
    public AudioSource flashOFF;


   

    private bool on;
    private bool off;

    string flashlightKey = "Flashlight";
    string reloadKey = "Reload";
    

    void Start()
    {
        light = GetComponent<Light>();

        off = true;
        light.enabled = false;

       

        
    }



    void Update()
    {

        
        lifetimeText.text = lifetime.ToString("0") + "%";
        batteryText.text = batteries.ToString();

        if (Input.GetButtonDown(flashlightKey) && off)
        {
            flashON.Play();
            light.enabled = true;
            on = true;
            off = false;
        }

        else if (Input.GetButtonDown(flashlightKey) && on)
        {
            flashOFF.Play();
            light.enabled = false;
            on = false;
            off = true;
        }

        if (on)
        {
            lifetime -= 0.5f * Time.deltaTime; //-0.1 every second
        }

        if (lifetime <= 0)
        {
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }

        if (lifetime >= 100)
        {
            lifetime = 100;
        }

        if (Input.GetButtonDown(reloadKey) && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetButtonDown(reloadKey) && batteries == 0)
        {
            return;
        }

        if (batteries <= 0)
        {
            batteries = 0;
        }



    }

}
