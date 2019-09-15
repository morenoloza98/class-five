using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text timer;
    public Text gameOver;
    private float timeRemaining;
    public GameObject[] cards;
    GameMaster gameMasterScript;
    public GameObject gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 10f;
        gameMasterScript = gameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 60)
        {
            float minutes = Mathf.Round(timeRemaining / 60);
            float seconds = Mathf.Round(timeRemaining % 60);
            if (seconds <= 9)
            {
                timer.text = "Timer: " + minutes + ":0" + seconds;
            }
            else
            {
                timer.text = "Timer: " + minutes + ":" + seconds;
            }
        }
        else
        {
            timer.text = "Timer: 00:" + Mathf.Round(timeRemaining);
        }
        timeRemaining -= Time.deltaTime;
        GameOver();
    }

    void GameOver()
    {
        if (timeRemaining <= 0 && gameMasterScript.count != 0)
        {
            for(int i = 0; i <cards.Length; i++)
            {
                cards[i].gameObject.SetActive(false);
            }

            gameOver.gameObject.SetActive(true);
            gameOver.text = "You lose";
            timer.text = "";
        }

        if(timeRemaining > 0 && gameMasterScript.count == 0)
        {
            gameOver.gameObject.SetActive(true);
            gameOver.text = "You win";
            timer.gameObject.SetActive(false);
        }
    }
}
