using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterialsOnGameLoad : MonoBehaviour
{
    public Material[] tapemat;
    public Material hurdlesMat;
    public GameObject[] borders;
    public Material[] trailMat;
    // public Texture tex1, tex2, tex3,tex4,tex5,tex6,tex7,tex8;
    public Material trackMat;
    // public Texture trackTex1, trackTex2, trackTex3,trackTex4,trackTex5;
    // public int mn;
    public Material[] skyboxMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("gameLoad") == 0)
        {
            PlayerPrefs.SetInt("gameLoad", 1);
        }
        if (PlayerPrefs.GetInt("TrackMat") == 0)
        {
            PlayerPrefs.SetInt("TrackMat", 1);
        }

    }
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("TrackMat") > 5)
        {
            PlayerPrefs.SetInt("TrackMat", 1);
        }
        //F8C246
        if (PlayerPrefs.GetInt("TrackMat") == 1)
        {
            //RenderSettings.skybox = skyboxMaterial[0];
            borders[0].SetActive(true);
            borders[1].SetActive(true);
            borders[0].GetComponent<MeshRenderer>().material.color = GetColorFromString("0D285B");
            borders[1].GetComponent<MeshRenderer>().material.color = GetColorFromString("0D285B");
            hurdlesMat.color = GetColorFromString("F8C246");
            //trackMat.mainTexture = trackTex1;
            //trackMat.SetTexture("_DetailAlbedoMap", trackTex1);
            tapemat[0].color = GetColorFromString("2AF63F");
            trailMat[0].color = GetColorFromString("2AF63F");
            tapemat[1].color = GetColorFromString("CB1C24");
            trailMat[1].color = GetColorFromString("CB1C24");
            tapemat[2].color = GetColorFromString("FFDE17");
            trailMat[2].color = GetColorFromString("FFDE17");
            tapemat[3].color = GetColorFromString("E5178C");
            trailMat[3].color = GetColorFromString("E5178C");
            tapemat[4].color = GetColorFromString("2B3990");
            trailMat[4].color = GetColorFromString("2B3990");
            tapemat[5].color = GetColorFromString("F25E22");
            trailMat[5].color = GetColorFromString("F25E22");
            //PlayerPrefs.SetInt("TrackMat", 2);
        }
        else if (PlayerPrefs.GetInt("TrackMat") == 2)
        {
            //RenderSettings.skybox = skyboxMaterial[0];
            borders[0].SetActive(true);
            borders[1].SetActive(true);
            borders[0].GetComponent<MeshRenderer>().material.color = GetColorFromString("0C504F");
            borders[1].GetComponent<MeshRenderer>().material.color = GetColorFromString("0C504F");
            hurdlesMat.color = GetColorFromString("F8C246");
            //trackMat.mainTexture = trackTex2;
            //trackMat.SetTexture("_DetailAlbedoMap", trackTex2);
            tapemat[0].color = GetColorFromString("A53F98");
            trailMat[0].color = GetColorFromString("A53F98");
            tapemat[1].color = GetColorFromString("CE1E2D");
            trailMat[1].color = GetColorFromString("CE1E2D");
            tapemat[2].color = GetColorFromString("F9D928");
            trailMat[2].color = GetColorFromString("F9D928");
            tapemat[3].color = GetColorFromString("2B39A4");
            trailMat[3].color = GetColorFromString("2B39A4");
            tapemat[4].color = GetColorFromString("F1408C");
            trailMat[4].color = GetColorFromString("F1408C");
            tapemat[5].color = GetColorFromString("58C74A");
            trailMat[5].color = GetColorFromString("58C74A");
            //PlayerPrefs.SetInt("TrackMat", 3);
        }
        else if (PlayerPrefs.GetInt("TrackMat") == 3)
        {
            //RenderSettings.skybox = skyboxMaterial[1];
            borders[0].SetActive(false);
            borders[1].SetActive(false);
            //trackMat.mainTexture = trackTex3;
            //trackMat.SetTexture("_DetailAlbedoMap", trackTex3);
            hurdlesMat.color = GetColorFromString("E96A06");
            tapemat[0].color = GetColorFromString("93278F");
            trailMat[0].color = GetColorFromString("93278F");
            tapemat[1].color = GetColorFromString("754C24");
            trailMat[1].color = GetColorFromString("754C24");
            tapemat[2].color = GetColorFromString("008D45");
            trailMat[2].color = GetColorFromString("008D45");
            tapemat[3].color = GetColorFromString("2E3192");
            trailMat[3].color = GetColorFromString("2E3192");
            tapemat[4].color = GetColorFromString("C1272D");
            trailMat[4].color = GetColorFromString("C1272D");
            tapemat[5].color = GetColorFromString("FF00C7");
            trailMat[5].color = GetColorFromString("FF00C7");

            //PlayerPrefs.SetInt("TrackMat", 4);
        }
        else if (PlayerPrefs.GetInt("TrackMat") == 4)
        {
            //RenderSettings.skybox = skyboxMaterial[2];
            borders[0].SetActive(true);
            borders[1].SetActive(true);
            //trackMat.mainTexture = trackTex4;
            //trackMat.SetTexture("_DetailAlbedoMap", trackTex4);
            hurdlesMat.color = GetColorFromString("F8C246");
            tapemat[0].color = GetColorFromString("A53F98");
            trailMat[0].color = GetColorFromString("A53F98");
            tapemat[1].color = GetColorFromString("CE1E2D");
            trailMat[1].color = GetColorFromString("CE1E2D");
            tapemat[2].color = GetColorFromString("F9D928");
            trailMat[2].color = GetColorFromString("F9D928");
            tapemat[3].color = GetColorFromString("2B39A4");
            trailMat[3].color = GetColorFromString("2B39A4");
            tapemat[4].color = GetColorFromString("F1408C");
            trailMat[4].color = GetColorFromString("F1408C");
            tapemat[5].color = GetColorFromString("58C74A");
            trailMat[5].color = GetColorFromString("58C74A");

            //PlayerPrefs.SetInt("TrackMat", 5);
        }
        else if (PlayerPrefs.GetInt("TrackMat") == 5)
        {
            //RenderSettings.skybox = skyboxMaterial[3];
            borders[0].SetActive(true);
            borders[1].SetActive(true);
            //trackMat.mainTexture = trackTex5;
            //trackMat.SetTexture("_DetailAlbedoMap", trackTex5);
            hurdlesMat.color = GetColorFromString("F8C246");
            tapemat[0].color = GetColorFromString("FFDE17");
            trailMat[0].color = GetColorFromString("FFDE17");
            tapemat[1].color = GetColorFromString("754C24");
            trailMat[1].color = GetColorFromString("754C24");
            tapemat[2].color = GetColorFromString("008D45");
            trailMat[2].color = GetColorFromString("008D45");
            tapemat[3].color = GetColorFromString("2E3192");
            trailMat[3].color = GetColorFromString("2E3192");
            tapemat[4].color = GetColorFromString("C1272D");
            trailMat[4].color = GetColorFromString("C1272D");
            tapemat[5].color = GetColorFromString("F25E22");
            trailMat[5].color = GetColorFromString("F25E22");
            //PlayerPrefs.SetInt("TrackMat", 6);
        }
        //if (PlayerPrefs.GetInt("gameLoad") > 8)
        //{
        //    PlayerPrefs.SetInt("gameLoad", 1);
        //}
        //if (PlayerPrefs.GetInt("gameLoad") == 1)
        //{
        //foreach (Material m in tapemat)
        //{
        //    m.mainTexture = tex1;
        //    m.SetTexture("_DetailAlbedoMap", tex1);
        //}
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex1;
        //        m.SetTexture("_DetailAlbedoMap", tex1);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 2);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 2)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex2;
        //        m.SetTexture("_DetailAlbedoMap", tex2);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex2;
        //        m.SetTexture("_DetailAlbedoMap", tex2);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 3);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 3)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex3;
        //        m.SetTexture("_DetailAlbedoMap", tex3);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex3;
        //        m.SetTexture("_DetailAlbedoMap", tex3);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 4);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 4)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex4;
        //        m.SetTexture("_DetailAlbedoMap", tex4);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex4;
        //        m.SetTexture("_DetailAlbedoMap", tex4);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 5);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 5)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex5;
        //        m.SetTexture("_DetailAlbedoMap", tex5);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex5;
        //        m.SetTexture("_DetailAlbedoMap", tex5);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 6);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 6)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex6;
        //        m.SetTexture("_DetailAlbedoMap", tex6);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex6;
        //        m.SetTexture("_DetailAlbedoMap", tex6);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 7);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 7)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex7;
        //        m.SetTexture("_DetailAlbedoMap", tex7);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex7;
        //        m.SetTexture("_DetailAlbedoMap", tex7);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 8);
        //}
        //else if (PlayerPrefs.GetInt("gameLoad") == 8)
        //{
        //    foreach (Material m in tapemat)
        //    {
        //        m.mainTexture = tex8;
        //        m.SetTexture("_DetailAlbedoMap", tex8);
        //    }
        //    foreach (Material m in trailMat)
        //    {
        //        m.mainTexture = tex8;
        //        m.SetTexture("_DetailAlbedoMap", tex8);
        //    }
        //    PlayerPrefs.SetInt("gameLoad", 9);
        //}
    }
    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }
    private float HexToFloatNormalized(string Hex)
    {
        return HexToDec(Hex) / 255f;
    }
    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));

        return new Color(red, green, blue);
    }
    // Update is called once per frame
    void Update()
    {
        // mn = PlayerPrefs.GetInt("gameLoad");
        //DontDestroyOnLoad(this.gameObject);
    }
}
