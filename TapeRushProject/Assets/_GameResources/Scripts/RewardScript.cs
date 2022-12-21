using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RewardScript : MonoBehaviour
{
    public coinsAnimation coinAnim;
    public GameObject itemParent;
    int TurnCount;
    
    public List<Transform> allChildren;
    void Start()
    {
    }
    private void OnEnable()
    {
        Debug.Log(itemParent.transform.childCount);
        RefreshPanel();
    }

    void RefreshPanel()
    {
        allChildren = new List<Transform>();
        foreach (Transform child in itemParent.transform)
        {
            allChildren.Add(child);
        }
        foreach (Transform child in allChildren)
        {
            child.GetChild(0).gameObject.SetActive(true);
            child.GetChild(1).gameObject.SetActive(false);
        }
        TurnCount = 3;
    }
    public void OnItemClick(int index)
    {
        coinAnim.gameObject.transform.position = allChildren[index].transform.position;
        coinAnim.AnimateCoins();
        if (TurnCount<1) { return; }
        TurnCount--;
        //Get Cash Only
        if (TurnCount > 1)
        {
            int r = Random.Range(4, 21);
            allChildren[index].GetChild(0).gameObject.SetActive(false);
            allChildren[index].GetChild(1).gameObject.SetActive(true);
            allChildren[index].GetComponentInChildren<Text>().text = (r * 5).ToString();
            UIManager.instance.RefreshCash(r * 5);
        }
        //Get Cash or Skin
        else
        {
            int cash = Random.Range(0, 2);
            //Give Cash
            if (cash == 1)
            {
                int r = Random.Range(4, 21);
                allChildren[index].GetChild(0).gameObject.SetActive(false);
                allChildren[index].GetChild(1).gameObject.SetActive(true);
                allChildren[index].GetComponentInChildren<Text>().text = (r * 5).ToString();
                UIManager.instance.RefreshCash(r * 5);
            }
            //Give Skin
            else
            {
                UIManager.instance.NewSkinOpen();
            }
        }
        PlayerPrefs.GetInt("key",TurnCount);
        if (TurnCount <= 0)
        {
            StartCoroutine("delay");
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.4f);
        UIManager.instance.PanelAnimation();

    }

}
