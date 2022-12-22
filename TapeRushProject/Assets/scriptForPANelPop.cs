using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptForPANelPop : MonoBehaviour
{
    public GameObject PanelForEasyHard;
    private static int check1stTime = 0;

    // Start is called before the first frame update

    void Start()
    {
        //  if (!PlayerPrefs.HasKey("num"))
        // {
        //     PlayerPrefs.SetInt("num",1);


        // }
        checkPlayerPref();



    }

    // Update is called once per frame
    void Update()
    {

        // checkPlayerPref();
    }
    void checkPlayerPref()
    {
        // if(PlayerPrefs.GetInt("num")==1){

        // PanelForEasyHard.SetActive(true);
        // PlayerPrefs.SetInt("num",2);
        // Debug.Log(PlayerPrefs.GetInt("num")+"fffffffffffff");
        // }
        if (check1stTime == 0)
        {
            PanelForEasyHard.SetActive(true);
            check1stTime++;
        }
    }
}
