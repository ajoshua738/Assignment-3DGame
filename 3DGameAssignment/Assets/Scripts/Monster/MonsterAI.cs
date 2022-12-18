using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public NavMeshAgent monster;
    public Animator monsterAnimator;
    int randNum;
    public Transform playerTransform, monsterTransform, cDestination_1, cDestination_2, cDestination_3, cDestination_4;
    public bool walking, chasing, idle;
    Vector3 destPoint;
    public float chaseTime;
    public float IdleTime;

    // Start is called before the first frame update
    void Start()
    {
        findDest();
    }

    // Update is called once per frame
    void Update()
    {
        if (walking == true)
        {
            monster.destination = destPoint;
            monster.speed = 1;
        }

        if (chasing == true)
        {
            monster.destination = playerTransform.position;
            monster.speed = 4;
        }

        if (idle == true)
        {
            monster.speed = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            chasing = true;
            walking = false;
            idle = false;
            monsterAnimator.ResetTrigger("Idle");
            monsterAnimator.ResetTrigger("Walk");
            monsterAnimator.SetTrigger("Run");
            StopCoroutine("nextDest");
            StopCoroutine("chase");
            StartCoroutine("chase");
        }

        if (other.CompareTag("Destination"))
        {
            if (chasing == false)
            {
                idle = true;
                walking = false;
                monsterAnimator.ResetTrigger("Walk");
                monsterAnimator.SetTrigger("Idle");
                StartCoroutine("nextDest");
            }
        }
    }

    IEnumerator nextDest()
    {
        yield return new WaitForSeconds(IdleTime);
        idle = false;
        walking = true;
        monsterAnimator.ResetTrigger("Idle");
        monsterAnimator.SetTrigger("Walk");

        findDest();
    }

    IEnumerator chase()
    {
        yield return new WaitForSeconds(chaseTime);
        chasing = false;
        walking = true;
        monsterAnimator.ResetTrigger("Idle");
        monsterAnimator.ResetTrigger("Run");
        monsterAnimator.SetTrigger("Walk");
        findDest();
    }

    void findDest()
    {
        walking = true;
        randNum = Random.Range(1, 4);

        monsterAnimator.SetTrigger("Walk");
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
