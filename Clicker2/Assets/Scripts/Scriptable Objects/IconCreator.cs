using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "IconCreator", menuName = "Icon/New Icon")]
public class IconCreator : ScriptableObject
{
    public Sprite iconSprite;
    public string iconTitle;
    public string iconDescription;
    public float strength;
    public float defense;
    public float accuracy;
    public float luckPercent;
    public float criticalAtkpercentage;
    public float critmultiplier;
    public float healPower;
    public float amount;
    public float maxAmount;
    public float price;
    public bool infinite;
    public float permanentStrengthInc;
    public float permanentDefenseInc;
    public float permanentAccuracyInc;
    public float permanentDodgeInc;
    public float permanentLuckinc;
    public float hpIncrease;
    public float lifeIncrease;
    public GameObject effect;
    [System.Serializable]
    public enum Tiers
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5
    }
    [System.Serializable]
    public enum Type
    {
        None,
        Earth,
        Fire,
        Water,
        Wind,
        Electric,
        Dark,
        Holy
    }
    [System.Serializable]
    public enum Equipment
    {
        None,
        Weapon,
        Shield,
        Head,
        Chest,
        Torso,
        Shoes,
        Ring
    }
    public Tiers tiers;
    public Type type;
    public Equipment equipment;
}