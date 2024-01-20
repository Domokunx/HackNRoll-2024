using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Props")]
    public float minSpeed = 0f;
    public float maxSpeed = 2f;
    public int attack = 1;

    private string[] words = new string[10] 
        {
            "hello",
            "test",
            "System.out.println();",
            "test2",
            "testers",
            "empty",
            "word",
            "yes",
            "testing",
            "HackNRoll"
        };
    [Space]

    [Header("Object Refs")]
    public Transform target;
    public TextMeshPro textBox;

    [HideInInspector] public string word;

    #region PriVars
    private float speed = 1f;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        word = words[Random.Range(0, words.Length)];
        textBox.text = word;
    }

    // Update is called once per frame
    void Update()
    {
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
}
