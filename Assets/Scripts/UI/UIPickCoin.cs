using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPickCoin : UIBase
{
    [SerializeField] private Button _doPickUpBtn;

    public override void Init()
    {
        _doPickUpBtn.onClick.AddListener(AnimationRigginController.Instance._PlayerAction.DoPicKUp);
    }

    public override void Reset()
    {
        _doPickUpBtn.onClick.RemoveAllListeners();
    }

    public override void Notify(ExampleState state)
    {
        transform.GetChild(0).gameObject.SetActive(state == ExampleState.PickUp);
    }
}
