using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Props")]
    public int enemyHealth = 1;
    public float minSpeed = 0f;
    public float maxSpeed = 2f;
    public int attack = 1;
    public int score = 1;
    public bool isBoss = false;
    [Space]

    [Header("Object Refs")]
    public Transform target;
    public TextMeshPro textBox;

    [HideInInspector] public string word;

    #region PriVars
    private float speed = 1f;
    private string[] words = new string[] 
        {
            "hello",
            "test",
            "empty",
            "word",
            "yes",
            "testing",
            "class",
            "object"
        };

    private string[] bossWords = new string[]
        {   
            "System.out.println();",
            "HackNRoll",
            "QuAcK"
        };
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        word = isBoss ? bossWords[Random.Range(0, bossWords.Length)] : words[Random.Range(0, words.Length)];
        textBox.text = word;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            PlayerPrefs.SetInt("CurrentScore", PlayerPrefs.GetInt("CurrentScore") + score);
            GameManager.instance.UpdateScore();
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Trigger");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            Player.instance.TakeDamage(attack);
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        enemyHealth--;
        word = isBoss ? bossWords[Random.Range(0, bossWords.Length)] : words[Random.Range(0, words.Length)];
        textBox.text = word;
        textBox.color = Color.yellow;
    }
}
