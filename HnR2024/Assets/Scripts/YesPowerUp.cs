using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YesPowerUp : MonoBehaviour
{
    public void UseSkill()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.textBox.text = "yes";
            enemy.word = "yes";
        }

        SkillSelectManager.Instance.OnSelectSkill();
    }
}
