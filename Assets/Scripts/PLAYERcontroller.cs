using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERcontroller : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 15f; //rango de moviment a x
    public float zRangeUp = 15f;
    public float zRangeDown = 1; //15 fins -1
    private float horitzontalInput;
    private float verticalInput;

    public GameObject projectilePrefab;

    /*pos.x = posició player x --> en cas de que sa posició 
     * sigui major que 15 o menor que -15, no el deixarem passar; 
     * farem que se recoloqui a un nou vector*/
     void Update()
    {
        horitzontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horitzontalInput);
        //anar a la dreta x velocitat declarada x correcció de temps x input horitzontal(moviment en eix x)

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        PlayerInBound();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void PlayerInBound() //bordes 
    {
        /*si sa meva posició en x és menor que -15 (-15=borde)
         * el recolocaré(new vector3) al límit en l'eix x i deixaré igual y + z*/

        Vector3 pos = transform.position;
        if(pos.x < -xRange) 
        {
            transform.position = new Vector3(-xRange, pos.y, pos.z);
        }
        if(pos.x > xRange)
        {
            transform.position = new Vector3(xRange, pos.y, pos.z);
        }
        if(pos.z > zRangeUp)
        {
            transform.position = new Vector3(pos.x, pos.y, zRangeUp);
        }
        if(pos.z < -zRangeDown)
        {
            transform.position = new Vector3(pos.x, pos.y, -zRangeDown);
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }


}
