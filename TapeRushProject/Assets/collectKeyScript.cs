using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectKeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("KeyConsumed") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetInt("KeyConsumed") == 0)
        {
            PlayerPrefs.SetInt("key", PlayerPrefs.GetInt("key") + 1);
            PlayerPrefs.SetInt("KeyConsumed", 1);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
