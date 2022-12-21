using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;


public class removeParentScript : MonoBehaviour
{
    public gameOverScript go;
    public GameObject player;
    public HapticTypes hapticType = HapticTypes.MediumImpact;
    public float intensity = 0.4f;
    public float sharpness = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        MMVibrationManager.SetHapticsActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        hurdleCollider hc = other.gameObject.GetComponent<hurdleCollider>();

        if (other.tag == "Player")
        {
            int count = 0;
            MMVibrationManager.TransientHaptic(intensity, sharpness);
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            
            hc.trail.transform.parent = null;
            other.gameObject.transform.parent = null;
            foreach (Transform t in player.transform)
            {
                if (t.tag == "Player")
                {
                    count = count + 1;
                }
            }
            if (count == 0)
            {
                go.GameOver();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
