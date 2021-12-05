using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private GameObject currentAnimal;
    public GameObject[] animals;
    private PlayerController playerController;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        currentAnimal = animals[0];
        for (int i = 1; i < animals.Length; i++) { 
            animals[i].gameObject.SetActive(false);
        }
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


}