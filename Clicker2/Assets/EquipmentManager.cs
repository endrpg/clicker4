using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameDevTV.Saving;
public class EquipmentManager : MonoBehaviour,ISaveable
{
    private static EquipmentManager instance;
    public static EquipmentManager Instance
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
    void Awake()
    {
        instance = this;
    }
    public List<IconCreator> Equipment;
    public IconCreator head;
    public IconCreator chest;
    public IconCreator torso;
    public IconCreator shoes;
    public IconCreator equipment;
    public IconCreator shield;
    public IconCreator ring1;
    public IconCreator ring2;
    public GameObject headSp;
    public GameObject chestSp;
    public GameObject torsoSp;
    public GameObject shoesSp;
    public GameObject equipmentSp;
    public GameObject shieldSp;
    public GameObject ring1Sp;
    public GameObject ring2Sp;
    public GameObject slotPrefab;
    public GameObject parentPanel;
    void Update()
    {
        SpriteEx(headSp,head);
        SpriteEx(chestSp,chest);
        SpriteEx(torsoSp,torso);
        SpriteEx(shoesSp,shoes);
        SpriteEx(equipmentSp,equipment);
        SpriteEx(shieldSp,shield);
        SpriteEx(ring1Sp,ring1);
        SpriteEx(ring2Sp,ring2);
        foreach (var item in Equipment)
        {
            GameObject equipmentSlots = Instantiate(slotPrefab,transform.position,Quaternion.identity);
            equipmentSlots.transform.SetParent(parentPanel.transform,false);
            equipmentSlots.GetComponent<EquipmentScript>().meObj = item;
        }
    }
    void SpriteEx(GameObject sp,IconCreator ic)
    {
        if(ic != null)
        {
            Color c = sp.GetComponent<Image>().color;
            c.a = 1;
            sp.GetComponent<Image>().color = c;
            sp.GetComponent<Image>().sprite = ic.iconSprite;
        }
    }
    //Saving
    public object CaptureState()
    {
        Dictionary<string,object> data = new Dictionary<string,object>();
        data["ListEquipment"] = Equipment;
        data["headE"] = head;
        data["chestE"] = chest;
        data["torsoE"] = torso;
        data["shoesE"] = shoes;
        data["equipmentE"] = equipment;
        data["shieldE"] = shield;
        data["ring1E"] = ring1;
        data["ring2E"] = ring2;
        return data;
    }
    public void RestoreState(object state)
    {
        Dictionary<string,object> data = (Dictionary<string,object>) state;
        Equipment = (List<IconCreator>)data["ListEquipment"];
        head = (IconCreator)data["headE"];
        chest = (IconCreator)data["chestE"];
        torso = (IconCreator)data["torsoE"];
        shoes = (IconCreator)data["shoesE"];
        equipment = (IconCreator)data["equipmentE"];
        shield = (IconCreator)data["shieldE"];
        ring1 = (IconCreator)data["ring1E"];
        ring2 = (IconCreator)data["ring2E"];
    }

}
