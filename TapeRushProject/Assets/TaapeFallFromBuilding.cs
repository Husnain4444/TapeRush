using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaapeFallFromBuilding : MonoBehaviour
{
    public float size = 0f;
    // Start is called before the first frame update
    void Start()
    {
        size = (-3 * PlayerPrefs.GetInt("TapeCount"))+9f;
    }
    private void OnEnable()
    {
        //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //this.GetComponent<Rigidbody>().AddForce(0f, 0f, 13f);
        //this.GetComponent<Rigidbody>().useGravity = true;
    }
    // Update is called once per frame
    void Update()
    {

        size = this.transform.parent.gameObject.GetComponent<TapeFallScripts>().sizeY;
        if (transform.position.y <= size)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
