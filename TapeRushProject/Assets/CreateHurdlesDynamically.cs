using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHurdlesDynamically : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] hurdlePrefabs;
    public GameObject[] doubleHurdlePrefabs;
    public GameObject[] tapes;
    public List<GameObject> hurdles;
    public List<GameObject> hurdles2;
    private List<Transform> tapeTransform;
    private List<Transform> hurdlesTransform;
    private List<Transform> doubleHurdlesTransform;
    public Transform obs1, obs2, obs3,obs4,obs5;
    
    public int NoOfHurdles;
    // Start is called before the first frame update
    void Start()
    {
        hurdlesTransform = new List<Transform>();
        doubleHurdlesTransform = new List<Transform>();
        InstantiateHurdles(NoOfHurdles);
        SetHurdlePos();
        SetTapePos();
    }

    void InstantiateHurdles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, 4);
            GameObject gb = Instantiate(hurdlePrefabs[rand]);
            
            gb.SetActive(true);
            hurdles.Add(gb);

        }
        for (int i = 0; i < 4; i++)
        {
            int rand2 = Random.Range(0, 6);
            GameObject gb2 = Instantiate(doubleHurdlePrefabs[rand2]);
            gb2.SetActive(true);
            hurdles2.Add(gb2);
        }

    }
    public void SetHurdlePos()
    {
        for(int i=0; i<hurdles.Count; i++)
        {
            int x;
            int rnd = Random.Range(1, 3);
            if (rnd == 1)
            {
                x = 4;
            }
            else
            {
                x = -4;
            }
            label:
            float z;
            if (i < hurdles.Count / 2)
            {
                z = Random.Range(-1100f, -800f);
            }
            else
            {
                z = Random.Range(1000f, 1200f);
            }

            if (hurdlesTransform.Count > 0)
            {
                foreach(Transform t in hurdlesTransform)
                {
                    if(Vector3.Distance(new Vector3(x, 2.64f, z), t.position) < 50|| Vector3.Distance(new Vector3(x, 2.64f, z), obs1.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs2.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs3.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs4.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs5.position) < 50)
                    {
                        goto label;
                    }
                }
            }
            hurdles[i].transform.position = new Vector3(x, 2.64f, z);
            hurdlesTransform.Add(hurdles[i].transform);
        }
        for(int i=0; i<hurdles2.Count; i++)
        {
            int x = 0;
            label2:
            float z;
            if (i < hurdles.Count / 2)
            {
                z = Random.Range(-800f, 0f);
            }
            else
            {
                z = Random.Range(0f, 1000f);
            }
            if (doubleHurdlesTransform.Count > 0)
            {
                foreach (Transform t in doubleHurdlesTransform)
                {
                    if (Vector3.Distance(new Vector3(x, 2.64f, z), t.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs1.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs2.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs3.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs4.position) < 50 || Vector3.Distance(new Vector3(x, 2.64f, z), obs5.position) < 50)
                    {
                        goto label2;
                    }
                }
            }
            hurdles2[i].transform.position = new Vector3(x, 0.13f, z);
            doubleHurdlesTransform.Add(hurdles2[i].transform);
        }
        
    }

    public void SetTapePos()
    {

        for (int i = 0; i < tapes.Length; i++)
        {
            float x = Random.Range(-5f, 5f);
            label3:
            float z;
            if (i < tapes.Length / 2)
            {
                z = Random.Range(-1200f, 200f);
            }
            else
            {
                z = Random.Range(200f, 1200f);
            }
            if (doubleHurdlesTransform.Count > 0)
            {
                foreach (Transform t in doubleHurdlesTransform)
                {
                    if (Vector3.Distance(new Vector3(x, 2.64f, z), t.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs1.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs2.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs3.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs4.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs5.position) < 40)
                    {
                        goto label3;
                    }
                }
            }
            if (hurdlesTransform.Count > 0)
            {
                foreach (Transform t in hurdlesTransform)
                {
                    if (Vector3.Distance(new Vector3(x, 2.64f, z), t.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs1.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs2.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs3.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs4.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs5.position) < 40)
                    {
                        goto label3;
                    }
                }
            }
            if (tapeTransform.Count > 0)
            {
                foreach (Transform t in tapeTransform)
                {
                    if (Vector3.Distance(new Vector3(x, 2.64f, z), t.position) < 100 || Vector3.Distance(new Vector3(x, 2.64f, z), obs1.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs2.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs3.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs4.position) < 40 || Vector3.Distance(new Vector3(x, 2.64f, z), obs5.position) < 40)
                    {
                        goto label3;
                    }
                }
            }
            if (tapes[i].transform.parent == Player.transform)
            {
                tapes[i].transform.position = new Vector3(tapes[i].transform.position.x, 2.14f, tapes[i].transform.position.z);
            }
            else
            {
                tapes[i].transform.position = new Vector3(x, 1.08f, z);
                tapeTransform.Add(tapes[i].transform);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
