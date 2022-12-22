using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using IronSourceJSON;
public class gameOverScript : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject newskinAddedScreen;
    public GameObject player;
    public GameObject MainPlayer;
    private int count = 0;
    public coinsAnimation coinAnim;
    public totalCoinsScript totalCoinsCounter;
    public GameObject swipeDetector;
    bool isOver;
    public static gameOverScript instance;
    public GameObject secondChanceScript;
    public bool sc;
    private void Awake()
    {
        sc = true;
        instance = this;
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            GameOver();
        }
    }
    private void Start()
    {
        count = 0;
    }
    public void FixedUpdate()
    {

        count = 0;
        foreach (Transform t in player.transform)
        {
            if (t.tag == "Player")
            {
                count = count + 1;
            }
        }
        if (count == 0)
        {
            GameOver();
        }

    }
    public void GameWin()
    {
        if (isOver)
        {
            return;
        }
        isOver = true;
        gameplay.SetActive(false);
        gameWin.SetActive(true);

        swipeDetector.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Core.Movement.MovementController>().enabled = false;
        MainPlayer.GetComponent<PathFollower>().enabled = false;
        UIManager.instance.OnGameWin(count);
    }
    public void GameOver()
    {
        //if (isOver)
        //{

        //    return;
        //}
        //isOver = true;
        PlayerPrefs.SetFloat("PlayerZ", MainPlayer.transform.position.z);
        //UIManager.instance.OnGameOver();
        //MainPlayer.GetComponentInChildren<Animator>().SetBool("secondChance", true);
        gameplay.SetActive(false);
        gameOver.SetActive(true);
        swipeDetector.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Core.Movement.MovementController>().enabled = false;
        MainPlayer.GetComponent<PathFollower>().enabled = false;

    }
    public void simpleGameOver()
    {
        gameplay.SetActive(false);
        gameOver.SetActive(true);
        swipeDetector.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Core.Movement.MovementController>().enabled = false;
        MainPlayer.GetComponent<PathFollower>().enabled = false;
    }
    public void NextLevel()
    {
        coinAnim.AnimateCoins();
        PlayerPrefs.SetInt("KeyConsumed", 0);
        IronSourceScript.instance.InterstitialShow();


        if (PlayerPrefs.GetInt("TapeSkin") == 1)
        {


            StartCoroutine("delay2");
        }
        else
        {
            StartCoroutine("delay");

        }

    }
    public void ClaimNewSkinBtn()
    {
        PlayerPrefs.SetInt("NewTapes", PlayerPrefs.GetInt("NewTapes") + 1);
        newskinAddedScreen.SetActive(false);
        gameWin.SetActive(false);
        IronSourceScript.instance.InterstitialShow();
        SceneManager.LoadScene(0);

    }
    public void loseSkinButton()
    {
        //PlayerPrefs.SetInt("NewTapes", PlayerPrefs.GetInt("NewTapes") - 1);
        if (PlayerPrefs.GetInt("NewTapes") > 6)
        {
            PlayerPrefs.SetInt("NewTapes", PlayerPrefs.GetInt("NewTapes") + 1);
            //player.GetComponent<BalancePlayerState>().ReplaceTape(PlayerPrefs.GetInt("NewTapes") - 1);

        }
        newskinAddedScreen.SetActive(false);
        gameWin.SetActive(false);

        SceneManager.LoadScene(0);

    }
    IEnumerator delaySC()
    {
        yield return new WaitForSeconds(2f);
        player.GetComponent<BalancePlayerState>().AddTapes(3);
        player.transform.position = new Vector3(0f, player.transform.position.y, player.transform.position.z);
    }
    public void SecondChance()
    {
        PlayerPrefs.SetInt("TapeCount", 3);

        //Time.timeScale = 0;
        swipeDetector.GetComponent<SwipeDetecter>().SecondChanceStartPanel.SetActive(true);
        //MainPlayer.transform.position = new Vector3(0f, 0f, MainPlayer.transform.position.z);
        MainPlayer.GetComponent<PathFollower>().speed1 = 0f;
        PlayerPrefs.SetInt("enable", 0);
        //player.transform.position = new Vector3(0f, 0f, 0f);
        player.GetComponent<Rigidbody>().isKinematic = true;
        //isOver = false;
        StartCoroutine("delaySC");

        //MainPlayer.GetComponent<PathFollower>().enabled = true;
        gameplay.SetActive(true);
        gameOver.SetActive(false);
        swipeDetector.SetActive(true);
        player.GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<Core.Movement.MovementController>().enabled = true;
        MainPlayer.GetComponent<PathFollower>().enabled = true;
        secondChanceScript.SetActive(true);
    }
    IEnumerator delay2()
    {
        yield return new WaitForSeconds(1f);
        totalCoinsCounter.SetValue();

        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        yield return new WaitForSeconds(1f);
        newskinAddedScreen.SetActive(true);


    }
    IEnumerator delay()
    {
        new WaitForSeconds(1f);
        totalCoinsCounter.SetValue();

        yield return new WaitForSeconds(2f);
        gameWin.SetActive(false);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(0);

    }
    public void Restart()
    {
        // IronSourceScript.instance.InterstitialShow();
        PlayerPrefs.SetInt("KeyConsumed", 1);
        SceneManager.LoadScene(0);
    }
}
