using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float heightLimit = 5;
    private float playingTime = 0;
    private Rigidbody playerRb;
    public bool obstacleCollision = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playingTime += Time.deltaTime;
        playerRb.velocity = new Vector3(speed + (playingTime/4), playerRb.velocity.y, playerRb.velocity.z);

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y + jumpForce);
        }

        if(transform.position.y > heightLimit)
        {
            transform.position = new Vector3(transform.position.x, heightLimit, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
        }
        else if(transform.position.y < -heightLimit)
        {
            transform.position = new Vector3(transform.position.x, -heightLimit, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Obstacle"))
        {
            obstacleCollision = true;
            //DestroyAllComponents();
            Destroy(gameObject);
        }
    }

    public void DestroyAllComponents()
    {
        var components = GetComponents<Component>();
        foreach (var component in components)
        {
            if (component is Transform)
                continue;
            Destroy(component);
        }
    }
}
