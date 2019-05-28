using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public int coinValue = 1;
    public float fallSpeed = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.increase(coinValue);
            Destroy(this.gameObject);
        }
    }
}
