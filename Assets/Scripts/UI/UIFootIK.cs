using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFootIK : UIBase
{
    [SerializeField] private Button _upRightLegsBtn;
    [SerializeField] private Button _downRightLegBtn;
    [SerializeField] private Button _upLeftLegsBtn;
    [SerializeField] private Button _downLeftLegBtn;

    public override void Init()
    {
        var rightFootIK = AnimationRigginController.Instance._PlayerAction.RightFootIK;
        var leftFootIK = AnimationRigginController.Instance._PlayerAction.LeftFootIK;

        _upRightLegsBtn.onClick.AddListener(() => { rightFootIK.position = SetNewYPosition(rightFootIK.position, 0.1f); });

        _downRightLegBtn.onClick.AddListener(() =>
        {
            if (rightFootIK.position.y < 0f)
                return;
            rightFootIK.position = SetNewYPosition(rightFootIK.position, -0.1f);
        });

        _upLeftLegsBtn.onClick.AddListener(() => { leftFootIK.position = SetNewYPosition(leftFootIK.position, 0.1f); });
        _downLeftLegBtn.onClick.AddListener(() =>
        {
            if (leftFootIK.position.y < 0f)
                return;
            leftFootIK.position = SetNewYPosition(leftFootIK.position, -0.1f);
        });

        Vector3 SetNewYPosition(Vector3 pos, float value) => new Vector3(pos.x, pos.y + value, pos.z);
    }

    public override void Reset()
    {
        _upRightLegsBtn.onClick.RemoveAllListeners();
        _downRightLegBtn.onClick.RemoveAllListeners();
        _upLeftLegsBtn.onClick.RemoveAllListeners();
        _downLeftLegBtn.onClick.RemoveAllListeners();
    }

    public override void Notify(ExampleState state)
    {
        transform.GetChild(0).gameObject.SetActive(state == ExampleState.FootIK);
    }
}
