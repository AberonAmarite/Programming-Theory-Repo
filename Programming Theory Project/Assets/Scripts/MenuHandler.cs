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
    private void Start()
    {
        Instance = this;
    }
    public void StartGame() { 
        nickname = inputField.text;
        SceneManager.LoadScene(1);
    }
}
