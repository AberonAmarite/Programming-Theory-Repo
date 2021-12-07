using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler Instance;
    public InputField inputField;
    public static string nickname;
    public static bool isFirstScene = false;
    private void Start()
    {
        Instance = this;
        isFirstScene = true;
    }
    public void StartGame() { 
        nickname = inputField.text;
        SceneManager.LoadScene(1);
    }
}
