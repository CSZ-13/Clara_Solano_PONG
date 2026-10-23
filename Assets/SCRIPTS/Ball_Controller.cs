using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball_Controller : MonoBehaviour
{
    public float velocidad = 10f;
    public Game_Manager Manager;
    private Rigidbody2D _rb;
    private float tiempoAtascada = 0f;
   

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D> ();
        _rb.velocity = new Vector3(Random.Range(0, 2), Random.Range(-0.5f, 0.5f)).normalized*velocidad;
        LaunchBall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _rb.velocity = _rb.velocity.normalized * velocidad;
    
    }

    void LaunchBall()
    {
        bool isRight = false;
        if (Random.value > 0.5f)
        {
            isRight = true;
        }

        float xVelocity = -1;
        if (isRight == true) 
        { 
            xVelocity = 1;
        }

        float yVelocity = Random.Range (-1f,1f);
        _rb.velocity = new Vector2 (xVelocity*velocidad, yVelocity*velocidad);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ball hit");
        
        Manager.Player1 ++;
        Debug.Log(Manager.points);
        Manager.UpdatePointsText();

    }
}
