using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsScript : MonoBehaviour
{
    public static settingsScript instance;
    public GameObject[] modes;
    public GameObject player;
    public SwipeDetecter sd;
    public GameObject innerplayer, settingMapParent, mapParent;
    public int mapNum = 0;
    float sped = 50;
    // Start is called before the first frame update
    public void Start()
    {
        if (instance == null)
        { instance = this; }

        if (!PlayerPrefs.HasKey("mapNum"))
        {
            PlayerPrefs.SetInt("mapNum", 0);
        };
        mapNum = PlayerPrefs.GetInt("mapNum");
        int mode = PlayerPrefs.GetInt("mode", 1);
        DisableMap();
        settingMapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        mapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        foreach (GameObject gb in modes)
        {
            gb.SetActive(false);
        }
        modes[mode - 1].SetActive(true);
        sped = player.GetComponent<PathFollower>().speed1;

        if (mode == 1)
        {
            EasySetting();
        }
        else if (mode == 2)
        {
            MediumSetting();
        }
        else if (mode == 3)
        {
            HardSetting();
        }
    }
    public void EasySetting()
    {

        player.GetComponent<PathFollower>().speed1 = sped + 0;
        SetEveryTapeRotation(-5f);
        PlayerPrefs.SetInt("mode", 1);
    }
    public void MediumSetting()
    {
        player.GetComponent<PathFollower>().speed1 = sped + 15;
        SetEveryTapeRotation(-8f);
        PlayerPrefs.SetInt("mode", 2);
    }
    public void HardSetting()
    {
        player.GetComponent<PathFollower>().speed1 = sped + 25;
        SetEveryTapeRotation(-13f);
        PlayerPrefs.SetInt("mode", 3);
    }
    private int returnIndex()
    {
        if (modes[0].activeInHierarchy)
        {
            return 0;
        }
        else if (modes[1].activeInHierarchy)
        {
            return 1;
        }
        else if (modes[2].activeInHierarchy)
        {
            return 2;

        }
        return -1;
    }
    public void nextPressed()
    {
        int index = returnIndex();
        modes[index].SetActive(false);
        modes[(index + 1) % 3].SetActive(true);
        if ((index + 1) % 3 == 0)
        {
            EasySetting();
        }
        else if ((index + 1) % 3 == 1)
        {
            MediumSetting();
        }
        else if ((index + 1) % 3 == 2)
        {
            HardSetting();
        }
    }
    public void prevPressed()
    {
        int index = returnIndex();
        modes[index].SetActive(false);
        if (index == 0)
        {
            index = 3;
        }
        modes[(index - 1) % 3].SetActive(true);
        if ((index - 1) % 3 == 0)
        {
            EasySetting();
        }
        else if ((index - 1) % 3 == 1)
        {
            MediumSetting();
        }
        else if ((index - 1) % 3 == 2)
        {
            HardSetting();
        }
    }


    public void SetEveryTapeRotation(float rotSpeed)
    {
        foreach (Transform t in innerplayer.gameObject.transform)
        {
            if (t.tag == "Player")
            {

                t.gameObject.GetComponent<AddTorqueOnEveryTape>().tapeSpeed = rotSpeed;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    // changing map in Settings
    public void NextMap()
    {
        DisableMap();
        mapNum++;
        if (mapNum >= settingMapParent.transform.childCount)
        {
            mapNum = settingMapParent.transform.childCount - 1;
        }
        settingMapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        mapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        PlayerPrefs.SetInt("mapNum", mapNum);
    }

    public void PreviousMap()
    {
        DisableMap();
        mapNum--;
        if (mapNum < 0)
        {
            mapNum = 0;
        }
        settingMapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        mapParent.transform.GetChild(mapNum).gameObject.SetActive(true);
        PlayerPrefs.SetInt("mapNum", mapNum);
    }
    private void DisableMap()
    {
        for (int i = 0; i < settingMapParent.transform.childCount; i++)
        {
            settingMapParent.transform.GetChild(i).gameObject.SetActive(false);
            mapParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
