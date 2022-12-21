using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCountStrengthPaintFeatureScript : MonoBehaviour
{
    
    public Text countText;
    public Text LevelCountText;
    public BalancePlayerState bps;
    public Text MaxLevelReached;
    public List<GameObject> player;
    public Button btn1;
    public Button NoCoinsButton;
    public NumberCounter nc;
    // Start is called before the first frame update
    void Start()
    {
        ButtonEnableAndDisable(PlayerPrefs.GetInt("TotalCoins"));
        if (PlayerPrefs.GetInt("CountLevel") == 0)
        {
            PlayerPrefs.SetInt("CountLevel", 1);

        }
        LevelCountText.text = PlayerPrefs.GetInt("CountLevel").ToString();

    }
    private void Awake()
    {
        
        //LevelCountText.text = PlayerPrefs.GetInt("CountLevel",1).ToString();
        bps.AddNewTape((PlayerPrefs.GetInt("CountLevel") - 1) );
    }

    public void AddCount()
    {

        int totalCoins = PlayerPrefs.GetInt("TotalCoins");
        int amount = int.Parse(countText.text);
        Debug.Log(PlayerPrefs.GetInt("TotalCoins") - amount);
        if((PlayerPrefs.GetInt("TotalCoins") - amount) > 0)
        {
            nc.Value = PlayerPrefs.GetInt("TotalCoins") - amount;
        }
        else
        {
            nc.Value = 0;
        }
        
        if (amount <= totalCoins && PlayerPrefs.GetInt("CountLevel")<10)
        {
            //PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - amount);
            AddTape();
            PlayerPrefs.SetInt("CountLevel", PlayerPrefs.GetInt("CountLevel") + 1);
            ButtonEnableAndDisable(PlayerPrefs.GetInt("TotalCoins") - amount);
            
            LevelCountText.text = PlayerPrefs.GetInt("CountLevel").ToString();
        }
        
        if(PlayerPrefs.GetInt("CountLevel")>=10)
        {
            PlayerPrefs.SetInt("CountLevel", 10);
            LevelCountText.text = PlayerPrefs.GetInt("CountLevel").ToString();
            btn1.gameObject.SetActive(false);
            NoCoinsButton.gameObject.SetActive(false);
            MaxLevelReached.gameObject.SetActive(true);
        }

    }
    public void AddTape()
    {
        bps.AddNewTape(1);
        //player[0].SetActive(true);
        //player[0].GetComponent<hurdleCollider>().trail.gameObject.SetActive(true);
        //player.Remove(player[0]);
        //player[0].transform.parent.gameObject.GetComponent<BalancePlayerState>().BalancePlayer();
    }
    public void ButtonEnableAndDisable(int coins)
    {
        Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
        int amount = int.Parse(countText.text);
        int totalCoins = coins;
        if (amount <= totalCoins)
        {
            btn1.gameObject.SetActive(true);
            NoCoinsButton.gameObject.SetActive(false);
        }
        else if (amount > totalCoins)
        {
            btn1.gameObject.SetActive(false);
            NoCoinsButton.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("CountLevel") >= 10)
        {
            btn1.gameObject.SetActive(false);
            NoCoinsButton.gameObject.SetActive(false);
            MaxLevelReached.gameObject.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
