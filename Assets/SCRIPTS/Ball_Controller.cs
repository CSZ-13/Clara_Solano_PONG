using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Ball_Controller : MonoBehaviour
{
    public float ballVelocity = 10f;
    public Game_Manager Manager;
    public Scene_Controller Scene;
    private Rigidbody2D _rb;
    private float tiempoAtascada = 0f;
    float _lastHorizontalDirection = 1f;
    private AudioSource _AudioSource;

    public float timeAlive = 0f;
    float velocityMulty = 1f;

    public GameObject p1WinPanel;
    public GameObject p2WinPanel;

    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1f;
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector3(Random.Range(0, 2), Random.Range(-0.5f, 0.5f)).normalized * ballVelocity;
        _AudioSource = GetComponent<AudioSource>();
        
        LaunchBall(0);
    }

    private void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 2f && velocityMulty <2f)
        {
            ballVelocity = 10f;
            velocityMulty += 0.25f;
            ballVelocity *= velocityMulty;
            timeAlive = 0f;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > ballVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * ballVelocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= ballVelocity * 0.3f)
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
            ) * ballVelocity;
        }
    }

    void LaunchBall(int dir)
    {
        velocityMulty = 1f;
        ballVelocity = 10f;
        timeAlive = 0f;

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
        _rb.velocity = new Vector2(xVelocity * ballVelocity, yVelocity * ballVelocity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Wall_L"))
        {
            
            Manager.Player1++;
            if (Manager.Player1 == 5)
            {
                Manager.WinSound();
                p1WinPanel.SetActive(true);
                Time.timeScale = 0f;
               
            }
            else
            {
                Manager.ScoreSound();
                LaunchBall(-1);
            }

        }

        if (collision.gameObject.CompareTag("Wall_R"))
        {
            
            Manager.Player2++;
            if (Manager.Player2 == 5)
            {
                Manager.WinSound();
                p2WinPanel.SetActive(true);
                Time.timeScale = 0f;
               
            }
            else
            {
                Manager.ScoreSound();
                LaunchBall(1);
            }

        }
        
        _AudioSource.pitch = Random.Range(0.8f, 1.5f);
        _AudioSource.Play();

        Manager.UpdatePointsText();



    }
}
