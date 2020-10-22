using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Not found");
            }
            return instance;
        }
    }

    public bool currentTurn = true;
    public Player player;
    public Enemy enemy;
    [SerializeField]float gold = 100;
    public GameObject parentPanel;
    public List<IconCreator> myPowerups;
    public List<GeneralEnemy> Tier1Enemy;
    public List<GeneralEnemy> Tier2Enemy;
    public List<GeneralEnemy> Tier3Enemy;
    public GeneralEnemy myEnemyObj;
    public GameObject enemyPrefab;
    public GameObject slotPrefab;
    [Range(-1,4)]public int hearts;
    public int tempType; // Received from attackButtonSccript
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    public void DoDamage(float damage)
    {
        if(!currentTurn)
        {
            currentTurn = true;
            float evadeValue = Random.value;
            if(evadeValue > player.evadePercent/100)
            {
                CriticalDamage(player.criticalAttackPercentage/100, damage);
                player.currentHp -= (float)Mathf.RoundToInt(damage - (Random.value * player.permDefense));
                Debug.Log("Player " + player.currentHp);
                WriterScript.Instance.Debuging("Enemy Hit You, " + "You : " + player.currentHp.ToString());
            }
        }
        else if(currentTurn)
        {
            currentTurn = false;
            float evadeValue = Random.value;
            if(evadeValue > myEnemyObj.evadePercent/100)
            {
                if(tempType != -1 && (tempType == (int)myEnemyObj.weakAgainst|| tempType == (int)myEnemyObj.weakAgainst2))
                {
                    CriticalDamage(myEnemyObj.criticalAttackPercentage/100, damage);
                    enemy.health -= (float)Mathf.RoundToInt(((player.accuracyPercent/100+1)*damage) -(Random.value * enemy.defense));
                    tempType = -1;
                }
                else if(tempType != -1 && (tempType == (int)myEnemyObj.strongAgainst||tempType == (int)myEnemyObj.strongAgainst2))
                {
                    CriticalDamage(myEnemyObj.criticalAttackPercentage/100, damage);
                    enemy.health -= (float)Mathf.RoundToInt((player.accuracyPercent/100 - Random.value) *damage);
                    tempType = -1;
                }
                else
                {
                    CriticalDamage(myEnemyObj.criticalAttackPercentage/100, damage);
                    enemy.health -= (float)Mathf.RoundToInt(damage);
                }
                Debug.Log("Enemy " + enemy.health);
            }
        }
    }
    void CriticalDamage(float toCheck, float damage)
    {
        float criticalControl = Random.value;
        if(criticalControl > toCheck)
        {
            if(!currentTurn)
            {
                enemy.health -= (float)Mathf.RoundToInt((myEnemyObj.criticalAttackMultiplier-1)*(((player.accuracyPercent/100+1)*damage) -(Random.value * enemy.defense)));
            }
            else if(currentTurn)
            {
                player.currentHp -= (float)Mathf.RoundToInt((player.criticalAttackMultiplier-1)*(damage - (Random.value * player.permDefense)));
            }
        }
    }
    //Slot Instantiation
    public void SlotInstantiation()
    {
        foreach (var item in myPowerups)
        {
            float number = 0;
            if(item.amount > 0&& !item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
                prefabInstantiated.GetComponent<AttackButtonScript>().itemNo = number;
            }
            else if(item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
            }
            number += 1;
        }
    }
    public void EnemyRandomise()
    {
        player.currentHp = player.permanentHp;
        int randomNum = Random.Range(0,Tier1Enemy.Count);
        currentTurn = true;
        enemy = null;
        myEnemyObj = Tier1Enemy[randomNum];
        GameObject enemyG = (GameObject)Instantiate(enemyPrefab,new Vector2(31,370),Quaternion.identity);
        enemyG.transform.SetParent(GameObject.Find("War Panel").transform,false);
        enemyG.GetComponent<Image>().sprite = myEnemyObj.enemySprite;
        enemy = enemyG.GetComponent<Enemy>();
        enemy.attack = myEnemyObj.attack;
        enemy.health = myEnemyObj.health;
        enemy.defense = myEnemyObj.defense;
    }
    //Gold Related methods
    public void RemoveGold(float coins)
    {
        gold -= coins;
    }
    public float ReturnGold()
    {
        return gold;
    }
    public void AddGold(float coins)
    {
        gold += coins;
    }
}
