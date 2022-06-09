using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject go;
    public MonoBehaviour mono;

    [Button()]
    public void TurnOnGo()
    {
        go.SetActive(true);
        
        if(go.activeSelf)
        {}

        if (go.activeInHierarchy)
        {
        }
    }

    [Button()]
    public void TurnOffGo()
    {
        go.SetActive(false);
    }

    [Button()]
    public void TurnOnMono()
    {
        mono.enabled = true;
    }

    [Button()]
    public void TurnOffMono()
    {
        mono.enabled = false;

        if (mono.enabled)
        {
            
        }
    }
}