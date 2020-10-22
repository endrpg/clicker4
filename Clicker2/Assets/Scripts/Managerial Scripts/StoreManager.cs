using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public List<IconCreator> allIcons;
    public List<IconCreator> selectedIcons;
    public GameObject parentPanel;
    public GameObject slotPrefab;
    public float tier1Prob;
    public float tier2Prob;
    public float tier3Prob;
    public float tier4Prob;
    public float tier5Prob;
    public List<IconCreator> tier1;
    public List<IconCreator> tier2;
    public List<IconCreator> tier3;
    public List<IconCreator> tier4;
    public List<IconCreator> tier5;
    void Start()
    {
        foreach(var item in allIcons)
        {
            if((int)item.tiers == 0)
            {
                tier1.Add(item);
            }
            else if((int)item.tiers == 1)
            {
                tier2.Add(item);
            }
            else if((int)item.tiers == 2)
            {
                tier3.Add(item);
            }
            else if((int)item.tiers == 3)
            {
                tier4.Add(item);
            }
            else if((int)item.tiers == 4)
            {
                tier5.Add(item);
            }
        }
        RandomiseStore();
    }
    public void RandomiseStore()
    {
        ProbabilityDistribution();
        foreach (var item in selectedIcons)
        {
            var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
            prefabInstantiated.transform.SetParent(parentPanel.transform,false);
            prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
            prefabInstantiated.GetComponent<ToreButtonScript>().myStoreObj = item;
        }
    }
    void ProbabilityDistribution()
    {
        for(int i = 0; i < 2;i+=1)
        {
            float prob = Random.value;
            if(prob >= tier1Prob)
            {
                CustomisedLoop(tier1,i);
            }
            else if(prob >= tier2Prob)
            {
                CustomisedLoop(tier2,i);
            }
            else if(prob >= tier3Prob)
            {
                CustomisedLoop(tier3,i);
            }
            else if(prob >- tier4Prob)
            {
                CustomisedLoop(tier4,i);
            }
            else if(prob >= tier5Prob)
            {
                CustomisedLoop(tier5,i);
            }
        }
    }
    void CustomisedLoop(List<IconCreator> tier,int i)
    {
        int presentIcon = Random.Range(0,tier.Count);
        IconCreator presentPrefab = tier[presentIcon];
        if(!selectedIcons.Contains(presentPrefab))
        {
            selectedIcons.Add(presentPrefab);
        }
        else
        {
            i-=1;
        }
    }
}
