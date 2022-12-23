using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEvent : MonoBehaviour
{

    public GameObject monsterSkin;
    public GameObject monsterObj;
    public GameObject eventTrigger;
    float timer = 1.0f;
 


    /*lifetime -= 0.1f * Time.deltaTime; //-0.1 every second*/
    // Start is called before the first frame update
    void Start()
    {
        monsterSkin.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (eventTrigger.activeInHierarchy == false)
        {
            monsterSkin.SetActive(true);
        }
        if (monsterSkin.activeInHierarchy)
        {
            timer -= 0.5f * Time.deltaTime;


        }


        if (timer <= 0)
        {
            monsterObj.SetActive(false);
        }

    }

    
}
