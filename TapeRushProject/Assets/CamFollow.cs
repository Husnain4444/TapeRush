using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float size;
    private Transform ts;
    public  Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //size = 0.09f;
        ts = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPositiion= Vector3.Lerp(transform.position,desiredPosition, 0.04f);
        transform.position = smoothPositiion;
        //Vector3 targetPos = new Vector3(player.position.x, player.position.y, player.position.z-10f);
        //ts.position = new Vector3(player.transform.position.x, player.transform.position.y+6f, player.transform.position.z-size);
        //Vector3.Lerp(transform.position, ts.position, 0.04f);
        transform.LookAt(player);

    }
    
}
