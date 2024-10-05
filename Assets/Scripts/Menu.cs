using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI inputField;
    public TextMeshProUGUI text;

    private void Start()
    {
        MenuManager.instant.LoadScore();

        text.text = "Best Score: "+MenuManager.instant.MaxName+": " + MenuManager.instant.MaxScore;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        MenuManager.instant.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
    public void GetName()
    {
       
    string inputText = inputField.text;
        MenuManager.instant.name = inputText;

    }
    public void LoadScoreOnText()
    {
        MenuManager.instant.LoadScore();

    }
}

