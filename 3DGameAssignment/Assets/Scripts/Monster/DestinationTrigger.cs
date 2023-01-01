using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    public Collider collision;
    string monsterTag = "Monster";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(monsterTag))
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
