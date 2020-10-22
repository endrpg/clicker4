using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StatManager : MonoBehaviour
{
    public TextMeshProUGUI hpValue;
    public TextMeshProUGUI strengthValue;
    public TextMeshProUGUI defenseValue;
    public TextMeshProUGUI luckValue;
    public TextMeshProUGUI accuracyValue;
    public TextMeshProUGUI evadeValue;
    public TextMeshProUGUI criticalPerValue;
    public TextMeshProUGUI criticalBonusValue;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Color heart1Img;
    public Color heart2Img;
    public Color heart3Img;
    // Start is called before the first frame update
    void Start()
    {
        heart1Img = heart1.GetComponent<Image>().color;
        heart2Img = heart2.GetComponent<Image>().color;
        heart3Img = heart3.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.hearts == 3)
        {
            heart1Img.a = 1f;
            heart2Img.a = 1f;
            heart3Img.a = 1f;
        }
        else if(GameManager.Instance.hearts == 2)
        {
            heart1Img.a = 1f;
            heart2Img.a = 1f;
            heart3Img.a = 0f;
        }
        else if(GameManager.Instance.hearts == 1)
        {
            heart1Img.a = 1f;
            heart2Img.a = 0f;
            heart3Img.a = 0f;
        }
        else if(GameManager.Instance.hearts == 0)
        {
            heart1Img.a = 0f;
            heart2Img.a = 0f;
            heart3Img.a = 0f;
        }
        hpValue.text = GameManager.Instance.player.permanentHp.ToString();
        strengthValue.text = GameManager.Instance.player.permStrength.ToString();
        defenseValue.text = GameManager.Instance.player.permDefense.ToString();
        luckValue.text = GameManager.Instance.player.permanentLuck.ToString();
        accuracyValue.text = GameManager.Instance.player.accuracyPercent.ToString() + "%";
        evadeValue.text = GameManager.Instance.player.evadePercent.ToString() + "%";
        criticalPerValue.text = GameManager.Instance.player.criticalAttackPercentage.ToString() + "%";
        criticalBonusValue.text = GameManager.Instance.player.criticalAttackMultiplier.ToString() + "X";
    }
}
