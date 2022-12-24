using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forBoxOpening : MonoBehaviour
{
    public static forBoxOpening instance;
    public int number = 0;
    public GameObject TreasureBox;
    public GameObject particels;
    public GameObject Demon;
    public GameObject img;
    [SerializeField] private GameObject collectButton;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (number == 9)
        {
            number = 0;

            // play anim of boxOpen
            StartCoroutine(waitForSplash());
            Demon.GetComponent<Animator>().SetTrigger("open");



            StartCoroutine(waitForBox());


        }

    }
    public void onClickButtonADD()
    {
        number++;


    }
    public IEnumerator waitForBox()
    {
        yield return new WaitForSeconds(4f);
        TreasureBox.GetComponent<Animator>().SetTrigger("Activate");
        // particels.SetActive(true);

        yield return new WaitForSeconds(2f);
        img.SetActive(true);
        yield return new WaitForSeconds(1f);
        img.GetComponent<Animator>().Play("animationForMap");
        particels.SetActive(false);
        yield return new WaitForSeconds(3f);
        collectButton.SetActive(true);
    }
    public IEnumerator waitForSplash()
    {

        yield return new WaitForSeconds(4f);
        particels.SetActive(true);
    }
    public void passOnNextSecene()
    {
        collectButton.SetActive(false);
        img.SetActive(false);
        StartCoroutine(GenerateEndTapesDynamically.instance.delay());
    }


}
