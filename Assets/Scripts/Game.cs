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
    public AudioClip lowHealthAlarm;
    public AudioClip levelUpAudio;

    private float lowHealthAlarmCooldown = 0f;

    public Text levelUIText;

    public readonly static int maximumHealth = 5;
    public int health;

    public static bool isGamePaused = false;

    public static int previousLevel = 0;
    public static int currentLevel = 0;
    public static string[] currentLevelNames = new string[3]{"Tutorial", "Level 1: Escape The Corner", "Level 2: Couch Crawl"};
    public static Vector3[] levelStartCoordinates = new Vector3[3]{new Vector3(-829.02f, 73.6f, 620.5f), new Vector3(-774f, 88f, 325f), new Vector3(-273f, 156f, 372f)};
    private Color32 aliveColor = new Color32(0,128,0,100);
    private Color32 dangerColor = new Color32(245, 87, 66,100);
    private Color32 deadColor = new Color32(128,0,0,100);

    // Start is called before the first frame update
    void Start()
    {
        // teleportToCurrentLevelStart();
        gamePauseText.gameObject.SetActive(false);

        // Ensure game is not paused
        isGamePaused = false;
        Time.timeScale = 1;

        // Set Health
        health = maximumHealth;
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

        if (Input.GetKeyDown("x")) {
            currentLevel += 1;
        }

        // If game is paused, do not allow any actions in update1
        if (isGamePaused) {
            return;
        }

        // Check Level and see if we need to load a new one
        if (currentLevel != previousLevel) {
            loadCurrentLevel();
            AudioSource.PlayClipAtPoint(levelUpAudio, kyle.transform.position, 0.5f);
            previousLevel = currentLevel;
        }


        // If Kyle has no health, reload the current level
        if (health == 0){
            SceneManager.LoadScene("EndScreen");
        }

        if (health > 0 && health <= 2 && lowHealthAlarmCooldown <= 0) {
            AudioSource.PlayClipAtPoint(lowHealthAlarm, kyle.transform.position, 0.5f);
            lowHealthAlarmCooldown = 500f;
        } else if (health > 0 && health <= 2) {
            lowHealthAlarmCooldown -= 1f;
        } else {
            lowHealthAlarmCooldown = 500f;
        }

        // Correctly Draw The Health Bars of the Character
        HandleHealthBars();

        levelUIText.text = currentLevelNames[currentLevel];
        

    }


    void loadCurrentLevel() {
        health = maximumHealth;
        teleportToCurrentLevelStart();
        kyle.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


    void teleportToCurrentLevelStart() {
        Debug.Log("Loading Level" + currentLevel);
        Debug.Log("Level Start: " + levelStartCoordinates[currentLevel].x + "," + levelStartCoordinates[currentLevel].y + "," + levelStartCoordinates[currentLevel].z);
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
            if (health < 3) {
                healthBar3.GetComponent<Image>().color = dangerColor;
                healthBar4.GetComponent<Image>().color = dangerColor;
                healthBar5.GetComponent<Image>().color = dangerColor;
            }
        }
        else {
            healthBar2.GetComponent<Image>().color = deadColor;
        }

        if (health >= 1) {
            healthBar1.GetComponent<Image>().color = aliveColor;
            if (health < 2) {
                healthBar2.GetComponent<Image>().color = dangerColor;
                healthBar3.GetComponent<Image>().color = dangerColor;
                healthBar4.GetComponent<Image>().color = dangerColor;
                healthBar5.GetComponent<Image>().color = dangerColor;
            }
        }
        else {
            healthBar1.GetComponent<Image>().color = deadColor;
        }
    }

}
