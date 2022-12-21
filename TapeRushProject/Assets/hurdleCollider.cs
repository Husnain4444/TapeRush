using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurdleCollider : MonoBehaviour
{
    public GameObject trail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hurdle")
        {
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //GameObject gb = this.transform.parent.gameObject;
            //gb.transform.parent = null;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
            //this.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
            StartCoroutine("delay");
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(trail.gameObject);
        Destroy(this.transform.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
