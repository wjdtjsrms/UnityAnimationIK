using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonGameObject<UIManager>
{
    private void Awake()
    {
        foreach(var child in transform.GetComponentsInChildren<UIBase>())
        {
            child.Init();
        }
    }
}
