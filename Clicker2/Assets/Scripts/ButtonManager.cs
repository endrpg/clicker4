using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    
    [SerializeField]GameObject show1;
    [SerializeField]GameObject show2;
    [SerializeField]GameObject show3;
    [SerializeField]GameObject unshow1;
    [SerializeField]GameObject unshow2;
    [SerializeField]GameObject unshow3;
    [SerializeField]GameObject unshow4;
    public bool equipment = false;
    private Button myButton;
    void Start()
    {
        myButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        myButton.onClick.RemoveAllListeners();
        myButton.onClick.AddListener(delegate{ShowUnshow();});
    }
    void ShowUnshow()
    {
        ConditionalShow(show1);
        ConditionalShow(show2);
        ConditionalShow(show3);
        ConditionalUnshow(unshow1);
        ConditionalUnshow(unshow2);
        ConditionalUnshow(unshow3);
        ConditionalUnshow(unshow4);
    }
    void ConditionalShow(GameObject show)
    {
        if(show != null)
        {
            if(equipment == true)
            {
                EquipmentManager.Instance.Draw();
            }
            show.SetActive(true);
        }
    }
    void ConditionalUnshow(GameObject unshow)
    {
        if(unshow != null)
        {
            unshow.SetActive(false);
        }
    }
}
