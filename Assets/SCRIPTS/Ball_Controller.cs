using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball_Controller : MonoBehaviour
{
    public float velocidad = 10f;
    public Game_Manager Manager;
    public Scene_Controller Scene;
    private Rigidbody2D _rb;
    private float tiempoAtascada = 0f;
    float _lastHorizontalDirection = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector3(Random.Range(0, 2), Random.Range(-0.5f, 0.5f)).normalized * velocidad;
        LaunchBall(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > velocidad)
        {
            _rb.velocity = _rb.velocity.normalized * velocidad;
        }

        if (Mathf.Abs(_rb.velocity.x) >= velocidad * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 1f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * velocidad;
        }
    }

    void LaunchBall(int dir)
    {

        this.transform.position = new Vector3(0, 0, 0);

        bool isRight = false;

        if (dir == 0)
        {
            if (Random.value > 0.5f)
            {
                isRight = true;
            }
        }
        else if (dir == 1)
        {
            isRight = true;
        }



        float xVelocity = -1;
        if (isRight == true)
        {
            xVelocity = 1;
        }

        float yVelocity = Random.Range(-1f, 1f);
        _rb.velocity = new Vector2(xVelocity * velocidad, yVelocity * velocidad);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall_R"))
        {
            Manager.Player1++;
            if (Manager.Player1 == 5)
            {
                Scene.mainMenu();
            }
            else
            {
                LaunchBall(-1);
            }

        }

        if (collision.gameObject.CompareTag("Wall_L"))
        {
            Manager.Player2++;
            if (Manager.Player2 == 5)
            {
                Scene.mainMenu();
            }
            else
            {
                LaunchBall(1);
            }

        }

        Manager.UpdatePointsText();



    }
}
