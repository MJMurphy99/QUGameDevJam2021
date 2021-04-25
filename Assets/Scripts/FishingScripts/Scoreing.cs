using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreing : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;

    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreBoard.text = "Score: " + score;
        }
    }

}
