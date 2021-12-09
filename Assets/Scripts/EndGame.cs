using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    public Button loadGameButton;
    public Button startMenuButton;

    // Start is called before the first frame update
    void Start() {
        loadGameButton.onClick.AddListener(() => { StartGame(); });
        startMenuButton.onClick.AddListener(() => { ShowMenu(); });
    }

    void StartGame() {
        SceneManager.LoadScene("Game");
    }

    void ShowMenu() {
        SceneManager.LoadScene("Title");
    }
}
