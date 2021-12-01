using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public Button startGameButton;
    public Button showInstructionsButton;

    // Start is called before the first frame update
    void Start() {
        startGameButton.onClick.AddListener(() => { StartGame(); });
        showInstructionsButton.onClick.AddListener(() => { LoadInstructions(); });
    }

    void StartGame() {
        SceneManager.LoadScene("Game");
    }

    void LoadInstructions() {
        SceneManager.LoadScene("Instructions");
    }
}
