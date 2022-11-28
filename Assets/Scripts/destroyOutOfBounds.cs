using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOutOfBounds : MonoBehaviour
{
    public float upperLimit = 20f;
    public float lowerLimit = -10f;

    // Update is called once per frame
    void Update()
    {
        //límit inferior --> animals no alimentats
        if (transform.position.z <= lowerLimit) 
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        if (transform.position.z >= upperLimit)
        {
            Destroy(gameObject);
        }
    }



}
