using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPowerUp : MonoBehaviour
{
    public void UseSkill()
    {
        Player.instance.Heal(2);
        SkillSelectManager.Instance.OnSelectSkill();
    }
}
