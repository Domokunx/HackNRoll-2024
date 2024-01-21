using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRatePowerUp : MonoBehaviour
{
    public void UseSkill()
    {
        EnemyManager.instance.IncreaseSpawnIntervals();
        SkillSelectManager.Instance.OnSelectSkill();
    }
}
