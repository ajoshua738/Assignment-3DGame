using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    public Collider collision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            StartCoroutine(enableTrigger());
            collision.enabled = false;  
        }
    }

    IEnumerator enableTrigger()
    {
        yield return new WaitForSeconds(2.0f);
        collision.enabled = true;
    }
}
