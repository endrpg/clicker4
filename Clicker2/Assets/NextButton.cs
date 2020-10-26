using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextButton : MonoBehaviour
{
    public GameObject toShow;
    public GameObject toUnshow;
    Button me;
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{GoWar();});
    }
    void GoWar()
    {
        toShow.SetActive(true);
        toUnshow.SetActive(false);
        if(GameManager.Instance.hearts == 0)
        {
            GameManager.Instance.GameReset();
        }
        Destroy(transform.parent.gameObject);
        GameManager.Instance.InstantiateFalse();
    }
}
