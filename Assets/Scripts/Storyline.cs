using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Storyline : MonoBehaviour
{

    public Button returnToMenuButton;

    // Start is called before the first frame update
    void Start() {
        returnToMenuButton.onClick.AddListener(() => { LoadStartingScene(); });
    }

    void LoadStartingScene() {
        SceneManager.LoadScene("Title");
    }
}
