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
    public int enemyType;
    [Space]

    [Header("Object Refs")]
    public Transform target;
    public TextMeshPro textBox;

    [HideInInspector] public string word;

    #region PriVars
    private float speed = 1f;
    private string[] words1 = new string[] 
    {
        "hello",
        "test",
        "empty",
        "word",
        "yes",
        "class",
        "object"
    };

    private string[] words2 = new string[]
    {   
        "HackNRoll",
        "QuAcK",
        "Debuggle"
    };

    private string[] words3 = new string[]
    {
        "System.out.println();"
    };
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        word = enemyType == 1 ? words1[Random.Range(0, words1.Length)]
               : enemyType == 2 ? words2[Random.Range(0, words2.Length)]
               : words3[Random.Range(0, words3.Length)];
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
        word = enemyType == 1 ? words1[Random.Range(0, words1.Length)]
               : enemyType == 2 ? words2[Random.Range(0, words2.Length)]
               : words3[Random.Range(0, words3.Length)];
        textBox.text = word;
        textBox.color = Color.yellow;
    }
}
