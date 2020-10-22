using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WriterScript : MonoBehaviour
{
    private static WriterScript instance;
    public static WriterScript Instance
    {
        get
        {
            if(instance == null)
            {
            }
            return instance;
        }
    }
    public GameObject parentpanel;
    public GameObject textpanel;
    void Awake()
    {
        instance = this;
    }
    public void Debuging(string textToWrite)
    {
        GameObject instantiated = Instantiate(textpanel,transform.position,Quaternion.identity);
        instantiated.transform.SetParent(parentpanel.transform,false);
        instantiated.transform.SetSiblingIndex(0);
        TextMeshProUGUI myText = instantiated.GetComponent<TextMeshProUGUI>();
        myText.text = textToWrite;
    }
}
