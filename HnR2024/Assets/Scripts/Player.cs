using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Player Props")]
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Died");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
