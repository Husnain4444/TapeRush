using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;
public class zigzagPathTapeCombine : MonoBehaviour
{
    public int TapeNumber;
    public BalancePlayerState ChooseTransform;
    public GameObject trail;
    public HapticTypes hapticType = HapticTypes.LightImpact;
    public float intensity = 0.001f;
    public float sharpness = 0.001f;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        MMVibrationManager.SetHapticsActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            MMVibrationManager.Haptic(hapticType, false, true);
            this.gameObject.GetComponent<AddTorqueOnEveryTape>().enable = true;
            ChooseTransform.AddDesiredTape(1, TapeNumber);
            ChooseTransform.BalancePlayer();
            this.gameObject.SetActive(false);
        }
    }

}
