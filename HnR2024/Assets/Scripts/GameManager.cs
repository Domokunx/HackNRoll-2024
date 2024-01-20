using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ObjectRefs")]
    public TextMeshProUGUI scoreText;
    public TMP_InputField inputField;

    #region Private Variables
    int score = 0;

    private Enemy[] enemies;
    #endregion

    private void Start()
    {
        instance = this;

        inputField.Select();

        PlayerPrefs.SetInt("CurrentScore", 0);
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

        FindEnemyWithInput();

        // Delete Input
        inputField.text = string.Empty;
        inputField.ActivateInputField();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore");
    }
    private void FindEnemyWithInput()
    {
        Enemy closestE = null;
        foreach (Enemy e in enemies)
        {
            if (MyEquals(inputField.text.ToCharArray(), e.word.ToCharArray()))
            {
                closestE = e;
            }
        }

        if (closestE == null) return;
        closestE.TakeDamage();
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
