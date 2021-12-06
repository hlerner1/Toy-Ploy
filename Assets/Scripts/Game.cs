using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{


    public Camera mainCamera;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject healthBar4;
    public GameObject healthBar5;
    public GameObject gamePauseText;

    public GameObject kyle;

    public Text levelUIText;

    public readonly static int maximumHealth = 5;
    public int health = maximumHealth;

    public static bool isGamePaused = false;

    public static int currentLevel = 0;
    public static string[] currentLevelNames = new string[4]{"Tutorial", "Level 1: Escape The Corner", "Level 2: The Great Glass Table", "Level 3: Dresser Run"};
    public static Vector3[] levelStartCoordinates = new Vector3[]{new Vector3(-829.02f, 73.6f, 620.5f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f)};

    private Color32 aliveColor = new Color32(0,128,0,100);
    private Color32 deadColor = new Color32(128,0,0,100);

    // Start is called before the first frame update
    void Start()
    {
        teleportToCurrentLevelStart();
        gamePauseText.gameObject.SetActive(false);

        // Ensure game is not paused
        isGamePaused = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        // Pause game by pressing "p"
        if (Input.GetKeyDown("p")) {
            isGamePaused = !isGamePaused;
            Time.timeScale = isGamePaused ? 0 : 1;
            gamePauseText.gameObject.SetActive(isGamePaused);
        }

        // If game is paused, allow quitting via "q" to title
        if (isGamePaused && Input.GetKeyDown("q")) {
            SceneManager.LoadScene("Title");
        }

        // If game is paused, do not allow any actions in update
        if (isGamePaused) {
            return;
        }

        // If Kyle has no health, reload the current level
        if (health == 0){
            loadCurrentLevel();
        }
        // Correctly Draw The Health Bars of the Character
        HandleHealthBars();

        levelUIText.text = currentLevelNames[currentLevel];


    }


    void loadCurrentLevel() {
        health = maximumHealth;
        teleportToCurrentLevelStart();
    }


    void teleportToCurrentLevelStart() {
        kyle.transform.position = levelStartCoordinates[currentLevel];
    }

    void HandleHealthBars() {
        if (health >= 5) {
            healthBar5.GetComponent<Image>().color = aliveColor;
        }
        else {
            healthBar5.GetComponent<Image>().color = deadColor;
        }

        if (health >= 4) {
            healthBar4.GetComponent<Image>().color = aliveColor;
        }
        else {
            healthBar4.GetComponent<Image>().color = deadColor;
        }

        if (health >= 3) {
            healthBar3.GetComponent<Image>().color = aliveColor;
        }
        else {
            healthBar3.GetComponent<Image>().color = deadColor;
        }

        if (health >= 2) {
            healthBar2.GetComponent<Image>().color = aliveColor;
        }
        else {
            healthBar2.GetComponent<Image>().color = deadColor;
        }

        if (health >= 1) {
            healthBar1.GetComponent<Image>().color = aliveColor;
        }
        else {
            healthBar1.GetComponent<Image>().color = deadColor;
        }
    }

}
