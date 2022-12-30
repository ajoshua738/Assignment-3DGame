using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjective : MonoBehaviour
{

    public GameObject item1,item2,item3,item4,item5;
    
    public TMP_Text itemCountText;
    public float noItems = 0;

  

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (noItems < 5)
        {

            itemCountText.text = noItems.ToString("0") + " / 5";
            if (item1.activeInHierarchy)
            {
                noItems += 1;
                item1.SetActive(false);

            }

            if (item2.activeInHierarchy)
            {
                noItems += 1;
                item2.SetActive(false);

            }

            if (item3.activeInHierarchy)
            {
                noItems += 1;
                item3.SetActive(false);

            }

            if (item4.activeInHierarchy)
            {
                noItems += 1;
                item4.SetActive(false);

            }

            if (item5.activeInHierarchy)
            {
                noItems += 1;
                item5.SetActive(false);

            }
        }


        if(noItems >= 5)
        {
            itemCountText.text = "All Items Found!";
        }


    }
}
