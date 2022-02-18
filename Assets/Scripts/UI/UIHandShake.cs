using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandShake : UIBase
{
    [SerializeField] private Button _doHandShakeBtn;

    public override void Init()
    {
        _doHandShakeBtn.onClick.AddListener(() =>
        {
            var playerTarget = Vector3.Lerp(
                AnimationRigginController.Instance._PlayerAction.CharacterChest.position,
                AnimationRigginController.Instance._TestPlayerAction.CharacterChest.position, 0.48f);

            var testPlayerTarget = Vector3.Lerp(
                AnimationRigginController.Instance._TestPlayerAction.CharacterChest.position,
                AnimationRigginController.Instance._PlayerAction.CharacterChest.position, 0.48f);

            testPlayerTarget.y = playerTarget.y;

            AnimationRigginController.Instance._PlayerAction.DoShakeHands(playerTarget);
            AnimationRigginController.Instance._TestPlayerAction.DoShakeHands(testPlayerTarget);
        });

    }

    public override void Reset()
    {
        _doHandShakeBtn.onClick.RemoveAllListeners();
    }

    public override void Notify(ExampleState state)
    {
        transform.GetChild(0).gameObject.SetActive(state == ExampleState.Handshake);
    }
}
