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

    /*pos.x = posici� player x --> en cas de que sa posici� 
     * sigui major que 15 o menor que -15, no el deixarem passar; 
     * farem que se recoloqui a un nou vector*/
     void Update()
    {
        horitzontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horitzontalInput);
        //anar a la dreta x velocitat declarada x correcci� de temps x input horitzontal(moviment en eix x)

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
        /*si sa meva posici� en x �s menor que -15 (-15=borde)
         * el recolocar�(new vector3) al l�mit en l'eix x i deixar� igual y + z*/

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
