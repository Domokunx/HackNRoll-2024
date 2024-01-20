using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SkillSelectManager : MonoBehaviour
{
    public static SkillSelectManager Instance;

    public GameObject[] powerUps;
    public RectTransform[] skillPanels;

    public GameObject skillSelectScreen;
    public TMP_InputField inputField;

    private int[] chosen = new int[3] {-1, -1, -1};
    private GameObject[] pUPs = new GameObject[3];
    private void Start()
    {
        Instance = this;
    }

    public void OnSelectSkill()
    {
        Time.timeScale = 1.0f;
        skillSelectScreen.SetActive(false);
        inputField.enabled = true;
        inputField.Select();

        foreach (GameObject pUP in pUPs)
        {
            Destroy(pUP);        
        }
    }

    public void RefreshSelections()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomPUP;
            do 
            {
                randomPUP = Random.Range(0, powerUps.Length);
            }
            while (chosen.Contains(randomPUP));
            chosen[i] = randomPUP;

            pUPs[i] = Instantiate(powerUps[randomPUP], skillSelectScreen.transform);
            TransferRectTransform(skillPanels[i], pUPs[i].GetComponent<RectTransform>());
        }

        chosen = new int[] {-1, -1, -1};
    }

    private void TransferRectTransform(RectTransform from, RectTransform to)
    {
        to.anchorMin = from.anchorMin;
        to.anchorMax = from.anchorMax;
        to.anchoredPosition = from.anchoredPosition;
        to.sizeDelta = from.sizeDelta;
        to.pivot = from.pivot;
    }
}
