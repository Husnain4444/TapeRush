using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        hurdleCollider hc = other.gameObject.GetComponent<hurdleCollider>();

        if (other.tag == "Player")
        {
            Destroy(hc.trail.gameObject);
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
