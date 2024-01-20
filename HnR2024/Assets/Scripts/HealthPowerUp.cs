using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public void UseSkill()
    {
        Player.instance.Heal(1);
        SkillSelectManager.Instance.OnSelectSkill();
    }
}
