using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public Transform[] AllSkinObj, AllCoolSkinObj, AllGiftObj;
    public Texture[] AllSkinTexture, AllCoolSkinTexture;
    public int[] CoolSkinPrice;
    private void OnEnable()
    {
        Init();
        PlayerPrefs.DeleteAll();
    }
    void Init()
    {
        int skinIndex = PlayerPrefs.GetInt("PatternReward");
        //set All Skin
        for (int i = 0; i < AllSkinObj.Length; i++)
        {
            if (i < skinIndex)
            {
                AllSkinObj[i].GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                AllSkinObj[i].GetChild(1).gameObject.SetActive(true);
            }
        }

        //Set All Cool Skin
        for (int i = 0; i < AllCoolSkinObj.Length; i++)
        {
            if ((PlayerPrefs.GetInt("Cool" + i)) == 1 || i == 0)
            {
                AllCoolSkinObj[i].GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                AllCoolSkinObj[i].GetChild(1).gameObject.SetActive(true);
            }
        }

        //Set All Gift
        int GiftIndex = PlayerPrefs.GetInt("GiftIndex");
        for (int i = 0; i < AllGiftObj.Length; i++)
        {
            if (i < GiftIndex)
            {
                AllGiftObj[i].GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                AllGiftObj[i].GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void OnCoolSkinPurchased(int index)
    {
        int totalCoin = PlayerPrefs.GetInt("TotalCoins");
        int amount = CoolSkinPrice[index];
        if (amount <= totalCoin)
        {
            totalCoin -= amount;
            PlayerPrefs.SetInt("TotalCoins", totalCoin);
            PlayerPrefs.SetInt("Cool" + index, 1);
            AllCoolSkinObj[index].GetChild(1).gameObject.SetActive(false);
            UIManager.instance.ShowToast("Purchased Successfully!");

        }
        else
        {
            UIManager.instance.ShowToast("Not enough Coins!");
        }
    }
    public void OnSelectSkin(int index)
    {
        UIManager.instance.SetTexture(AllSkinTexture[index]);
        UIManager.instance.ShowToast("Skin Selected!");
    }
    public void OnSelectCoolSkin(int index)
    {
        UIManager.instance.SetTexture(AllCoolSkinTexture[index]);
        UIManager.instance.ShowToast("Theme Selected!");
    }
}
