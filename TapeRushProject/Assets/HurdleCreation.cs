using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleCreation : MonoBehaviour
{
    public List<GameObject> hurdles;
    public Transform HurdleParent;
    public int totalCreation;
    public float startZ, LeftX, RightX,IncrementZ;
    float currentZ;
    void Start()
    {
        currentZ = startZ;
        HurdleCreate();
    }
    void HurdleCreate()
    {
        for (int i = 0; i < totalCreation; i++)
        {
            int indexH = Random.Range(0, hurdles.Count);
            float xValue = Random.Range(LeftX, RightX);
            Instantiate(hurdles[indexH], new Vector3(xValue, 0, currentZ),Quaternion.identity,HurdleParent);
            currentZ += IncrementZ;
        }
    }
}
