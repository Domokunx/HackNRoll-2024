using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPowerUp : MonoBehaviour
{
    public void UseSkill()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.speed /= 3;
        }

        SkillSelectManager.Instance.OnSelectSkill();
    }
}
