using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelectManager : MonoBehaviour
{
    public GameObject skillSelectScreen;
    public void OnSelectSkill()
    {
        Time.timeScale = 1.0f;
        skillSelectScreen.SetActive(false);
    }
}
