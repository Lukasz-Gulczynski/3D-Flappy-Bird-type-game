using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public List<GameObject> animals;
    public GameObject player;
    PlayerController playerController;
    private string choosenAnimal;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            choosenAnimal = playerController.name.Replace("(Clone)", "");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer(string animal)
    {
        player = Instantiate(animals.Find(a => a.name == animal), new Vector3(-5f, 0, 10), Quaternion.Euler(0, 90, 0));
        DontDestroyOnLoad(player);
    }

    public void RestartPlayer()
    {
        player = Instantiate(animals.Find(a => a.name == choosenAnimal), new Vector3(-5f, 0, 10), Quaternion.Euler(0, 90, 0));
        DontDestroyOnLoad(player);
    }
}
