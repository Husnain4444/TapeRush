using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailFollowPlayer : MonoBehaviour
{
    public Transform tape;
    public float size;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TrailRenderer>().enabled = false;
        //size = 0.09f;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = tape.position + offset;
        Vector3 smoothPositiion = Vector3.Lerp(transform.position, desiredPosition, 0.1f);
        transform.position = smoothPositiion;
        transform.rotation = tape.rotation;

        this.gameObject.GetComponent<TrailRenderer>().enabled = true;
        //Vector3 targetPos = new Vector3(player.position.x, player.position.y, player.position.z-10f);
        //ts.position = new Vector3(player.transform.position.x, player.transform.position.y+6f, player.transform.position.z-size);
        //Vector3.Lerp(transform.position, ts.position, 0.04f);
        //transform.LookAt(tape);
        if (!tape.gameObject.activeSelf)
        {
            Destroy(this.gameObject);
        }
    }

}
