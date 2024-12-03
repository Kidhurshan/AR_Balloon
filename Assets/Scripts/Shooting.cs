using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject smoke;
    public GameLoop gameloop;

    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Balloon(Clone)")
            {
                Destroy(hit.transform.gameObject);
                GameObject smokeInstance = Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(smokeInstance, 2f);
                gameloop.incrementScore();
            }
        }
    }

}