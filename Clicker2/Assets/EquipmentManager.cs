using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentManager : MonoBehaviour
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

}
