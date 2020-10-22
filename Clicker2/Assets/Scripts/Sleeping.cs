using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sleeping : MonoBehaviour
{
    public float goldRequirement = 2f;
    public float hpIncreaseSleep = 1f;
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{Sleep();});
    }
    void Sleep()
    {
        GameManager.Instance.RemoveGold(goldRequirement);
        GameManager.Instance.player.permanentHp += hpIncreaseSleep;
    }
}
