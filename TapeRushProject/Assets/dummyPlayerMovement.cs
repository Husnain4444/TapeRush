using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyPlayerMovement : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y-2f, transform.position.z);
    }
}
