using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastDateTimeScript : MonoBehaviour
{
    public Text txt;
    public Text showIncome;
    string str;
    int hours;
    public NumberCounter nc;
    public Button claim;
    public Button noCoins;
    public Text showLevelNoTxt;
    public GameObject maxlevelReached;
    private System.DateTime currentDate;
    private System.DateTime previousDate;
    public int val;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("OfflineVal") == 0)
        {
            PlayerPrefs.SetInt("OfflineVal", 50);

        }
        showIncome.text = PlayerPrefs.GetInt("OfflineVal", 50).ToString();
        str = PlayerPrefs.GetString("hours", " ");

        if (str == null || str == " ")
        {
            str = System.DateTime.Now.ToString();
            previousDate = System.DateTime.Now;
        }
        else
        {
            previousDate = System.DateTime.Parse(str);

        }
        currentDate = System.DateTime.Now;
        System.TimeSpan span = currentDate.Subtract(previousDate);
        hours = span.Hours;
        if (hours > 24)
        {
            hours = 24;
        }
        val = PlayerPrefs.GetInt("IncomeLevel") * 5;
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + (hours * val));

        txt.text = (hours * 10).ToString();
        PlayerPrefs.SetString("hours", currentDate.ToString());
        ButtonEnableAndDisable();
        //ClaimReward();

    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("IncomeLevel") == 0)
        {
            PlayerPrefs.SetInt("IncomeLevel", 1);

        }
        showLevelNoTxt.text = PlayerPrefs.GetInt("IncomeLevel").ToString();
        ButtonEnableAndDisable();
    }
    public void ClaimReward()
    {
        nc.Value = PlayerPrefs.GetInt("TotalCoins") - int.Parse(showIncome.text);
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") - int.Parse(showIncome.text));
        PlayerPrefs.SetInt("OfflineVal", PlayerPrefs.GetInt("OfflineVal") * 2);
        showIncome.text = PlayerPrefs.GetInt("OfflineVal").ToString();
        ButtonEnableAndDisable();
        PlayerPrefs.SetInt("IncomeLevel", PlayerPrefs.GetInt("IncomeLevel") + 1);
        showLevelNoTxt.text = PlayerPrefs.GetInt("IncomeLevel").ToString();
        hours = 0;
        txt.text = 0.ToString();
    }

    private void OnDestroy()
    {
        //PlayerPrefs.SetString("hours", System.DateTime.Now.ToString());
    }
    // Update is called once per frame
    void Update()
    {

        showIncome.text = PlayerPrefs.GetInt("OfflineVal").ToString();
        //if (int.Parse(txt.text) == 0)
        //{
        //    claim.interactable = false;
        //}
        //else
        //{

        //    claim.interactable = true;

        //}
        if (System.Environment.ExitCode == 1)
        {
            PlayerPrefs.SetString("hours", System.DateTime.Now.ToString());
        }
    }

    public void ButtonEnableAndDisable()
    {
        Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
        int amount = int.Parse(showIncome.text);
        int totalCoins = PlayerPrefs.GetInt("TotalCoins");
        if (amount <= totalCoins)
        {
            claim.gameObject.SetActive(true);
            noCoins.gameObject.SetActive(false);
        }
        else if (amount > totalCoins)
        {
            claim.gameObject.SetActive(false);
            noCoins.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("IncomeLevel") >= 10)
        {
            claim.gameObject.SetActive(false);
            noCoins.gameObject.SetActive(false);
            maxlevelReached.gameObject.SetActive(true);
        }

    }

    private void Application_quitting()
    {
        PlayerPrefs.SetString("hours", System.DateTime.Now.ToString());
        //throw new System.NotImplementedException();
    }
}
