using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AttackButtonScript : MonoBehaviour
{
    public IconCreator myObj;
    Button me;
    public TextMeshProUGUI amount;
    public float itemNo;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentTurn)
        {
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{AttackingEnemy();});
        }
        UpdateText();
    }
    void AttackingEnemy()
    {
        if(myObj.amount > 0)
        {
            if((int)myObj.type != 3)
            {
                GameManager.Instance.tempType = (int)myObj.type;
            }
            //Damage Block
            float luckTime = Random.value;
            if(GameManager.Instance.player.permanentLuck/100 + myObj.luckPercent/100 < luckTime)
            {
                GameManager.Instance.DoDamage(1.5f * (GameManager.Instance.player.permStrength + myObj.strength));
            }
            else if(myObj.healPower != 0)
            {
                GameManager.Instance.player.currentHp += myObj.healPower;
            }
            else
            {
                GameManager.Instance.DoDamage(GameManager.Instance.player.permStrength + myObj.strength);
            }
            WriterScript.Instance.Debuging("You attacked the enemy with " + myObj.iconTitle + " Enemy : " + GameManager.Instance.enemy.health.ToString());
            //Damage Block Ends
            if(!myObj.infinite)
            {
                myObj.amount -=1;
            }
            if(myObj.effect != null)
            {
                GameObject effect = Instantiate(myObj.effect,new Vector2(31,422),Quaternion.identity);
                effect.transform.SetParent(GameObject.Find("War Panel").transform,false);
                Destroy(effect,1f);
            }
            GameManager.Instance.currentTurn = false;
        }
        if(myObj.amount <= 0)
        {
            GameManager.Instance.myPowerups.RemoveAt((int)itemNo);
            Destroy(this.gameObject);
        }
    }
    void UpdateText()
    {
        if(!myObj.infinite)
        {
            amount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if(myObj.amount > 1)
            {
                amount.text = myObj.amount.ToString();
            }
            if(myObj.amount == 1)
            {
                amount.text = "";
            }
        }
        if(myObj.infinite)
        {
            amount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            amount.text = "+++";
        }
    }
}
