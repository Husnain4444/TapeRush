using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MoreMountains.NiceVibrations;
public class newHurdleCollider : MonoBehaviour
{
    public HapticTypes hapticType = HapticTypes.HeavyImpact;
    public float intensity = 1f;
    public float sharpness = 1f;
    private string text;
    public TextMeshPro tmp;
    public char sign;
    public bool div;
    public bool mul;
    public int num;
    public int mulNum;
    public int sumNum;
    public GameObject bps;
    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(1, 5);
        mulNum = Random.Range(1, 3);
        sumNum = Random.Range(1, 5);
        string tt;
        if (div == true)
        {
            tt = $"{sign} {sumNum}";
        }
        else if (mul == true)
        {
            tt = $"{sign} {mulNum}";
        }
        else
        {
            tt = $"{sign} {num}";

        }
        tmp.text = tt;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SmashHurdle")
        {
            MMVibrationManager.TransientHaptic(intensity, sharpness);
            //MMVibrationManager.Haptic(hapticType, false, true);
            this.GetComponentInChildren<Transform>().gameObject.SetActive(false);
            if (sign == '+')
            {
                bps.GetComponent<BalancePlayerState>().AddTapes(sumNum);
            }
            if (sign == '-')
            {
                bps.GetComponent<BalancePlayerState>().SubTapes(num);
            }
            if (sign == '*')
            {
                int tapecount = PlayerPrefs.GetInt("TapeCount");
                mulNum = (tapecount * mulNum) - tapecount;
                bps.GetComponent<BalancePlayerState>().AddTapes(mulNum);
            }
            if (sign == '/')
            {
                int tapecount = PlayerPrefs.GetInt("TapeCount");
                num = tapecount - (tapecount / num);
                bps.GetComponent<BalancePlayerState>().SubTapes(num);
            }
            this.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
