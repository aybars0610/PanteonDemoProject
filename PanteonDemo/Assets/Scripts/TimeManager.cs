using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
  
    //[SerializeField] public float levelFinishedTime =80f;
    //[SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GameObject losePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateTheTimer();

        if (gameFinished == true && gameOver == false)

        {
            confetti.gameObject.SetActive(true);
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);

        }

        if (gameFinished = true && gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            confetti.gameObject.SetActive(false);
            
            losePanel.gameObject.SetActive(true);
        }
    }

    //public void UpdateTheTimer()
    //{
    //    timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    //}
}
