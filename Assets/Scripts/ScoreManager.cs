using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = new ScoreManager();
        }
    }

    public void increase(int value)
    {
        score += value;
        text.text = "X" + score.ToString();
    }
}
