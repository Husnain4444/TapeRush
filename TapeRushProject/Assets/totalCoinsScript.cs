using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class totalCoinsScript : MonoBehaviour
{
    public NumberCounter numbercounter;
    public Text rewardText;
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetValue()
    {
        //value = PlayerPrefs.GetInt("TotalCoins") + int.Parse(rewardText.text);
        if(int.TryParse(this.GetComponent<Text>().text,out value))
        {
            value = PlayerPrefs.GetInt("TotalCoins") + int.Parse(rewardText.text);
            numbercounter.Value = value;
            //numbercounter.NewVal = value;
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + int.Parse(rewardText.text));
        }
    }
    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("TotalCoins").ToString();
    }
    // Update is called once per frame
    void Update()
    {
        value = PlayerPrefs.GetInt("TotalCoins") - int.Parse(rewardText.text);
        
    }
}
