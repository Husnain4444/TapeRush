using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeTapes : MonoBehaviour
{
    public BalancePlayerState bps;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            bps.BalancePlayer();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
