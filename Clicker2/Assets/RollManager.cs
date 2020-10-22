using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RollManager : MonoBehaviour
{
    private static RollManager instance;
    public static RollManager Instance
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
    public GameObject prefabRoll;
    void Awake()
    {
        instance = this;
    }
    public void InstantiateRoll()
    {
        GameObject dice = Instantiate(prefabRoll,transform.position,Quaternion.identity);
        dice.transform.SetParent(GameObject.Find("War panel").transform,false);
        RollingDice rollingDice = dice.GetComponent<RollingDice>();
        rollingDice.me = dice.GetComponent<Button>();
        rollingDice.meImg = dice.GetComponent<Image>();
        rollingDice.meImg.sprite = rollingDice.roll;
    }
}
