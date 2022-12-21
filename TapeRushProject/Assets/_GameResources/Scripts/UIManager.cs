using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject ImageFillPanel, RewardPanel, SkinOpenPanel;
    public FillImageData[] FillImageList;
    public GameObject NoThanksButton;
    public Text ToastText;
    public Text TotalCoin;
    public Image[] images;
    public Material[] tapemat;
    public Material[] trailMat;
    public List<Texture> PatternToAddOnTape;
    public List<Sprite> skinsToGiveAsGifts;
    public Animator[] SkinAnimList;
    public coinsAnimation coinAnim;
    public Transform ArrowCenter;
    public Text multiplyText, RewardText;
    public MultiplyData[] rotationRangeList;
    //Shop
    public GameObject[] ItemsBgList, itemParentList;

    public int EarnedCoin;
    public int TotalKeys;
    public int TotalChildAdd;

    //Second Chnace
    public Sprite[] secondAnimSpritList;
    public Image SecondAnimImage;
    public GameObject ContinueButton, ReplayButton;
    public static bool secondChance;


    public static UIManager instance;

    Tween myTween;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("PatternReward") == 0)
        {
            PlayerPrefs.SetInt("PatternReward", 1);
        }
        // if (!PlayerPrefs.HasKey("Cool"))
        // {
        //     PlayerPrefs.SetInt("Cool", 0);
        // }
        foreach (Image i in images)
        {
            i.sprite = skinsToGiveAsGifts[PlayerPrefs.GetInt("PatternReward") - 1];
        }
    }

    public void OnGameWin(int totalTape)
    {
        Debug.Log("Total Tape: " + totalTape);
        TotalKeys = PlayerPrefs.GetInt("key");
        TotalChildAdd = totalTape / 2;
        //RewardPanel
        if (TotalKeys >= 3)
        {
            RewardPanel.SetActive(true);
            PlayerPrefs.SetInt("key", 0);
        }
        else
        {
            PanelAnimation();
        }
        IronSourceScript.instance.InterstitialShow();

    }
    public void PanelAnimation()
    {

        RewardPanel.SetActive(false);
        SkinOpenPanel.SetActive(false);
        StartMultiplyAnim();
        ImageFillPanel.SetActive(true);
        Invoke("NoThanksShow", 3f);
    }
    void NoThanksShow()
    {
        NoThanksButton.SetActive(true);
    }
    public void ClaimSkinToApplyOnTapes()
    {
        PlayerPrefs.SetInt("PatternReward", PlayerPrefs.GetInt("PatternReward") + 1);
        foreach (Material mat in tapemat)
        {
            mat.mainTexture = PatternToAddOnTape[PlayerPrefs.GetInt("PatternReward") - 1];
            mat.SetTexture("_DetailAlbedoMap", PatternToAddOnTape[PlayerPrefs.GetInt("PatternReward") - 1]);
        }
        foreach (Material mat in trailMat)
        {
            mat.mainTexture = PatternToAddOnTape[PlayerPrefs.GetInt("PatternReward") - 1];
            mat.SetTexture("_DetailAlbedoMap", PatternToAddOnTape[PlayerPrefs.GetInt("PatternReward") - 1]);

        }
        IronSourceScript.instance.InterstitialShow();
        //IronSource.Agent.showRewardedVideo();
    }

    public void SetTexture(Texture t)
    {
        foreach (Material mat in tapemat)
        {
            mat.mainTexture = t;
            mat.SetTexture("_DetailAlbedoMap", t);

        }
        foreach (Material mat in trailMat)
        {
            mat.mainTexture = t;
            mat.SetTexture("_DetailAlbedoMap", t);

        }
    }

    //Skin Open Code
    public void NewSkinOpen()
    {
        foreach (Image i in images)
        {
            i.sprite = skinsToGiveAsGifts[PlayerPrefs.GetInt("PatternReward") - 1];
        }
        RewardPanel.SetActive(false);
        SkinOpenPanel.SetActive(true);
        StartCoroutine(SkinAnimationStart());
    }
    IEnumerator SkinAnimationStart()
    {
        for (int i = 0; i < SkinAnimList.Length; i++)
        {
            SkinAnimList[i].Play("skinAnim");
            yield return new WaitForSeconds(.2f);
        }
    }
    void StartMultiplyAnim()
    {
        myTween = ArrowCenter.DORotate(new Vector3(0, 0, 120), 1, RotateMode.Fast);
        myTween.SetLoops(-1, LoopType.Yoyo);

        myTween.SetEase(Ease.Linear);
        StartCoroutine(PriceChange());
    }
    public void rewardedAd()
    {

        Debug.Log("Exit");
        myTween.Pause();
        StopAllCoroutines();
        IronSourceScript.instance.RewadedAd();
    }
    public void OnClaimClick()
    {

        RewardText.text = (EarnedCoin * MultiplyValue()).ToString();
        gameOverScript.instance.NextLevel();
    }
    IEnumerator PriceChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(.06f);
            multiplyText.text = (EarnedCoin * MultiplyValue()).ToString();
        }

    }
    int MultiplyValue()
    {
        float rotationValue = ArrowCenter.rotation.eulerAngles.z;
        int result = 1;
        for (int i = 0; i < rotationRangeList.Length; i++)
        {
            if (rotationValue >= rotationRangeList[i].startPoint && rotationValue < rotationRangeList[i].endPoint)
            {
                result = rotationRangeList[i].value;
                break;
            }
        }
        return result;

    }
    public void ShowToast(string msg)
    {
        ToastText.text = msg;
        ToastText.transform.parent.gameObject.SetActive(true);
    }
    public void RefreshCash(int amount)
    {
        int t = PlayerPrefs.GetInt("TotalCoins") + amount;
        TotalCoin.text = t.ToString();
        PlayerPrefs.SetInt("TotalCoins", t);
    }
    //For Second Chance And GameOver
    public void OnGameOver()
    {
        //Give 2nd Chance
        if (!secondChance)
        {
            secondChance = true;
            ContinueButton.SetActive(true);
            ReplayButton.SetActive(false);
            StartCoroutine(SecondChanceAnimation());
        }
        //Already Used
        else
        {
            secondChance = false;
            SecondAnimImage.gameObject.SetActive(false);
            ContinueButton.SetActive(false);
            ReplayButton.SetActive(true);
        }
    }
    public void ContinueClick()
    {
        StopAllCoroutines();
        IronSourceScript.instance.currentReward = rewardType.secondChance;
        IronSourceScript.instance.RewadedAd();
    }

    IEnumerator SecondChanceAnimation()
    {
        SecondAnimImage.gameObject.SetActive(true);
        for (int i = 0; i < secondAnimSpritList.Length; i++)
        {
            yield return new WaitForSeconds(.25f);
            SecondAnimImage.sprite = secondAnimSpritList[i];
        }
        secondChance = false;
        SecondAnimImage.gameObject.SetActive(false);
        ContinueButton.SetActive(false);
        ReplayButton.SetActive(true);
    }



    //For Shop Panel
    public void TabClick(int index)
    {
        for (int i = 0; i < itemParentList.Length; i++)
        {
            if (i == index)
            {
                itemParentList[i].SetActive(true);
                ItemsBgList[i].SetActive(true);
            }
            else
            {
                itemParentList[i].SetActive(false);
                ItemsBgList[i].SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class MultiplyData
    {
        public float startPoint, endPoint;
        public int value;
    }
    [System.Serializable]
    public class FillImageData
    {
        public Sprite[] FillImageSpritList;
        public Sprite ParentSprite;
    }
}
