using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Button exit;
    public Button play;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        exit.onClick.AddListener(endGame);
        play.onClick.AddListener(toGameScene);
    }
    private void endGame() {
        Debug.Log("You ended the game!");
        Application.Quit();
    }
    private void toGameScene() {
        Debug.Log("You started the game!");
        SceneManager.LoadScene("Game");
    }
}
