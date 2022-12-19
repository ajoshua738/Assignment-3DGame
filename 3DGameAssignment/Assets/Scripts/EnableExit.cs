using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableExit : MonoBehaviour
{

    public GameObject barrier;
    public GameObject keyOBNeeded;

    // Start is called before the first frame update
    void Start()
    {
        barrier.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (keyOBNeeded.activeInHierarchy)
        {
            barrier.SetActive(false);
        }
    }
}
