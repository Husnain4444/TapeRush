using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callBalanceScript : MonoBehaviour
{
    public BalancePlayerState bps;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("delay");
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        bps.BalancePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
