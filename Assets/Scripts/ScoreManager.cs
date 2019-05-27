using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public GameObject coin;
    public TextMeshProUGUI text;
    public int coinsCount = 4;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            StartCoroutine(SpawnCoins());
        }
    }

    IEnumerator SpawnCoins () {
        int i = coinsCount;
        while (i-- > 0) {
            Instantiate(coin, new Vector2(Random.Range(-12f, 12f), 15.0f), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void increase(int value)
    {
        score += value;
        text.text = "X" + score.ToString();
    }
}
