using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelRewardScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        int tmp = (PlayerPrefs.GetInt("TapeCount") * 10);
        tmp = tmp + PlayerPrefs.GetInt("Reward");
        UIManager.instance.EarnedCoin = tmp;
        this.GetComponent<Text>().text = tmp.ToString();
        //PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + tmp);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
