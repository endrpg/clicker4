using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentScript : MonoBehaviour
{
    Button me;
    public IconCreator meObj;
    void Start()
    {
        me = GetComponent<Button>();
    }
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{ContactEquipManager();});
    }
    void ContactEquipManager()
    {
        if((int)meObj.equipment == 3)
        {
            EquipmentManager.Instance.head = meObj;
        }
        else if((int)meObj.equipment == 4)
        {
            EquipmentManager.Instance.chest = meObj;
        }
        else if((int)meObj.equipment == 5)
        {
            EquipmentManager.Instance.torso = meObj;
        }
        else if((int)meObj.equipment == 6)
        {
            EquipmentManager.Instance.shoes = meObj;
        }
        else if((int)meObj.equipment == 7)
        {
            if(EquipmentManager.Instance.ring1 == null)
            {
                EquipmentManager.Instance.ring1 = meObj;
            }
            else if(EquipmentManager.Instance.ring2 == null)
            {
                EquipmentManager.Instance.ring2 = meObj;
            }
            else if(EquipmentManager.Instance.ring2 != null && EquipmentManager.Instance.ring1 != null)
            {
                int random = Random.Range(1,2);
                if(random == 1)
                {
                    EquipmentManager.Instance.ring1 = meObj;
                }
                else if(random == 2)
                {
                    EquipmentManager.Instance.ring2 = meObj;
                }
            }
        }
        else if((int)meObj.equipment == 1)
        {
            EquipmentManager.Instance.equipment = meObj;
        }
        else if((int)meObj.equipment == 2)
        {
            EquipmentManager.Instance.shield = meObj;
        }
    }
}
