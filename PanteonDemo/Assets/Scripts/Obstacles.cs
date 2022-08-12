using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private int obstacleType = 0;
    private Vector3 startPos;
    private Player player;
   private OpponentPlayer opponentPlayer;

    //---Horizontal Obstacles---
    [SerializeField] private float delta = .25f;  // Amount to move left and right from the start point
    [SerializeField] private float speed = 4.0f;
    //---End Horizontal Obstacles---

    [SerializeField] private float rotatorSpeed;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        player = GameObject.Find("Player").GetComponent<Player>();

     opponentPlayer = GameObject.FindWithTag("Player").GetComponent<OpponentPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleType == 0)
        {
            return;
        }
        if (obstacleType == 1)
        {
            HorizontalObstacle();
        }
        if (obstacleType == 2)
        {
            StaticObstacle();
        }
        if (obstacleType == 3)
        {
            RotatingStick();
        }

    }

    void HorizontalObstacle()
    {
        //for horizontal obstacle
        Vector3 newPos = startPos;
        newPos.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = newPos;
    }

    void StaticObstacle()
    {
        //empty function
        //Debug.Log("Static Obs");
    }

    void RotatingStick()
    {
        //for rotator stick bonus obstacle
        gameObject.transform.Rotate(0, (90 * Time.deltaTime * rotatorSpeed), 0);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "HorizontalObstacle" && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player")
            {
                //player.isFall = true;
                collision.gameObject.GetComponent<Player>().isFall = true;
               
            }
            else
            {
                //opponentPlayer.isFall = true;
                collision.gameObject.GetComponent<OpponentPlayer>().isFall = true;
               
            }

        }

        if (gameObject.tag == "StaticObstacle" && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player" )
            {
                //player.isFall = true;
                collision.gameObject.GetComponent<Player>().isFall = true;
                
            }
            else
            {
                //opponentPlayer.isFall = true;
               collision.gameObject.GetComponent<OpponentPlayer>().isFall = true;
               
            }
        }

        if (gameObject.tag == "halfDonut" && collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.name == "Player")
            {
               
                collision.gameObject.GetComponent<Player>().isFall = true;
               
            }
            else
            {
              
                collision.gameObject.GetComponent<OpponentPlayer>().isFall = true;
                
            }
        }
        if (gameObject.tag == "Rotator" && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 300);
            
        }
    }
}
