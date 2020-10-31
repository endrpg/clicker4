using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sleeping : MonoBehaviour
{
    public float goldRequirement = 2f;
    public float hpIncreaseSleep = 1f;
    public GameObject toShow;
    public GameObject toUnshow;
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
        toUnshow = GameObject.Find("Canvas (1)");
        toShow = GameObject.Find("Canvas");
    }
    void Sleep()
    {
        if(GameManager.Instance.hearts > 0)
        {
            GameManager.Instance.RemoveGold(goldRequirement);
            GameManager.Instance.player.permanentHp += hpIncreaseSleep;
        }
        else if(GameManager.Instance.hearts == 0)
        {
            GameManager.Instance.GameReset();
            toUnshow.SetActive(false);
            toShow.SetActive(true);
        }
        Destroy(transform.parent.gameObject);
        GameManager.Instance.InstantiateFalse();
    }
}
