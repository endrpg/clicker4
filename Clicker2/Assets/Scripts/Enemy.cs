using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    public float attack = 5f;
    public float health = 100f;
    public float defense = 10f;
    bool attackDone = false;
    public GameObject winPanel;
    public bool instantiated = false;
    void Update()
    {
        if(!GameManager.Instance.currentTurn&&!attackDone)
        {
            StartCoroutine(Attack());
        }
        if(health <= 0 && !instantiated)
        {
            instantiated = true;
            GameManager.Instance.currentTurn = true;
            GameObject lost = Instantiate(winPanel,GameObject.Find("War Panel").transform);
            GameManager.Instance.warsFought += 1;
            GameManager.Instance.AddGold(GameManager.Instance.ReturnEnemyGold());
        }
    }
    IEnumerator Attack()
    {
        attackDone = true;
        yield return new WaitForSeconds(2f);
        GameManager.Instance.DoDamage(attack);
        attackDone = false;
    }
}
