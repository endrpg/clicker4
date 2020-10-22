using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RollingDice : MonoBehaviour
{
    public Sprite roll;
    public Sprite no1;
    public Sprite no2;
    public Sprite no3;
    public Sprite no4;
    public Sprite no5;
    public Sprite no6;
    public Button me;
    public Image meImg;
    public int randomNum;

    void Start()
    {
    }
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{HandlingButton();});
    }
    void HandlingButton()
    {
        if(meImg.sprite == roll)
        {
            randomNum = Random.Range(1,6);
            if(randomNum == 1)
            {
                meImg.sprite = no1;
            }
            else  if(randomNum == 2)
            {
                meImg.sprite = no2;
            }
            else if(randomNum == 3)
            {
                meImg.sprite = no3;
            }
            else  if(randomNum == 4)
            {
                meImg.sprite = no4;
            }
            else if(randomNum == 5)
            {
                meImg.sprite = no5;
            }
            else  if(randomNum == 6)
            {
                meImg.sprite = no6;
            }
        }
        Destroy(this.gameObject,2f);
    }
}
