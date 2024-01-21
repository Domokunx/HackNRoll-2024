using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastStandPowerUP : MonoBehaviour
{
    public LastStandObject lso;
    public void UseSkill()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.speed = 0;
            enemy.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        EnemyManager.instance.enabled = false;

        Instantiate(lso);
        SkillSelectManager.Instance.OnSelectSkill();

    }

    
}
