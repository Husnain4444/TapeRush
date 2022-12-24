using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using PathCreation;
using System.Threading.Tasks;

public class gamePlayController : MonoBehaviour
{
    public static gamePlayController instance;
    public Color[] cameraColor;
    public Color[] fogColor;
    public Color[] gateColor;
    public GameObject gateFinishLine;
    public GameObject gameEndCharacter;
    public Text levelNoText;
    public Text gameOverLevelNoTxt;
    public Text gameWinLevelNoTxt;
    public Button pause;
    public Button play;
    [System.Serializable]
    public class LevelInfo
    {
        //public static LevelInfo instance = null;
        public int levelNo;
        public bool newTapeAdded;
        public GameObject borderRight;
        public GameObject borderLeft;
        public Transform LevelStartPos;
        public GameObject level;
        public Material skyboxMaterial;
        public Material trackMaterial;
        public Texture trackTexture;
        public GameObject finishLine;
        public GameObject endGameObject;
        public PathCreator path;
        public float ForwardSpeed;
        public int setTrackMatTapeCOmboNo;
        // Start is called before the first frame update


    }
    public List<LevelInfo> levels = new List<LevelInfo>();
    public GameObject Player;
    public changeMaterialsOnGameLoad borders;
    //public 
    public int levelNo;
    public CinemachineVirtualCamera cvcam;
    public CinemachineVirtualCamera cvcam2, cvcam4;
    async void Start()
    {
        Application.targetFrameRate = 60;
        if (instance == null)
        { instance = this; }
        if (PlayerPrefs.GetInt("Level") == 0 || PlayerPrefs.GetInt("Level") > 11)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        levelNo = PlayerPrefs.GetInt("Level");
        // levelNo = 7;
        InitiateLevel();
        levelNoText.text = "Level " + levelNo.ToString();
        gameOverLevelNoTxt.text = "Level " + levelNo.ToString();
        gameWinLevelNoTxt.text = "Level " + levelNo.ToString();
        levelNoText.gameObject.SetActive(true);

        await Task.Delay(2000);
        Player.GetComponent<settingsScript>().enabled = false;
        // gameEndCharacter.transform.position = new Vector3(gameEndCharacter.transform.position.x, GameObject.Find("Score Screen (4)").gameObject.transform.position.y, gameEndCharacter.transform.position.z);
        gameEndCharacter.transform.position = GameObject.Find("Score Screen (4)").gameObject.transform.position;
        gameEndCharacter.transform.position = new Vector3(GameObject.Find("Score Screen (4)").gameObject.transform.position.x, 0.2f, GameObject.Find("Score Screen (4)").gameObject.transform.position.z + 50);
    }
    public void InitiateLevel()
    {

        for (int i = 0; i < levels.Count; i++)
        {
            if (i + 1 == levelNo)
            {
                levels[i].level.SetActive(true);
                //levelNo = i - 1;
            }
            else
            {
                levels[i].level.SetActive(false);
            }
        }
        Player.GetComponent<PathFollower>().pathCreator = levels[levelNo - 1].path;
        Player.transform.position = levels[levelNo - 1].LevelStartPos.position;
        cvcam.Follow = levels[levelNo - 1].finishLine.transform;
        cvcam2.Follow = levels[levelNo - 1].endGameObject.transform;
        cvcam2.LookAt = levels[levelNo - 1].endGameObject.transform;
        borders.borders[0] = levels[levelNo - 1].borderLeft;
        borders.borders[1] = levels[levelNo - 1].borderRight;
        levels[levelNo - 1].trackMaterial.mainTexture = levels[levelNo - 1].trackTexture;
        levels[levelNo - 1].trackMaterial.SetTexture("_DetailAlbedoMap", levels[levelNo - 1].trackTexture);
        RenderSettings.skybox = levels[levelNo - 1].skyboxMaterial;
        PlayerPrefs.SetInt("TrackMat", levels[levelNo - 1].setTrackMatTapeCOmboNo);
        Player.GetComponent<PathFollower>().speed1 = levels[levelNo - 1].ForwardSpeed;
        if (levels[levelNo - 1].newTapeAdded == true)
        {
            PlayerPrefs.SetInt("TapeSkin", 1);
        }
        else
        {
            PlayerPrefs.SetInt("TapeSkin", 0);
        }

    }


    public void gamePause()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("enable", 0);
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }
    public void gamePlay()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("enable", 1);
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
