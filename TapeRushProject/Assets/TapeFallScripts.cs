using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TapeFallScripts : MonoBehaviour
{
    //public GameObject Pos;
    public Transform tapeFallPos;
    public List<GameObject> arrangeTapes;
    public float sizeY;
    private Vector3 start;
    private Vector3 target;
    private float lungeSpeed = .8f;
    private IEnumerator coroutine;
    public CinemachineVirtualCamera cvam;
    public GameObject followTapeToMoveDownward;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in this.transform)
        {

            if (t.tag == "Player" && t.gameObject.activeInHierarchy)
            {

                arrangeTapes.Add(t.gameObject);
                t.GetComponent<TaapeFallFromBuilding>().enabled = true;
                t.gameObject.GetComponent<AddTorqueOnEveryTape>().enable = true;

                t.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }


        }
        //cvam.LookAt = arrangeTapes[0].transform;
        //cvam.Follow = arrangeTapes[0].transform;


        sizeY = (arrangeTapes.Count * (-4f)) - 3f;
        MoveTapesToEndPos();
    }

    public void MoveTapesToEndPos()
    {

        followTapeToMoveDownward.GetComponent<followFirstTape>().enabled = true;
        followTapeToMoveDownward.GetComponent<followFirstTape>().Target = arrangeTapes[0];
        float y = arrangeTapes[0].transform.position.y;
        Destroy(arrangeTapes[0].GetComponent<hurdleCollider>().trail.gameObject);
        arrangeTapes[0].transform.position = new Vector3(tapeFallPos.position.x, arrangeTapes[i].transform.position.y, arrangeTapes[i].transform.position.z);
        arrangeTapes[0].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        arrangeTapes[0].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        arrangeTapes[0].GetComponent<Rigidbody>().useGravity = true;
        arrangeTapes[0].GetComponent<Rigidbody>().isKinematic = false;

        arrangeTapes[0].transform.position = Vector3.Lerp(new Vector3(arrangeTapes[0].transform.position.x, 0f, arrangeTapes[0].transform.position.z), tapeFallPos.transform.position, 4f);

        arrangeTapes[0].GetComponent<TaapeFallFromBuilding>().enabled = true;


        StartCoroutine("delay");
    }

    IEnumerator MoveTapes(int index, Vector3 start, Vector3 target, float speed)
    {
        arrangeTapes[index].transform.position = Vector3.MoveTowards(start, target, speed);
        //sizeY = arrangeTapes[index - 1].transform.position.y;
        float t = 0.0f;
        float rate = 5.0f / speed;
        while (t < 5.0)
        {
            t += Time.deltaTime * rate;

            yield return null;
        }
        yield return new WaitForSeconds(3);
    }
    IEnumerator delay()
    {
        for (int i = 1; i < arrangeTapes.Count; i++)
        {
            yield return new WaitForSeconds(0.8f);
            //StartCoroutine("delay");
            sizeY = sizeY + 3f;
            //start = new Vector3(arrangeTapes[0].transform.position.x, 0f, arrangeTapes[0].transform.position.z);
            //target = new Vector3(tapeFallPos.position.x, sizeY + 3, tapeFallPos.position.z);
            //coroutine = MoveTapes(i,start, target, lungeSpeed);
            //StartCoroutine(coroutine);
            float y = arrangeTapes[i].transform.position.y;
            Destroy(arrangeTapes[i].GetComponent<hurdleCollider>().trail.gameObject);
            arrangeTapes[i].transform.position = new Vector3(tapeFallPos.position.x, arrangeTapes[i].transform.position.y, arrangeTapes[i].transform.position.z);
            arrangeTapes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            arrangeTapes[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            arrangeTapes[i].GetComponent<Rigidbody>().useGravity = true;
            arrangeTapes[i].GetComponent<Rigidbody>().isKinematic = false;
            //while (Vector3.Distance(arrangeTapes[i].transform.position, tapeFallPos.transform.position) > 0)
            //{
            //    arrangeTapes[i].GetComponent<Rigidbody>().AddTorque(13f, 0f, 0f);
            //}
            arrangeTapes[i].transform.position = Vector3.Lerp(new Vector3(arrangeTapes[0].transform.position.x, 0f, arrangeTapes[0].transform.position.z), tapeFallPos.transform.position, 4f);
            arrangeTapes[i].GetComponent<TaapeFallFromBuilding>().enabled = true;
            //arrangeTapes[i].transform.position = Vector3.Lerp(new Vector3(arrangeTapes[0].transform.position.x, 0f, arrangeTapes[0].transform.position.z), new Vector3(tapeFallPos.position.x, sizeY + 3, tapeFallPos.position.z), 4f);
            //StartCoroutine("delay");
        }
        //i = i + 1;



    }
    // Update is called once per frame
    void Update()
    {

    }
}
