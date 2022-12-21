using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsAnimation : MonoBehaviour
{
    public static coinsAnimation instance;
    // Start is called before the first frame update
    public GameObject Coins;
    public int totalCoins;
    public bool Cash;
    public List<GameObject> coinObj = new List<GameObject>();
    public Transform TargetPosition,startposition,instantiatePosition;
    public GameObject currencyParent;
    void Start()
    {
        instance = this;
        totalCoins = Random.Range(10, 20);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void AnimateCoins()
    {
        //if (Cash)
        //{
        //    if (GemManager.instance.GameplayCash <= 0)
        //    { return; }
        //}
        //else
        //{
        //    if (GemManager.instance.GameplayGems <= 0)
        //    { return; }
        //}
        for(int i=0;i<totalCoins;i++)
        {
            GameObject go = Instantiate(Coins, instantiatePosition.position, Quaternion.identity);
 
            go.GetComponent<Coins_animationScript>().target= TargetPosition;
            go.GetComponent<Coins_animationScript>().startingPos = startposition.position;
            go.transform.parent = currencyParent.transform;
            coinObj.Add(go);
        }
        
    }

}
