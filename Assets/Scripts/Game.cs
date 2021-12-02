using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{


    public Camera mainCamera;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject healthBar4;
    public GameObject healthBar5;

    public Text levelUIText;

    public int health = 5;

    public static int currentLevel = 0;
    public static string[] currentLevelNames = new string[4]{"Tutorial", "Level 1: Escape The Corner", "Level 2: The Great Glass Table", "Level 3: Dresser Run"};

    private Color32 aliveColor = new Color32(0,128,0,100);
    private Color32 deadColor = new Color32(128,0,0,100);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Correctly Draw The Health Bars of the Character
        HandleHealthBars();

        levelUIText.text = currentLevelNames[currentLevel];


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
