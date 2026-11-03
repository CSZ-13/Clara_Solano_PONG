using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int Player1;
    public int Player2;
    public string points;
    public AudioClip pointScoreSound;
    public AudioClip matchWin;
    public AudioSource gameAudio;
    public TextMeshProUGUI scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        pointScoreSound = GetComponent<AudioClip>();
        matchWin = GetComponent<AudioClip>();
        Debug.Log(points);
        
    }
    public void ScoreSound()
    { 
        gameAudio.clip = pointScoreSound;
    }

    public void WinSound() 
    {
        gameAudio.clip = matchWin;
    }

    public void UpdatePointsText()
    {

        points = Player1 + "|" + Player2;
        scoreText.text = points;
    }
}
