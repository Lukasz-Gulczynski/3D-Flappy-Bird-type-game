using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float space = 10;
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            RespawnObstacles();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnObstacles()
    {
        Instantiate(obstacle, new Vector3(space, Random.Range(-0.5f, -4.5f), 1), Quaternion.Euler(0, 0, 0));
        space += 10;
    }
}
