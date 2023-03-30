using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    public List<GameObject> cloudList = new List<GameObject>();
    public List<GameObject> animals;
    private PlayerController playerController;
    private float leftBound = 35;
    GameObject[] elementsOutOfBounds;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        SpawnCloudsAtStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            elementsOutOfBounds = FindObjectsOfType<GameObject>();
            DestroyOutOfSightObjects();
        }
    }

    public void AddClouds()
    {
        Instantiate(cloudList[Random.Range(0, cloudList.Count)], new Vector3(playerController.transform.position.x + 30 + Random.Range(0, 10), Random.Range(0, 9), 15), Quaternion.Euler(0, 90, 0));
    }

    public void SpawnCloudsAtStart()
    {
        for (int i = 1; i < 10; i++)
        {
            Instantiate(cloudList[Random.Range(0, cloudList.Count)], new Vector3(playerController.transform.position.x + Random.Range(-20, 20), Random.Range(0, 9), 15), Quaternion.Euler(0, 90, 0));
        }
    }

    public void DestroyOutOfSightObjects()
    {
        Destroy(elementsOutOfBounds.Where(o => o.name.Contains("(Clone)") && o.transform.position.x < playerController.transform.position.x - leftBound).FirstOrDefault());
    }
}
