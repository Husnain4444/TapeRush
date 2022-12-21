using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDownCollider : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Rigidbody>().drag = 10;
            player.GetComponent<Rigidbody>().velocity = Vector3.one;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
