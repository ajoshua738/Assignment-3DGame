using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterJumpscare : MonoBehaviour
{
    public Animator monsterAnimator;
    public GameObject player;
    public AudioSource jumpscareSound;
    public float jumpscareTime;
    public int sceneIndex;
    public MonsterAI monsterAIScript;
    public GameObject flashlight;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            flashlight.SetActive(false);
            monsterAIScript.enabled = false;
            jumpscareSound.Play();
            monsterAnimator.ResetTrigger("Walk");
            monsterAnimator.ResetTrigger("Idle");
            monsterAnimator.ResetTrigger("Chase");
            monsterAnimator.SetTrigger("Jumpscare");
            StartCoroutine(jumpscare());

        }
    }


    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
