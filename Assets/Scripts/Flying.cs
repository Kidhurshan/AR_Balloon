using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    [SerializeField] private float maxHeight = 4f;
    [SerializeField] private float baseSpeed = 0.1f;
    [SerializeField] private float speedMultiplier = 0.75f;

    private GameLoop gameloop; // Reference to the GameLoop script

    void Start()
    {
        // Dynamically find the GameLoop script in the scene
        GameObject gameLoopObject = GameObject.FindWithTag("GameLoop"); // Use a tag to find the object
        if (gameLoopObject != null)
        {
            gameloop = gameLoopObject.GetComponent<GameLoop>();
        }

        if (gameloop == null)
        {
            Debug.LogError("GameLoop script not found in the scene!");
        }
    }

    void Update()
    {
        speedMultiplier = 1f + Time.time / 60f;
        transform.Translate(Vector3.up * Time.deltaTime * baseSpeed * speedMultiplier);

        if (transform.position.y >= maxHeight)
        {
            Destroy(gameObject);

            if (gameloop != null)
            {
                gameloop.decrementHealth();
            }
        }
    }
}
