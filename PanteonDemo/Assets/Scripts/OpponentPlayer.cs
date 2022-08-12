using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentPlayer : MonoBehaviour
{
    //---Move---
    public float speed = 1f;
    public bool isFall = false;
    private Transform finishLine;
    private NavMeshAgent agent;
    private bool isFinish = false;
    private Vector3 move;
    //---EndMove---
    private Animator anim;

    public GameObject finishObj;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        finishLine = GameObject.FindWithTag("Bitis").GetComponent<Transform>();
       
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        StartCoroutine(FallingAnim());

        if (transform.position.y < -.5f)
        {
            isFall = true;
        }
    }

    void Move()
    {
        if (!isFall && !isFinish)
        {
            anim.SetBool("isRunning", true);
            agent.speed = 1.5f;

         //  agent.SetDestination(finishLine.localPosition + new Vector3(Random.Range(-9.15f, 9.15f), 0, 0));
            

          agent.SetDestination(finishObj.transform.position + new Vector3(Random.Range(-9.15f,9.15f),0,0));
            // agent.destination = finishObj.transform.position + new Vector3(Random.Range(-1.15f, 1.15f), 0, 0);


            if (gameObject.transform.parent != null)
            {
                agent.speed = .8f;
                move = new Vector3(gameObject.transform.parent.gameObject.GetComponent<RotatePlatform>().rotationDirSpeed / 2, 0, 0);
                transform.Translate(move * Time.deltaTime);
                anim.SetBool("isForwarding", true);
            }
            else
            {
                anim.SetBool("isForwarding", false);
                agent.speed = 1f;
            }
        }
        
    }

  

    IEnumerator FallingAnim()
    {
        if (isFall)
        {
            anim.SetBool("isFalling", true);
            yield return new WaitForSeconds(1f);
            anim.SetBool("isFalling", false);
            isFall = false;
           transform.position = new Vector3(Random.Range(-1.3f,1.3f), .5f, -0.3f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bitis")
        {
            anim.SetBool("isStopping", true);
            agent.speed = 0;
            isFinish = true;
        }
    }
}
