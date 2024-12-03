using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    void Start()
    {
        // Ensure we have a unique material instance for each balloon
        mat = GetComponent<Renderer>().material;
        float hueMin = 0f;       // Full range of colors (0 to 1)
        float hueMax = 1f;
        float saturationMin = 0.4f; // Medium saturation to avoid overly dull colors
        float saturationMax = 0.7f;
        float valueMin = 0.5f;      // Medium to bright colors (light to medium-dark)
        float valueMax = 0.85f;

        // Assign a random color within the specified HSV range
        mat.color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
