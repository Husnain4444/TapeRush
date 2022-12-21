using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class OtherPencilsToCombineZigZag : MonoBehaviour
{
    private int count ;
    public bool right;
    public bool left ;
    public BalancePlayerState ChooseTransform;
    public GameObject trail;
    public HapticTypes hapticType = HapticTypes.LightImpact;
    public float intensity = 0.001f;
    public float sharpness = 0.001f;
    private void Awake()
    {
        PlayerPrefs.SetInt("count", 0);
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
            transform.SetParent(ChooseTransform.gameObject.transform);
            trail.transform.SetParent(ChooseTransform.gameObject.transform);
            //MMVibrationManager.Vibrate();
            MMVibrationManager.Haptic(hapticType, false, true);
            this.gameObject.GetComponent<AddTorqueOnEveryTape>().enable = true;
            if ( right==true)
            {
                //GameObject gb = transform.parent.gameObject;

                
                //transform.position = new Vector3(transform.position.x, 2.23f, transform.position.z);
                //transform.rotation = Quaternion.Euler(90f, 0f, 90f);
                StartCoroutine("delayRight");
                //MMVibrationManager.TransientHaptic(intensity, sharpness);
               
                //transform.position = ChooseTransform.right.position;

                //rightside
            }
            else if( left == true)
            {
                //GameObject gb = transform.parent.gameObject;
               transform.position = ChooseTransform.left.position;
                transform.position = new Vector3(transform.position.x, 2.23f, transform.position.z);
                //transform.rotation = Quaternion.Euler(90f, 0f, 90f);
                //MMVibrationManager.TransientHaptic(intensity, sharpness);
                //MMVibrationManager.ContinuousHaptic(intensity, sharpness, 0.01f);
                //MMVibrationManager.Haptic(hapticType, false, true);
                StartCoroutine("delayLeft");
                
            }
        }
    }

    IEnumerator delayRight()
    {

        yield return new WaitForSeconds(0.08f);
        transform.SetParent(ChooseTransform.gameObject.transform);
        trail.transform.SetParent(ChooseTransform.gameObject.transform);
        transform.position = Vector3.Lerp(transform.position, ChooseTransform.right.position, 0.05f);
        transform.rotation = ChooseTransform.right.rotation;
        
        this.GetComponent<MeshCollider>().isTrigger = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<hurdleCollider>().enabled = true;
        this.gameObject.tag = "Player";
        //GameObject gb= ChooseTransform.gameObject.transform.GetChild(2).gameObject;
        
        ChooseTransform.RightTransformUpdate();
        
        ChooseTransform.BalancePlayer();
        transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
        transform.rotation = Quaternion.Euler(24f, 0f, 90f);
        yield return new WaitForSeconds(2f);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") + 1);

    }
    IEnumerator delayLeft()
    {

        yield return new WaitForSeconds(0.08f);
        transform.SetParent(ChooseTransform.gameObject.transform);
        trail.transform.SetParent(ChooseTransform.gameObject.transform);
        transform.position = Vector3.Lerp(transform.position, ChooseTransform.left.position, 0.05f);
        transform.rotation = ChooseTransform.left.rotation;
        
        this.GetComponent<MeshCollider>().isTrigger = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<hurdleCollider>().enabled = true;
        this.gameObject.tag = "Player";

        //GameObject gb = ChooseTransform.gameObject.transform.GetChild(2).gameObject;
        
        ChooseTransform.LeftTransformUpdate();
        
        ChooseTransform.BalancePlayer();
        transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
        transform.rotation = Quaternion.Euler(24f, 0f, 90f);
        yield return new WaitForSeconds(2f);
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") + 1);

        //leftside
        PlayerPrefs.SetInt("count", 0);
        left = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
