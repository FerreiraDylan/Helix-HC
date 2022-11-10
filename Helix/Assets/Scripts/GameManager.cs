using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject Menu;
    public GameObject Victory;
    public GameObject Defeated;
    public GameObject UI;

    public int mapLength;
    public int level;
    public int maxDistance;

    public int progress;

    [Header("UI")]
    public Text t_MenuLevel;
    public Text t_actLevel;
    public Slider s_progress;

    public bool startGame;
    public float controlAxis;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        mapLength = PlayerPrefs.GetInt("mapLength", 20);
        maxDistance = (mapLength + 1) * 6;
        level = PlayerPrefs.GetInt("level", 0);

        startGame = false;
        Menu.SetActive(true);
        Victory.SetActive(false);
        Defeated.SetActive(false);
        UI.SetActive(false);
        controlAxis = 0;
        progress = 0;
        s_progress.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = (float)progress / (float)19;

        s_progress.value = Mathf.Lerp(s_progress.value, tmp, Time.deltaTime);
        t_MenuLevel.text = level.ToString();
        t_actLevel.text = level.ToString();
    }

    public void StartGame()
    {
        Menu.SetActive(false);
        startGame = true;
        UI.SetActive(true);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("mapLength", mapLength);
        PlayerPrefs.SetInt("level", level);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
