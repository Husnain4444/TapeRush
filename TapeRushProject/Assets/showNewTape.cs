using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showNewTape : MonoBehaviour
{
    public Image showTapePattern;
    public List<Sprite> TapePatterns;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NewTapes") <= 11)
        {
            showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];

        }
        else
        {
            PlayerPrefs.SetInt("NewTapes", 11);
        }
        //if (PlayerPrefs.GetInt("NewTapes") == 7)
        //{
        //    showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];
        //}
        //if (PlayerPrefs.GetInt("NewTapes") == 8)
        //{
        //    showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];
        //}
        //if (PlayerPrefs.GetInt("NewTapes") == 9)
        //{
        //    showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];
        //}
        //if (PlayerPrefs.GetInt("NewTapes") == 10)
        //{
        //    showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];
        //}
        //if (PlayerPrefs.GetInt("NewTapes") == 11)
        //{
        //    showTapePattern.sprite = TapePatterns[(PlayerPrefs.GetInt("NewTapes") - 6)];
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
