using System.Collections;
using UnityEngine;


public class SwipeDetecter : MonoBehaviour
{
    public GameObject dragImage, SecondChanceStartPanel;

    public GameObject gameplay;
    private Vector3 fingerDown;
    private Vector3 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    private Vector3 dragOffset;
    public float SWIPE_THRESHOLD = 20f;
    public GameObject player;
    public GameObject rb;
    private Camera cam;
    private Vector3 moveVelocity;
    public float speed = 11f;
    float lastSpeed;
    private bool enablePlayerMovement;
    bool isGameStart;
    // Start is called before the first frame update
    void Start()
    {
        enablePlayerMovement = false;
        //  dragImage.SetActive(true);s
        cam = Camera.main;
    }
    private void OnMouseDown()
    {

    }

    public void Awake()
    {
        if (UIManager.secondChance)
        {

            //player.transform.position = new Vector3(0, rb.gameObject.GetComponent<Transform>().position.y, PlayerPrefs.GetFloat("PlayerZ"));
            SecondChanceStartPanel.SetActive(true);
            dragImage.SetActive(false);
        }
        else
        {
            SecondChanceStartPanel.SetActive(false);
            dragImage.SetActive(true);
        }
    }
    public void SetEveryTapeRotation(float rotSpeed)
    {
        foreach (Transform t in player.gameObject.transform)
        {
            if (t.tag == "Player")
            {

                t.gameObject.GetComponent<AddTorqueOnEveryTape>().tapeSpeed = rotSpeed;
            }
        }
    }
    public void GameStart()
    {
        Debug.Log("GameStart method is called ");
        //Use Second Chance
        if (UIManager.secondChance)
        {
            SecondChanceStartPanel.SetActive(false);
        }
        //Allready Used
        else
        {
            dragImage.gameObject.SetActive(false);
        }
        //IronSource.Agent.displayBanner();
        PlayerPrefs.SetInt("enable", 1);
        player.GetComponent<Core.Movement.MovementController>().enabled = true;
        rb.GetComponent<PathFollower>().enabled = true;
        //player.GetComponent<MovementController>().enabled = true;
        gameplay.SetActive(true);
        isGameStart = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGameStart)
        {
            return;
        }

        if (Input.touchCount <= 0)
        {
            SetEveryTapeRotation(-6f);
            //player.GetComponent<Core.Movement.MovementController>().enabled = true;
            //player.GetComponent<PathFollower>().speed1 = 45f;
        }






        float verticalMove()
        {
            return Mathf.Abs(fingerDown.y - fingerUp.y);
        }

        float horizontalValMove()
        {
            return Mathf.Abs(fingerDown.x - fingerUp.x);
        }

        //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////

        IEnumerator delay()
        {
            yield return new WaitForSeconds(0.7f);

        }
    }

}