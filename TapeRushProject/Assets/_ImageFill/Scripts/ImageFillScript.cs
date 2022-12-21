using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageFillScript : MonoBehaviour
{
    public Transform FillParent;
    public GameObject TapeObj;
    public ParticleSystem[] ps;
   
    public List<Transform> allChildList;
    List<Vector3> allChildPositionList=new List<Vector3>();
    int currentNumber=0;
    int currentImage;
    void Start()
    {
        Init();
    }
    void Init()
    {
        allChildList = new List<Transform>();
        foreach (Transform child in FillParent)
        {
            allChildList.Add(child);
            allChildPositionList.Add(child.position);
            child.gameObject.SetActive(false);
        }
        allChildList.RemoveAt(allChildList.Count - 1);
        allChildPositionList.RemoveAt(allChildPositionList.Count - 1);

        //Check Current Image
        currentImage = PlayerPrefs.GetInt("Image");
        for(int i=0;i<allChildList.Count;i++)
        {
            allChildList[i].GetComponent<Image>().sprite = UIManager.instance.FillImageList[currentImage].FillImageSpritList[i];
        }

        //Check Previous OpenPart
        currentNumber =PlayerPrefs.GetInt("Child");
        if (currentNumber > 0)
        {
            for (int i = 0; i < currentNumber; i++)
            {
                allChildList[i].gameObject.SetActive(true);
            }
        }
        if (UIManager.instance.TotalChildAdd > 0)
        {
            StartCoroutine(AutoCombineCorutine());
        }
        
    }
    
    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Mouse Clicked!");
    //        CombineChild();
    //    }
    //}
    IEnumerator AutoCombineCorutine()
    {
        for (int i = 0; i < UIManager.instance.TotalChildAdd; i++)
        {
            
            CombineChild();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void CombineChild()
    {
       
        //Should Not out of bound
        if (currentNumber < allChildList.Count)
        {
            StartCoroutine(CombineCoroutine());
        }
        else 
        {
            Debug.Log("Picture is Completed!");
        }
    }
    IEnumerator CombineCoroutine()
    {
        Transform obj = allChildList[currentNumber];
        obj.position = obj.position + new Vector3(500, 0, 0);
        obj.gameObject.SetActive(true);
        obj﻿﻿﻿.DOMove(allChildPositionList[currentNumber], .4f);
        yield return new WaitForSeconds(.2f);
        //Vertical Combine
        if (currentNumber % 5 == 0 && currentNumber!=0)
        {
            TapeObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            TapeObj.transform.position = (allChildPositionList[currentNumber] + allChildPositionList[currentNumber - 5]) / 2;
        }
        // Horizontal Combine
        else if(currentNumber!=0)
        {
            TapeObj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            TapeObj.transform.position = (allChildPositionList[currentNumber] + allChildPositionList[currentNumber - 1]) / 2;
        }
        TapeObj.transform.localScale = Vector3.one;
        TapeObj.SetActive(true);
        yield return new WaitForSeconds(.1f);
        TapeObj.transform.DOScaleY(0, .2f);
        if (currentNumber < allChildList.Count - 1)
        {
            currentNumber++;
            PlayerPrefs.SetInt("Child", currentNumber);
        }
        else
        {
            NextImage();
            foreach (ParticleSystem s in ps)
            {
                s.Play();
            }
            
            
            
        }
        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
    void NextImage()
    {
        currentImage++;
        if (currentImage > PlayerPrefs.GetInt("GiftIndex"))
        {
            PlayerPrefs.SetInt("GiftIndex", currentImage);
        }
        if (currentImage >= UIManager.instance.FillImageList.Length)
        {
            currentImage--;
        }
        PlayerPrefs.SetInt("Image", currentImage);
        StartCoroutine("delay");
        for (int i = 0; i < allChildList.Count; i++)
        {
            allChildList[i].gameObject.SetActive(false);
            allChildList[i].GetComponent<Image>().sprite = UIManager.instance.FillImageList[currentImage].FillImageSpritList[i];
        }
        currentNumber = 0;
        PlayerPrefs.SetInt("Child", currentNumber);
    }

    

}
