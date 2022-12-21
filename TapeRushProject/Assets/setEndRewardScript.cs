using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setEndRewardScript : MonoBehaviour
{
    int hs;
    // Start is called before the first frame update
    void Start()
    {

        hs= PlayerPrefs.GetInt("highscore", 0);
        PlayerPrefs.SetInt("Reward", 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FirstTape")
        {
            foreach(Transform ps in this.transform)
            {
                if (ps.GetComponent<ParticleSystem>())
                {
                    ps.GetComponent<ParticleSystem>().Play();
                }
                
            }
            int i=int.Parse(this.GetComponentInChildren<TextMeshPro>().text);
            PlayerPrefs.SetInt("Reward", i);
            int hs= PlayerPrefs.GetInt("highscore");
            if (hs < i / 5)
            {
                PlayerPrefs.SetInt("highscore", i / 5);
            }
            
            //PlayerPrefs.SetInt("highscore", i/5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
