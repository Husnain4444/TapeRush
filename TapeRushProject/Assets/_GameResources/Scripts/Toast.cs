using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Toast : MonoBehaviour
{
    public float life;
    void OnEnable()
    {
        Invoke("ToastHide", life);
    }
    void ToastHide()
    {
        gameObject.SetActive(false);
    }
}
