using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextButton : MonoBehaviour
{
    public GameObject toShow;
    public GameObject toUnshow;
    public GameObject toShow1;
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
        if(GameManager.Instance.hearts == 0 && toShow1 != null)
        {
            toShow1.SetActive(true);
        }
    }
    void GoWar()
    {
        toShow.gameObject.SetActive(true);
        toUnshow.gameObject.SetActive(false);
        GameObject.Find("Store Manager").GetComponent<StoreManager>().RandomiseStore();
        if(GameManager.Instance.hearts == 0)
        {
            GameManager.Instance.GameReset();
        }
        Destroy(transform.parent.gameObject);
        GameManager.Instance.InstantiateFalse();
    }
}
