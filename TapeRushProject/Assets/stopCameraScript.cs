using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class stopCameraScript : MonoBehaviour
{
    
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    // Start is called before the first frame update
    private void Awake()
    {
        cam2.Priority = 10;
    }
    void Start()
    {
        cam2.Priority = 10;
    }
    private void OnEnable()
    {
        cam2.Priority = 10;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SmashHurdle")
        {
            cam2.Priority = 20;
            StartCoroutine("delay");
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        cam2.Priority = 10;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
