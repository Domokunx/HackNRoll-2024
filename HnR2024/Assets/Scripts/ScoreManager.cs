using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<string, int> submitScoreEvent;

    [SerializeField]
    private TMP_InputField inputField;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputField.text, PlayerPrefs.GetInt("CurrentScore"));
    }
}
