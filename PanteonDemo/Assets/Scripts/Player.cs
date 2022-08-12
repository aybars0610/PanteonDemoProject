using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isFall = false;
    private TimeManager gameOver;
   private TimeManager gameFinished;
    public bool onPaint;
    private Animator anim;
    private PlayerMovement playerMovement;
    [SerializeField] private GameObject PaintWall;
    [SerializeField] private Camera camera;
    public bool isPaint = false;
    [SerializeField] private int _currentLevel = 0;

    //---Rank---
    [SerializeField] private Transform[] opponentPlayers;
    public int _rank;

    //---EndRank---


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        gameOver = GameObject.FindObjectOfType<TimeManager>();
        gameFinished = GameObject.FindObjectOfType<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FallingAnim());
        Rank();

        if (transform.position.y < -.5f)
        {
            isFall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bitis")
        {
            onPaint = true;
            playerMovement.speed = 0;
            anim.SetBool("isStopping", true);
            transform.rotation = Quaternion.Slerp(Quaternion.identity,Quaternion.Euler(0,180,0), Time.deltaTime * 45);
            if (isPaint)
            {
                PaintWall.gameObject.SetActive(true);
            }
            

            camera.gameObject.SetActive(true);
            if (_currentLevel == 1)
            {
                if (_rank==1)
                {
                    FindObjectOfType<TimeManager>().gameOver = false;
                    FindObjectOfType<TimeManager>().gameFinished = true;
                }
                else
                {
                    FindObjectOfType<TimeManager>().gameOver = true;
                    FindObjectOfType<TimeManager>().gameFinished = true;
                }
                
            }

           
        }
    }

    void Rank()
    {
        if (!onPaint)
        {
            int numberOfFrontPlayers = 0;

            for (int i = 0; i < opponentPlayers.Length; i++)
            {
                Vector3 relativePosition = transform.InverseTransformPoint(opponentPlayers[i].transform.position);
                if (relativePosition.z < 0)
                {
                    numberOfFrontPlayers++;
                }
                _rank = (opponentPlayers.Length + 1 - numberOfFrontPlayers);
               
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
            //FindObjectOfType<TimeManager>().gameOver = true;
            //FindObjectOfType<TimeManager>().gameFinished = true;
            if (_currentLevel == 0)
            {
                Time.timeScale = 0;
                // transform.position = new Vector3(0, .5f, -10.0f);
                FindObjectOfType<TimeManager>().gameOver = true;
                FindObjectOfType<TimeManager>().gameFinished = true;

            }
            if (_currentLevel == 1)
            {
                transform.position = new Vector3(0, 0.8f, -0.3f);
                //FindObjectOfType<TimeManager>().gameOver = true;
                //FindObjectOfType<TimeManager>().gameFinished = true;
            }


        }
    }
}
