using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerAI : MonoBehaviour
{

    public NavMeshAgent crawler;
    public Animator crawlerAnimator;
    int randNum;
    public Transform playerTransform, crawlerTransform, cDestination_1, cDestination_2, cDestination_3, cDestination_4;
    public bool walking, chasing, idle;
    Vector3 destPoint;
    public float chaseTime;
    public float idleTime;

    // Start is called before the first frame update
    void Start()
    {
        findDest();
    }

    // Update is called once per frame
    void Update()
    {
        if(walking == true)
        {
            crawler.destination = destPoint;
            crawler.speed = 2;
        }

        if (chasing == true)
        {
            crawler.destination = playerTransform.position;
            crawler.speed = 5;
        }

        if(idle == true)
        {
            crawler.speed = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            chasing = true;
            walking = false;
            idle = false;
            crawlerAnimator.ResetTrigger("idle");
            crawlerAnimator.ResetTrigger("walk");
            crawlerAnimator.SetTrigger("run");
            StopCoroutine("nextDest");
            StopCoroutine("chase");
            StartCoroutine("chase");
        }

        if (other.CompareTag("Destination"))
        {
            if(chasing == false)
            {
                idle = true;
                walking = false;
                crawlerAnimator.ResetTrigger("walk");
                crawlerAnimator.SetTrigger("idle");
                StartCoroutine("nextDest");
            }
        }
    }

    IEnumerator nextDest()
    {
        yield return new WaitForSeconds(idleTime);
        idle = false;
        walking = true;
        crawlerAnimator.ResetTrigger("idle");
        crawlerAnimator.SetTrigger("walk");

        findDest();
    }

    IEnumerator chase()
    {
        yield return new WaitForSeconds(chaseTime);
        chasing = false;
        walking = true;
        crawlerAnimator.ResetTrigger("idle");
        crawlerAnimator.ResetTrigger("run");
        crawlerAnimator.SetTrigger("walk");
        findDest();
    }

    void findDest()
    {
        walking = true;
        randNum = Random.Range(1, 4);

        crawlerAnimator.SetTrigger("walk");
        if (randNum == 1)
        {
            destPoint = cDestination_1.position;
        }

        if (randNum == 2)
        {
            destPoint = cDestination_2.position;
        }

        if (randNum == 3)
        {
            destPoint = cDestination_3.position;
        }

        if (randNum == 4)
        {
            destPoint = cDestination_4.position;
        }
    }
}
