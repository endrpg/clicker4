using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1", menuName = "GeneralEnemy/New Enemy")]
public class GeneralEnemy : ScriptableObject
{
    public Sprite enemySprite;
    public string monsterName;
    public string monsterInfo;
    public float health;
    public float attack;
    public float defense;
    public float goldToWin;
    public float evadePercent;
    public float criticalAttackPercentage;
    public float criticalAttackMultiplier;

    public WeakAgainst weakAgainst;
    public StrongAgainst strongAgainst;
    public WeakAgainst weakAgainst2;
    public StrongAgainst strongAgainst2;
    public specialItemDropped ItemDrop;
    public enum WeakAgainst
    {
        Earth,
        Fire,
        Water,
        None,
        Wind,
        Electric,
        Dark,
        Holy
    }
    public enum StrongAgainst
    {
        Earth,
        Fire,
        Water,
        None,
        Wind,
        Electric,
        Dark,
        Holy
    }
    public enum specialItemDropped
    {
        none,
        item1,
        item2,
        item3,
        item4,
        item5,
        item6,
        item7,
        item8,
        item9,
        item10
    }
}
