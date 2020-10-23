using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Saving;
public class Player : MonoBehaviour,ISaveable
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
    //Saving
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        data["hpValue"] = permanentHp;
        data["strengthValue"] = permStrength;
        data["defenseValue"] = permDefense;
        data["luckValue"] = permanentLuck;
        data["accuracyValue"] = accuracyPercent;
        data["evadeValue"] = evadePercent;
        data["critattackPercent"] = criticalAttackPercentage;
        data["critattackMultiply"] = criticalAttackMultiplier;
        return data;
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        permanentHp = (float)data["hpValue"];
        permStrength = (float)data["strengthValue"];
        permDefense = (float)data["defenseValue"];
        permanentLuck = (float)data["luckValue"];
        accuracyPercent = (float)data["accuracyValue"];
        evadePercent = (float)data["evadeValue"];
        criticalAttackPercentage = (float)data["critattackPercent"] ;
        criticalAttackMultiplier = (float)data["critattackMultiply"];
    }
}
