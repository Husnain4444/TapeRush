using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTorqueOnEveryTape : MonoBehaviour
{
    public float tapeSpeed;
    public bool enable;
    // Start is called before the first frame update
    void Start()
    {
        tapeSpeed = -4f;
    }
    private void Awake()
    {
        PlayerPrefs.SetInt("enable", 0);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
        }
        if (PlayerPrefs.GetInt("enable") == 1 && enable==true)
        {
            transform.Rotate(new Vector3(0f, tapeSpeed, 0f), Space.Self);

        }
    }
}
