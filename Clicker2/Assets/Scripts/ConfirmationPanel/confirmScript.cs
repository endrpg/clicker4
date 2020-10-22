using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class confirmScript : MonoBehaviour
{
    public IconCreator myObj;
    AudioSource audioSource;
    public AudioClip cashRegister;
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        me = GetComponent<Button>();
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{Confirm();});
        audioSource = GetComponent<AudioSource>();
    }
    void Confirm()
    {
        if(GameManager.Instance.ReturnGold() >= myObj.price)
        {
            GameManager.Instance.RemoveGold(myObj.price);
            if((int)myObj.equipment == 0)
            {
                if(!GameManager.Instance.myPowerups.Contains(myObj))
                {
                    GameManager.Instance.myPowerups.Add(myObj);
                    myObj.amount += myObj.maxAmount;
                }
                else if(GameManager.Instance.myPowerups.Contains(myObj))
                {
                    myObj.amount += myObj.maxAmount;
                }
            }
            else if((int)myObj.equipment > 0 && !(EquipmentManager.Instance.Equipment.Contains(myObj)))
            {
                EquipmentManager.Instance.Equipment.Add(myObj);
            }
            else if((int)myObj.equipment > 0 && EquipmentManager.Instance.Equipment.Contains(myObj))
            {
                GameManager.Instance.AddGold(myObj.price);
            }
            if(cashRegister != null)
            {
                audioSource.PlayOneShot(cashRegister,1f);
            }
            Destroy(transform.parent.gameObject,1f);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
