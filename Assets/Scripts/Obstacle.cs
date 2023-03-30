using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GenerateObstacles generateObstacles;
    UIManagment uIManagment;
    EnviromentController enviromentController;
    // Start is called before the first frame update
    void Start()
    {
        generateObstacles = FindObjectOfType<GenerateObstacles>();   
        uIManagment = FindObjectOfType<UIManagment>();
        enviromentController = FindObjectOfType<EnviromentController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        generateObstacles.RespawnObstacles();
        uIManagment.AddScorePoints();
        enviromentController.AddClouds();
    }
}
