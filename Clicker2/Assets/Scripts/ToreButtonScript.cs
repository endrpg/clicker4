using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ToreButtonScript : MonoBehaviour
{
    public IconCreator myStoreObj;
    Button me;
    public TextMeshProUGUI amount;
    public GameObject goldConfirmation;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
        amount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{Buy();});
        UpdateText();
    }
    void UpdateText()
    {
        amount.text = myStoreObj.maxAmount.ToString();
        if(myStoreObj.maxAmount == 1)
        {
            amount.text = "";
        }
    }
    void Buy()
    {
        GameObject goldCOnfirm = Instantiate(goldConfirmation,transform.position,Quaternion.identity);
        goldCOnfirm.transform.SetParent(GameObject.Find("Store Panel").transform,false);
        goldCOnfirm.transform.localPosition = new Vector2(0,0);
        goldCOnfirm.transform.GetChild(1).GetComponent<confirmScript>().myObj = myStoreObj;
        goldCOnfirm.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "This will cost you " +myStoreObj.price.ToString() + "G";
    }
}
