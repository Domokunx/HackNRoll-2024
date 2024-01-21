using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPowerUp : MonoBehaviour
{
    public GameObject cat;
    public void UseSkill()
    {
        Instantiate(cat, new Vector3(Random.Range(-12, 12), Random.Range(-6, 6), 0), cat.transform.rotation);

        SkillSelectManager.Instance.OnSelectSkill();
    }
}
