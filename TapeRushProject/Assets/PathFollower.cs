using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PathFollower : MonoBehaviour
{
    public GameObject dragImage;
    private Vector3 fingerDown;
    private Vector3 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    private Vector3 dragOffset;
    public float SWIPE_THRESHOLD = 20f;
    // public Rigidbody rb;
    private Vector3 moveVelocity;

    public PathCreator pathCreator;
    public float speed1 = 60f;
    float distanceTraveled;
    void Start()
    {
        // if (PlayerPrefs.GetInt("mode") == 1)
        // { speed1 = 55; }
        // else if (PlayerPrefs.GetInt("mode") == 2)
        // { speed1 = 70; }
        // else if (PlayerPrefs.GetInt("mode") == 3)
        // { speed1 = 80; }

        // if (PlayerPrefs.GetInt("mapNum") == 0)
        // { settingsScript.instance.mapParent.transform.GetChild(0).gameObject.SetActive(true); }
        // else if (PlayerPrefs.GetInt("mapNum") == 1)
        // { settingsScript.instance.mapParent.transform.GetChild(0).gameObject.SetActive(true); }
        // else if (PlayerPrefs.GetInt("mapNum") == 2)
        // { settingsScript.instance.mapParent.transform.GetChild(0).gameObject.SetActive(true); }
    }

    void Update()
    {
        distanceTraveled += speed1 * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);

    }



}
