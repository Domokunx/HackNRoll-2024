using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("ObjectRefs")]
    public TextMeshProUGUI scoreText;
    public TMP_InputField inputField;
    public Transform playerTransform;
    public Slider expBar;
    public GameObject skillSelectScreen;

    #region Private Variables
    private Enemy[] enemies;

    private int EXPincrease = 2;
    private int maxEXP = 5;
    #endregion

    private void Start()
    {
        instance = this;

        inputField.Select();

        expBar.value = 0;
        expBar.maxValue = maxEXP;
        PlayerPrefs.SetInt("CurrentScore", 0);

        skillSelectScreen.SetActive(false);
    }

    private void Update()
    {
        enemies = FindObjectsOfType<Enemy>();
        
        if (expBar.value == maxEXP)
        {
            LevelUp();
        }
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
        expBar.value++;
        scoreText.text = "Score: " + PlayerPrefs.GetInt("CurrentScore");
    }
    private void FindEnemyWithInput()
    {
        Enemy closestE = null;
        foreach (Enemy e in enemies)
        {
            if (MyEquals(inputField.text.ToCharArray(), e.word.ToCharArray()))
            {
                if (closestE == null || !CurrCloserToTarget(e.transform, closestE.transform)) { }
                closestE = e;
            }
        }

        if (closestE == null) return;
        closestE.TakeDamage();
    }
    private bool CurrCloserToTarget(Transform newEnemy, Transform currEnemy)
    {
        return Vector3.Distance(playerTransform.position, newEnemy.position) >
               Vector3.Distance(playerTransform.position, currEnemy.position);
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

    private void LevelUp()
    {
        expBar.value -= maxEXP;
        maxEXP += ++EXPincrease;
        expBar.maxValue = maxEXP;
        
        skillSelectScreen.SetActive(true);
        Time.timeScale = 0f;
        inputField.enabled = false;
        SkillSelectManager.Instance.RefreshSelections();
    }
}
