using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class finishLineScript : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public GameObject player;
    public GameObject innerPlayer;
    public GameObject swipeScript;
    public gameOverScript gb;
    public GameObject endTapes;

    // Start is called before the first frame update
    private void Awake()
    {
        cam1.Priority = 9;
        cam2.Priority = 5;
    }
    void Start()
    {
        cam1.Priority = 9;
        cam2.Priority = 5;
    }
    private void OnEnable()
    {
        cam1.Priority = 9;
        cam2.Priority = 5;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("enable", 0);
            swipeScript.SetActive(false);
            
            innerPlayer.GetComponent<Rigidbody>().isKinematic = true;
            innerPlayer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            innerPlayer.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.GetComponent<PathFollower>().enabled = false;
            StartCoroutine("delay");
            //player.transform.position = new Vector3(0f, player.transform.position.y, player.transform.position.z);
            //gb.GameWin();
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        cam1.Priority = 21;
        yield return new WaitForSeconds(0.8f);
        //cam2.transform.rotation = Quaternion.Euler( new Vector3(20f, 180,0));
        cam1.Priority = 5;
        cam2.Priority = 22;
        yield return new WaitForSeconds(2f);
        endTapes.GetComponent<GenerateEndTapesDynamically>().enabled = true;
        //yield return new WaitForSeconds(1f);
        //cam2.transform.rotation = Quaternion.Euler(new Vector3(0, 180,0));
        //player.transform.position = finishTransform.transform.position;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
