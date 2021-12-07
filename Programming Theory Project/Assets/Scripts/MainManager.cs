using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private GameObject currentAnimal;
    public GameObject[] animals;
    private PlayerController playerController;
    private GameObject player;
    public int hp = 100;
    public Text hpText;
    public Text nicknameText;
    public Text GameoverText;
    public Button RetryButton;
    public Button GoToMenuButton;
    private int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        if (!MenuHandler.isFirstScene) {
            SceneManager.LoadScene(0);
        }
        Instance = this;
        nicknameText.text = MenuHandler.nickname;
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        currentAnimal = animals[0];
        for (int i = 1; i < animals.Length; i++) { 
            animals[i].gameObject.SetActive(false);
        }

        GameoverText.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);
        GoToMenuButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };
        for (int i = 0; i < animals.Length; i++) {
            if (Input.GetKeyDown(keys[i]))
            {
                currentAnimal.SetActive(false);
                currentAnimal = animals[i];
                animals[i].SetActive(true);
                playerController.animal = currentAnimal;
                currentAnimal.transform.SetParent(player.transform, true);
            }
        }

    }

    public void DisplayDamage(Enemy enemy) {
        if (enemy.canStrike) {
            enemy.canStrike = false;
            hp -= damage;
            if (hp <= 0) {
                Gameover();
            }
            hpText.text = "HP: " + hp;
            StartCoroutine(enemy.DelayStrike());
        }
       
    }
    private void Gameover() {
        Time.timeScale = 0;
        GameoverText.gameObject.SetActive(true);
        RetryButton.gameObject.SetActive(true);
        GoToMenuButton.gameObject.SetActive(true);

    }
    public void RetryGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
