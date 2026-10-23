using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public float moveSpeed = 10f; //player paddle speed 
    public float topHeight = 3.5f; //top limit of paddle
    public float bottomHeight = -3.5f; //bottom limit of paddle
    public bool useArrowKeys = false; //if activated move with arros, if not W and S


    void Update()
    {
        MovePaddle();
    }

    void MovePaddle() //
    { 
         this.gameObject.transform.position = new Vector3(transform.position.x, ConstrainPaddle(), transform.position.z);
    }
    
    float ConstrainPaddle() //makes sure paddle doesnt go over limits
    { 
        float nuevaY = this.gameObject.transform.position.y + (PaddleDirection() * moveSpeed * Time.deltaTime);

        if (nuevaY > topHeight)
        {
            nuevaY = topHeight;
        }
        if (nuevaY < bottomHeight)
        {
            nuevaY = bottomHeight;
        }
        return nuevaY;
    }

    float PaddleDirection() //function that determines paddle direcction
    {
        float direccion = 0f;

        if (useArrowKeys == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direccion = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direccion = -1f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                direccion = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direccion = -1f;
            }
        }
        return direccion;
    }

}
