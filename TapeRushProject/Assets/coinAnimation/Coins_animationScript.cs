using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_animationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startingPos;
    public Transform target;
    Vector3 offset;
    public float speed = 100, speed2 = 100;
    Coroutine delay;
    void Start()
    {
        startingPos = this.GetComponent<RectTransform>().position;
       
        speed = Random.Range(700, 1000);
        speed2 = Random.Range(1200, 1500);
        float x = Random.Range(-100, 100);
        float y = Random.Range(100, -200);
        offset = new Vector3(x, y, 0);
        StartCoroutine(scattering());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator scattering()
    {
        while ((int)Vector3.Distance(transform.position , startingPos + offset)>0)
        {
            yield return new WaitForFixedUpdate();
            transform.position = Vector3.MoveTowards(transform.position, startingPos + offset, Time.deltaTime * speed);
        }
        StartCoroutine(MoveToTarget());
    }
    IEnumerator MoveToTarget()
    {
        // float delay = Random.Range(1.0f, 1f);
        yield return new WaitForSeconds(.5f);
        while ((int)transform.position.y !=(int) target.position.y)
        {
            yield return new WaitForFixedUpdate();
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5);
        }
        Debug.Log("aaaaa");
       // target.GetComponent<Animator>().SetTrigger("punch");
        this.gameObject.SetActive(false);
    }
}
