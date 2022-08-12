using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{




    [SerializeField] private int _currentLevel = 0;
   // private int _currentLevel;

    //---Task2---
    private Player player;
    private Transform playerTransform;
    public GameObject paintable;
    private bool doOnce = true;
    //---EndTask2---

    //---Task3---
    public Text rankText;

    //---EndTask3---

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentLevel == 0)
        {
            if (player.onPaint && doOnce)
            {
                GameObject paint = Instantiate(paintable, new Vector3(playerTransform.position.x, .8f, 24.5f), Quaternion.Euler(270f, 0, 0));
                doOnce = false;
            }
        }
      
        if (_currentLevel == 1)
        {
            rankText.text = "Rank:" + player._rank.ToString();

        }

    }
}


