using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalancePlayerState : MonoBehaviour
{

    public Transform right;
    public Transform left;
    private bool rightFilled;
    private bool leftFilled;
    int count = 0;
    public int newTape;
    public GameObject[] tapePrefab;
    public GameObject[] trailPrefab;
    public bool blnc = false;
    public List<GameObject> arrangeTapes;
    public gameOverScript gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NewTapes") == 0)
        {
            PlayerPrefs.SetInt("NewTapes", 6);
        }
        if (PlayerPrefs.GetInt("TotalCoins") < 0)
        {
            PlayerPrefs.SetInt("TotalCoins", 0);

        }
        PlayerPrefs.SetInt("TapeCount", 0);
        foreach (Transform t in this.transform)
        {
            if (t.tag == "Player" && t.gameObject.activeInHierarchy)
            {

                PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount")+1);
            }
        }
        count = PlayerPrefs.GetInt("TapeCount");
    }
    private void OnEnable()
    {
        BalancePlayer();
    }
    public void RightTransformUpdate()
    {
        right.gameObject.transform.position = new Vector3(right.position.x + 0.7f, 2.8f, right.position.z);
        rightFilled = false;
    }
    public void LeftTransformUpdate()
    {
        left.gameObject.transform.position = new Vector3(left.position.x - 0.7f, 2.8f, left.position.z);
        leftFilled = false;
    }
    // Update is called once per frame
    void Update()
    {
        newTape = PlayerPrefs.GetInt("NewTapes");
        count = 0;
        foreach (Transform t in this.transform)
        {
            if (t.tag == "Player" && t.gameObject.activeInHierarchy)
            {

                count = count + 1;
            }
        }
        
        if(count< PlayerPrefs.GetInt("TapeCount"))
        {
            PlayerPrefs.SetInt("TapeCount", count);
            BalancePlayer();


        }
        if (blnc == true)
        {
            BalancePlayer();

        }
    }
    public void ReplaceTape(int index)
    {
        GameObject gbb = tapePrefab[index];
        GameObject gbb2 = trailPrefab[index];
        for(int i=index; i<tapePrefab.Length; i++)
        {
            tapePrefab[i] = tapePrefab[i + 1];
            trailPrefab[i] = trailPrefab[i + 1];
        }
        tapePrefab[tapePrefab.Length] = gbb;
        trailPrefab[trailPrefab.Length] = gbb2;
    }
    public void AddNewTape(int num)
    {
        
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                int rand = Random.Range(0, PlayerPrefs.GetInt("NewTapes"));
                GameObject gb = Instantiate(tapePrefab[rand], this.gameObject.transform);
                //gb.transform.SetParent(this.gameObject.transform);

                GameObject trailgb = Instantiate(trailPrefab[rand], this.gameObject.transform);
                //trailgb.transform.position = gb.transform.position;
                //trailgb.transform.SetParent(this.gameObject.transform);
                gb.GetComponent<hurdleCollider>().trail = trailgb;
                trailgb.GetComponent<trailFollowPlayer>().tape = gb.transform;
                BalancePlayer();
                gb.SetActive(true);
                trailgb.SetActive(true);
                trailgb.GetComponent<TrailRenderer>().enabled = true;
            }
            PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") + num);
        }
    }
    public void AddDesiredTape(int num, int tapeNum)
    {
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                
                GameObject gb = Instantiate(tapePrefab[tapeNum], this.gameObject.transform);
                //gb.transform.SetParent(this.gameObject.transform);

                GameObject trailgb = Instantiate(trailPrefab[tapeNum], this.gameObject.transform);
                //trailgb.transform.position = gb.transform.position;
                //trailgb.transform.SetParent(this.gameObject.transform);
                gb.GetComponent<hurdleCollider>().trail = trailgb;
                trailgb.GetComponent<trailFollowPlayer>().tape = gb.transform;
                BalancePlayer();
                gb.SetActive(true);
                trailgb.SetActive(true);
                trailgb.GetComponent<TrailRenderer>().enabled = true;
                gb.GetComponent<AddTorqueOnEveryTape>().enable = true;
                PlayerPrefs.SetInt("enable", 1);
            }
            PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") + num);
        }
    }
    public void AddTapes(int num)
    {
        
        int compRand = Random.Range(0, 5);
        Animator anim = this.transform.parent.GetComponentInChildren<Animator>();
        if (compRand == 0)
        {
            anim.SetBool("awesome", false);
            anim.SetBool("marvelous", false);
            anim.SetBool("wonderful", false);
            anim.SetBool("secondChance", false);
            anim.SetBool("exciting", false);
            anim.SetBool("great", true);

        }
        else if (compRand == 1)
        {
            anim.SetBool("marvelous", false);
            anim.SetBool("wonderful", false);
            anim.SetBool("secondChance", false);
            anim.SetBool("exciting", false);
            anim.SetBool("great", false);
            anim.SetBool("awesome", true);

        }
        else if (compRand == 2)
        {
            anim.SetBool("wonderful", false);
            anim.SetBool("secondChance", false);
            anim.SetBool("exciting", false);
            anim.SetBool("great", false);
            anim.SetBool("awesome", false);
            anim.SetBool("marvelous", true);

        }
        else if (compRand == 3)
        {
            anim.SetBool("marvelous", false);
            anim.SetBool("secondChance", false);
            anim.SetBool("exciting", false);
            anim.SetBool("great", false);
            anim.SetBool("awesome", false);
            anim.SetBool("wonderful", true);


        }
        else if (compRand == 4)
        {
            anim.SetBool("marvelous", false);
            anim.SetBool("wonderful", false);
            anim.SetBool("secondChance", false);
            anim.SetBool("great", false);
            anim.SetBool("awesome", false);
            anim.SetBool("exciting", true);

        }
        if (num > 0)
        {
            for (int i = 0; i < num; i++)
            {
                int rand = Random.Range(0, PlayerPrefs.GetInt("NewTapes"));
                GameObject gb = Instantiate(tapePrefab[rand], this.gameObject.transform);
                //gb.transform.SetParent(this.gameObject.transform);

                GameObject trailgb = Instantiate(trailPrefab[rand], this.gameObject.transform);
                //trailgb.transform.position = gb.transform.position;
                //trailgb.transform.SetParent(this.gameObject.transform);
                gb.GetComponent<hurdleCollider>().trail = trailgb;
                trailgb.GetComponent<trailFollowPlayer>().tape = gb.transform;
                BalancePlayer();
                gb.SetActive(true);
                trailgb.SetActive(true);
                trailgb.GetComponent<TrailRenderer>().enabled = true;
                gb.GetComponent<AddTorqueOnEveryTape>().enable = true;
                PlayerPrefs.SetInt("enable", 1);
            }
            PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") + num);
        }
        
        
    }
    public void SubTapes(int num)
    {
        Animator anim = this.transform.parent.GetComponentInChildren<Animator>();
        List<GameObject> tape = new List<GameObject>();
        List<GameObject> trail = new List<GameObject>();
        foreach (Transform t in this.transform)
        {
            if (t.tag == "Player")
            {

                tape.Add(t.gameObject);
            }
            else if (t.tag == "Trail")
            {
                trail.Add(t.gameObject);
            }
        }
        if (num >= tape.Count)
        {
            for (int i = 0; i <=tape.Count; i++)
            {
                
                Destroy(tape[i].gameObject);
                Destroy(trail[i].gameObject);
            }
            anim.SetBool("marvelous", false);
            anim.SetBool("wonderful", false);
            anim.SetBool("great", false);
            anim.SetBool("awesome", false);
            anim.SetBool("exciting", false);
            anim.SetBool("secondChance", true);
            gameOver.GameOver();
        }
        else
        {

            for (int i = 1; i <= tape.Count; i++)
            {
                if (i >= tape.Count-num)
                {
                    
                    Destroy(tape[i].gameObject);
                    Destroy(trail[i].gameObject);
                    arrangeTapes.Remove(tape[i].gameObject);
                    BalancePlayer();

                }
            }
            PlayerPrefs.SetInt("TapeCount", PlayerPrefs.GetInt("TapeCount") - num);

            BalancePlayer();
        }
        if (PlayerPrefs.GetInt("TapeCount") == 0)
        {
            gameOver.GameOver();
        }
        
        
    }
    public void BalancePlayer()
    {
        arrangeTapes = new List<GameObject>();
        foreach (Transform t in this.transform)
        {
            if (t.tag == "Player" && t.gameObject.activeInHierarchy)
            {
                
                arrangeTapes.Add(t.gameObject);
            }
            else if (t.tag == "Trail" && t.gameObject.activeInHierarchy)
            {
                //t.gameObject.GetComponent<TrailRenderer>().emitting = false;
            }
            
        }
        for(int i=0; i<arrangeTapes.Count; i++)
        {
            GameObject gb = arrangeTapes[i].transform.parent.gameObject;
            if (i < 10)
            {
               // arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i].transform.position.x, 2.32f, arrangeTapes[i].transform.position.z);
                
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.GetComponent<trailFollowPlayer>().enabled = true;
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.SetActive(true);
                if (i == 0)
                {
                    //gb.transform.position = new Vector3(0f, gb.transform.position.y, gb.transform.position.z);
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x, arrangeTapes[i].transform.position.y, gb.transform.position.z);
                }
                else if (i == 1)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z);
                }
                else if (i == 2)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z);
                }
                else if (i % 2 != 0 && i != 1)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z);
                }
                else if (i % 2 == 0 && i != 0 && i != 2)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z);
                }

            }
            else if(i>=10 && i < 20)
            {
                //arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i].transform.position.x, 2.32f, arrangeTapes[i].transform.position.z);
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.GetComponent<trailFollowPlayer>().enabled = false;
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.SetActive(false);
                
                if (i == 10)
                {
                    //gb.transform.position = new Vector3(0f, gb.transform.position.y, gb.transform.position.z);
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x, arrangeTapes[i].transform.position.y, gb.transform.position.z+3.3f);
                }
                else if (i == 11)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z+3.3f);
                }
                else if (i == 12)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z+3.3f);
                }
                else if (i % 2 != 0 && i != 11)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z+3.3f);
                }
                else if (i % 2 == 0 && i != 10 && i != 12)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z+3.3f);
                }

            }
            else if (i >= 20 && i < 30)
            {
                //arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i].transform.position.x, 2.32f, arrangeTapes[i].transform.position.z);
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.GetComponent<trailFollowPlayer>().enabled = false;
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.SetActive(false);
                
                if (i == 20)
                {
                    //gb.transform.position = new Vector3(0f, gb.transform.position.y, gb.transform.position.z);
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x, arrangeTapes[i].transform.position.y, gb.transform.position.z + 6.6f);
                }
                else if (i == 21)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 6.6f);
                }
                else if (i == 22)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 6.6f);
                }
                else if (i % 2 != 0 && i != 21)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 6.6f);
                }
                else if (i % 2 == 0 && i != 20 && i != 22)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 6.6f);
                }

            }
            else if (i >= 30 && i < 40)
            {
                //arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i].transform.position.x, 2.32f, arrangeTapes[i].transform.position.z);
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.GetComponent<trailFollowPlayer>().enabled = false;
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.SetActive(false);
                
                if (i == 30)
                {
                    //gb.transform.position = new Vector3(0f, gb.transform.position.y, gb.transform.position.z);
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x, arrangeTapes[i].transform.position.y, gb.transform.position.z + 9.9f);
                }
                else if (i == 31)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 9.9f);
                }
                else if (i == 32)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 9.9f);
                }
                else if (i % 2 != 0 && i != 31)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 9.9f);
                }
                else if (i % 2 == 0 && i != 30 && i != 32)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 9.9f);
                }

            }
            else if (i >= 40 && i < 50)
            {
                //arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i].transform.position.x, 2.32f, arrangeTapes[i].transform.position.z);
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.GetComponent<trailFollowPlayer>().enabled = false;
                arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject.SetActive(false);
                
                if (i == 40)
                {
                    //gb.transform.position = new Vector3(0f, gb.transform.position.y, gb.transform.position.z);
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x, arrangeTapes[i].transform.position.y, gb.transform.position.z + 12.2f);
                }
                else if (i == 41)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 12.2f);
                }
                else if (i == 42)
                {
                    arrangeTapes[i].transform.position = new Vector3(gb.transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 12.2f);
                }
                else if (i % 2 != 0 && i != 41)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x + 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 12.2f);
                }
                else if (i % 2 == 0 && i != 40 && i != 42)
                {
                    arrangeTapes[i].transform.position = new Vector3(arrangeTapes[i - 2].transform.position.x - 0.67f, arrangeTapes[i].transform.position.y, gb.transform.position.z + 12.2f);
                }

            }
            else
            {
                Destroy(arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject);
                Destroy(arrangeTapes[i].gameObject);
            }

        }

        foreach (Transform t in this.transform)
        {
            if (t.tag == "Trail")
            {
                t.gameObject.GetComponent<TrailRenderer>().emitting = true;
            }
        }
        //if (arrangeTapes.Count % 2 == 0)
        //{
        //    right.gameObject.transform.position = new Vector3(arrangeTapes[arrangeTapes.Count - 1].transform.position.x + 0.6f, arrangeTapes[arrangeTapes.Count - 1].transform.position.y, arrangeTapes[arrangeTapes.Count - 1].transform.position.z);
        //    left.gameObject.transform.position = new Vector3(arrangeTapes[arrangeTapes.Count - 2].transform.position.x - 0.6f, arrangeTapes[arrangeTapes.Count - 2].transform.position.y, arrangeTapes[arrangeTapes.Count - 2].transform.position.z);
        //}
        //else
        //{
        //    left.gameObject.transform.position = new Vector3(arrangeTapes[arrangeTapes.Count - 1].transform.position.x - 0.6f, arrangeTapes[arrangeTapes.Count - 1].transform.position.y, arrangeTapes[arrangeTapes.Count - 1].transform.position.z);
        //    right.gameObject.transform.position = new Vector3(arrangeTapes[arrangeTapes.Count - 2].transform.position.x + 0.6f, arrangeTapes[arrangeTapes.Count - 2].transform.position.y, arrangeTapes[arrangeTapes.Count - 2].transform.position.z);
        //}
    }
}
