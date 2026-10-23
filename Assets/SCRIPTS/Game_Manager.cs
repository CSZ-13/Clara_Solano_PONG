using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public int Player1;
    public int Player2;
    public string points;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(points);
        
    }

    public void UpdatePointsText()
    {

        points = Player1 + "|" + Player2;
        scoreText.text = points;
    }
}
