using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followFirstTape : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="endTapes" || other.tag == "FirstTape")
        {
            foreach (Transform t in other.transform)
            {
                t.gameObject.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       // this.transform.position = new Vector3(transform.position.x, Target.transform.position.y, transform.position.z);
    }
}
