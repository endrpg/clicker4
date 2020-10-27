using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDevTV.Saving;
public class GameManager : MonoBehaviour,ISaveable
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
    public Slider enemyHealth;
    public Slider playerHealth;
    public GameObject enemyPrefab;
    public GameObject slotPrefab;
    public float warsFought = 0f;
    [Range(0,3)]public int hearts;
    public int tempType; // Received from attackButtonSccript
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerHealth.maxValue = player.currentHp;
    }
    void currentfalse()
    {
        currentTurn = true;
    }
    public void DoDamage(float damage)
    {
        if(!currentTurn)
        {
            float evadeValue = Random.value;
            if(evadeValue > player.evadePercent/100)
            {
                CriticalDamage(player.criticalAttackPercentage/100, damage);
                player.currentHp -= (float)Mathf.RoundToInt(damage - (Random.value * player.permDefense));
                Debug.Log("Player " + player.currentHp);
                WriterScript.Instance.Debuging("Enemy Hit You, " + "You : " + player.currentHp.ToString());
            }
            currentfalse();
        }
        else if(currentTurn)
        {
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
            currentTurn = false;
        }
    }
    void CriticalDamage(float toCheck, float damage)
    {
        float criticalControl = Random.value;
        if(criticalControl < toCheck)
        {
            if(currentTurn)
            {
                enemy.health -= (float)Mathf.RoundToInt((myEnemyObj.criticalAttackMultiplier-1)*(((player.accuracyPercent/100+1)*damage) -(Random.value * enemy.defense)));
            }
            else if(!currentTurn)
            {
                player.currentHp -= (float)Mathf.RoundToInt((player.criticalAttackMultiplier-1)*(damage - (Random.value * player.permDefense)));
            }
        }
    }
    void Update()
    {
        if(myEnemyObj != null)
        {
            enemyHealth.value = myEnemyObj.health;
        }
        playerHealth.value = player.currentHp;
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
        if(warsFought <= 33f)
        {
            player.currentHp = player.permanentHp;
            int randomNum = Random.Range(0,Tier1Enemy.Count);
            currentTurn = true;
            enemy = null;
            myEnemyObj = Tier1Enemy[randomNum];
        }
        else if(warsFought > 33f && warsFought <= 60f)
        {
            player.currentHp = player.permanentHp;
            int randomNum = Random.Range(0,Tier2Enemy.Count);
            currentTurn = true;
            enemy = null;
            myEnemyObj = Tier2Enemy[randomNum];
        }
        else if(warsFought> 60f)
        {
            player.currentHp = player.permanentHp;
            int randomNum = Random.Range(0,Tier3Enemy.Count);
            currentTurn = true;
            enemy = null;
            myEnemyObj = Tier3Enemy[randomNum];
        }
        GameObject enemyG = (GameObject)Instantiate(enemyPrefab,new Vector2((float)-306.2,(float)-164.98),Quaternion.identity);
        enemyG.transform.SetParent(GameObject.Find("War Panel").transform,false);
        enemyG.GetComponent<Image>().sprite = myEnemyObj.enemySprite;
        enemy = enemyG.GetComponent<Enemy>();
        enemy.attack = myEnemyObj.attack;
        enemy.health = myEnemyObj.health;
        enemy.defense = myEnemyObj.defense;
        enemyHealth = enemyG.transform.GetChild(0).GetComponent<Slider>();
        enemyHealth.maxValue = myEnemyObj.health;
        enemyHealth.value = myEnemyObj.health;
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
    public float ReturnEnemyGold()
    {
        return myEnemyObj.goldToWin;
    }
    //Setting Instantiated to false
    public void InstantiateFalse()
    {
        GameManager.Instance.player.instantiated = false;
        GameManager.Instance.enemy.instantiated = false;
    }
    //Reset
    public void GameReset()
    {
        myPowerups.Clear();
        gold = 100f;
        warsFought = 0f;
        hearts = 3;
        EquipmentManager.Instance.Equipment.Clear();
        EquipmentManager.Instance.head = null;
        EquipmentManager.Instance.chest = null;
        EquipmentManager.Instance.torso = null;
        EquipmentManager.Instance.shoes = null;
        EquipmentManager.Instance.equipment = null;
        EquipmentManager.Instance.shield = null;
        EquipmentManager.Instance.ring1 = null;
        EquipmentManager.Instance.ring2 = null;
        GameManager.Instance.player.permanentHp = 100f;
        GameManager.Instance.player.permStrength = 10f;
        GameManager.Instance.player.permDefense = 10f;
        GameManager.Instance.player.accuracyPercent = 100f;
        GameManager.Instance.player.criticalAttackPercentage = 4f;
        GameManager.Instance.player.criticalAttackMultiplier = 1.5f;
        GameManager.Instance.player.evadePercent = 10f;
        GameManager.Instance.player.permanentLuck = 10f;

    }
    //Saving
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        var slotStrings = new string [myPowerups.Count];
        for (int i = 0; i < myPowerups.Count;i++)
        {
            slotStrings[i] = myPowerups[i].uniqueId;
        }
        data["myPowerupsList"] = slotStrings;
        data["goldValue"] = gold;
        return data;
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        var restoreList = (string[])data["myPowerupsList"];
        var allIconsList = GameObject.Find("Store Manager").GetComponent<StoreManager>().allIcons;
        for(int i = 0; i < allIconsList.Count; i++)
        {
            var itemId = allIconsList[i];
            int pos = System.Array.IndexOf(restoreList,itemId);
            if(pos > -1)
            {
                myPowerups.Add(allIconsList[i]);
            }
        }
        gold = (float)data["goldValue"];
    }
}
