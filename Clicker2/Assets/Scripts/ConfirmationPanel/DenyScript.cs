using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DenyScript : MonoBehaviour
{
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{Deny();});
    }
    void Deny()
    {
        Destroy(transform.parent.gameObject);
    }
}
