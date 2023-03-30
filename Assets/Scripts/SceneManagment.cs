using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private string _choosenAnimal = "";
    public string choosenAnimal;
    public GameObject chooseAnimaPanel;
    public GameObject mainMenuPanel;
    StartGame startGame;
    // Start is called before the first frame update
    void Start()
    {
        startGame = FindObjectOfType<StartGame>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RestartScene()
    {        
        SceneManager.LoadScene(1);
        startGame.RestartPlayer();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeScene()
    {
        if(_choosenAnimal == string.Empty)
        {
            _choosenAnimal = "PlayDragon";
        }

        choosenAnimal = _choosenAnimal;
        SceneManager.LoadScene(1);
        startGame.RespawnPlayer(choosenAnimal);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayDragon()
    {
        _choosenAnimal = "PlayDragon";
        ReturnToMainMenu();
    }

    public void PlayChicken()
    {
        _choosenAnimal = "PlayChicken";
        ReturnToMainMenu();
    }

    public void PlayCondor()
    {
        _choosenAnimal = "PlayCondor";
        ReturnToMainMenu();
    }

    public void ReturnToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        chooseAnimaPanel.SetActive(false);
    }

    public void ChooseAnimal()
    {
        mainMenuPanel.SetActive(false);
        chooseAnimaPanel.SetActive(true);
    }
}
