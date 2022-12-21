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

    }

    void Update()
    {
        distanceTraveled += speed1 * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);

    }



}
