using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTapePosDynamically : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] tapes;
    public CreateHurdlesDynamically chd;
    // Start is called before the first frame update
    void Start()
    {
        SetTapePos();
    }
    private void OnEnable()
    {
        
    }
    public void SetTapePos()
    {
        
        for (int i = 0; i <tapes.Length; i++)
        {
            float x = Random.Range(-5f, 5f);
            float z;
            if (i < tapes.Length / 2)
            {
                z = Random.Range(-1000f, 200f);
            }
            else
            {
                z = Random.Range(200f, 1200f);
            }
            
            if (tapes[i].transform.parent == Player.transform)
            {
                tapes[i].transform.position = new Vector3(tapes[i].transform.position.x, 2.14f, tapes[i].transform.position.z);
            }
            else
            {
                tapes[i].transform.position = new Vector3(x, 1.08f, z);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
