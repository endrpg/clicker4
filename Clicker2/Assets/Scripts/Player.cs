using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float permanentHp = 100f;
    public float currentHp  = 100f;
    public float permStrength = 10f;
    public float permDefense = 10f;
    public float accuracyPercent = 100f;
    public float criticalAttackPercentage;
    public float criticalAttackMultiplier;
    public float evadePercent = 10f;
    public float permanentLuck = 10f;
    public GameObject losePanel;
    // Update is called once per frame
    void Update()
    {
        if(currentHp <= 0)
        {
            GameManager.Instance.currentTurn = true;
            GameObject lost = Instantiate(losePanel,GameObject.Find("War Panel").transform);
        }
    }
}
