using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GenerateEndTapesDynamically : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] tapes;
    public List<GameObject> instantiatedTapes;
    int tapeCount;
    public float sizeY;
    public Transform FirstPos;
    public CinemachineVirtualCamera cvcam;
    public GameObject highestScore;
    public GameObject HighestScorePos;
    private GameObject firstTape;
    public gameOverScript gameOver;
    Transform temp;
    public Transform tmp;
    private bool doneCam=false;

    // Start is called before the first frame update
    void Start()
    {
        doneCam = true;
        highestScore.SetActive(false);
        highestScore.transform.position = HighestScorePos.transform.position;
        sizeY = this.transform.position.y;   
        tapeCount = PlayerPrefs.GetInt("TapeCount");
        InstantiateTapes();
        
    }

    public void InstantiateTapes()
    {
        highestScore.transform.position = new Vector3(highestScore.transform.position.x, highestScore.transform.position.y + (PlayerPrefs.GetInt("highscore") * (-8f)), highestScore.transform.position.z);
        highestScore.SetActive(true);

         //this.transform.rotation= Quaternion.Euler(new Vector3(-20, 0, 0));
        tapeCount = PlayerPrefs.GetInt("TapeCount");
        sizeY = sizeY+((-8 * tapeCount)-6f);
        
        int x = Random.Range(0, 6);
        GameObject gb = Instantiate(tapes[x]);
        gb.transform.position = FirstPos.transform.position;
        foreach(Transform t in gb.transform)
        {
            t.gameObject.SetActive(false);
        }
        gb.SetActive(true);
        
        gb.transform.SetParent(this.transform);
        instantiatedTapes.Add(gb);
        gb.transform.SetParent(gb.transform);
        gb.tag = "FirstTape";
        firstTape = gb;
        //cvcam.Follow = this.transform;
        for (int i=1; i<=tapeCount; i++)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(5, 0, 0)), 5f);
            //cvcam.transform.rotation = Quaternion.Slerp(cvcam.transform.rotation, Quaternion.Euler(new Vector3(5, 180, 0)), 1f);
            int x2 = Random.Range(0,6);
            Transform t = instantiatedTapes[i - 1].transform;
            t.position = new Vector3(t.position.x, t.position.y + 7f, t.position.z);
            GameObject gb2 = Instantiate(tapes[x2]);
            gb2.transform.position = t.transform.position;
            foreach (Transform t1 in gb2.transform)
            {
                t1.gameObject.SetActive(false);
            }
            gb2.SetActive(true);
            gb2.transform.SetParent(this.transform);
            instantiatedTapes.Add(gb2);
        }
        this.GetComponent<Rigidbody>().useGravity = true;
        PlayerPrefs.SetInt("enable", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= sizeY)
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            Player.SetActive(false);
            if (PlayerPrefs.GetInt("Reward")/5 < PlayerPrefs.GetInt("highscore"))
            {
                if (doneCam == true)
                {
                    doneCam = false;
                    temp = this.transform;
                    //this.transform.position = new Vector3(this.transform.position.x, highestScore.transform.position.y, this.transform.position.z);
                    StartCoroutine("delayForHighestScoreCameraMovement");
                }
                
                
                //StartCoroutine("delayForHighestScoreCameraMovement");
                //switchCamera;
            }
            else
            {
                int abc = PlayerPrefs.GetInt("Reward")/5;
                highestScore.transform.position = new Vector3(highestScore.transform.position.x, instantiatedTapes[0].transform.position.y, highestScore.transform.position.z);
                //set highest score panel at this position
                StartCoroutine("delay");
            }
            
            
            //this.transform.position= new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        else
        {
            
        }
    }
    IEnumerator delayForHighestScoreCameraMovement()
    {
        yield return new WaitForSeconds(2f);
        cvcam.Follow = highestScore.transform;
        cvcam.LookAt = null;
        PlayerPrefs.SetInt("enable", 0);
        yield return new WaitForSeconds(3f);
        
        tmp.position = new Vector3(highestScore.transform.position.x, instantiatedTapes[0].transform.position.y, highestScore.transform.position.z);
        tmp.rotation = highestScore.transform.rotation;
        cvcam.Follow = tmp;
        cvcam.LookAt = null;
        yield return new WaitForSeconds(3f);
        StartCoroutine("delay");
        //this.transform.position = new Vector3(this.transform.position.x, temp.transform.position.y, this.transform.position.z);
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        
        

        //cvcam.LookAt = null;
        yield return new WaitForSeconds(1f);
        //cvcam.Follow = this.transform;
        //this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 1f*Time.deltaTime);
        //cvcam.transform.rotation = Quaternion.Slerp(cvcam.transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), 1f);
        //Quaternion.Slerp(cvcam.transform.rotation, Quaternion.Euler( new Vector3(5, 180, 0)),1f);
        yield return new WaitForSeconds(1.3f);
        gameOver.GameWin();
    }
}
