using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public int coinValue = 1;
    public float fallSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void Update()
    {
        transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        //transform.position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.increase(coinValue);
            Destroy(this.gameObject);
        }
    }
}
