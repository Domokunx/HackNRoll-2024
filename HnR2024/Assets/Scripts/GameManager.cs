using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("ObjectRefs")]
    public TextMeshProUGUI scoreText;
    public TMP_InputField inputField;

    #region Private Variables
    int score = 0;

    private Enemy[] enemies;
    #endregion

    private void Start()
    {
        inputField.Select();

        PlayerPrefs.SetInt("CurrentScore", 0);
        score = 0;
    }

    private void Update()
    {
        enemies = FindObjectsOfType<Enemy>();
        
    }

    public void CheckInput()
    {
        if (string.IsNullOrWhiteSpace(inputField.text)) 
        {
            inputField.text = string.Empty;
            inputField.ActivateInputField();
            return;
        }

        if (FindEnemyWithInput())
        {
            scoreText.text = "Score: " + ++score;
            PlayerPrefs.SetInt("CurrentScore", score);
        }

        // Delete Input
        inputField.text = string.Empty;
        inputField.ActivateInputField();
    }
    private bool FindEnemyWithInput()
    {
        foreach (Enemy e in enemies)
        {
            if (MyEquals(inputField.text.ToCharArray(), e.word.ToCharArray()))
            {
                Debug.Log("enemy killed");  
                Destroy(e.gameObject);
                return true;
            }
        }
        return false;
    }
    private bool MyEquals(char[] s1, char[] s2)
    {
        for (int i = 0; i < s2.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                return false;
            }
        }
        return true;
    }
}
