using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scGamePlaycONTROLLER : MonoBehaviour
{
    public GameObject secondChancePanel;
    public GameObject player;
    bool scndgameStart;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        scndgameStart = true;
        gameOver.GetComponent<gameOverScript>().sc = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && scndgameStart)
        {
            secondChancePanel.SetActive(false);
            SecondChanceGamePlay();
            scndgameStart = false;
        }
        //if (PlayerPrefs.GetInt("TapeCount") == 0)
        //{
        //    gameOver.GetComponent<gameOverScript>().simpleGameOver();
        //}
        
    }
    public void SecondChanceGamePlay()
    {
        player.GetComponent<PathFollower>().speed1 = 50;
    }
}
