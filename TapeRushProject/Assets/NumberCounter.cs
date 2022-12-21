using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NumberCounter : MonoBehaviour
{
    public Text text;
    public Text HomeText;
    public int countFPS;
    public float Duration;
    private int _value;
    public Text rewardText;
    private Coroutine CountingCoroutine;
    public int Value
    {
        set
        {
            UpdateText(value);
            _value = value;
        }
        get
        {
            return _value;
        }
    }

    private void UpdateText(int newValue)
    {
        if (CountingCoroutine != null)
        {
            StopCoroutine(CountingCoroutine);

        }
        CountingCoroutine = StartCoroutine(CountText(newValue));
    }

    private IEnumerator CountText(int newValue)
    {
        Debug.Log(newValue);
        WaitForSeconds wait = new WaitForSeconds(1f / countFPS);
        int previousValue = PlayerPrefs.GetInt("TotalCoins");
        Debug.Log(previousValue);
        int stepAmount;
        if (newValue - previousValue < 0)
        {
            stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * Duration));
        }
        else
        {
            stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * Duration));
        }
        if (previousValue < newValue)
        {
            while (previousValue < newValue)
            {
                previousValue += stepAmount;
                if (previousValue > newValue)
                {
                    previousValue = newValue;
                }
                text.text = previousValue.ToString();
                HomeText.text= previousValue.ToString();
                PlayerPrefs.SetInt("TotalCoins", previousValue);
                yield return wait;
            }
        }
        else
        {
            while (previousValue > newValue)
            {
                previousValue += stepAmount;
                if (previousValue < newValue)
                {
                    previousValue = newValue;
                }
                text.text = previousValue.ToString();
                HomeText.text = previousValue.ToString();
                PlayerPrefs.SetInt("TotalCoins", previousValue);
                yield return wait;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
