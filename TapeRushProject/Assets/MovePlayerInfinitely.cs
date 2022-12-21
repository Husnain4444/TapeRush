using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerInfinitely : MonoBehaviour
{
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = new Vector3(0f, 0f, 16f);
    }
    private void OnEnable()
    {
        moveDirection = new Vector3(0f, 0f, 26f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
    }
}
