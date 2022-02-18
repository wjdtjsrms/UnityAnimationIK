using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour, IStateObserver<ExampleState>
{
    private Transform _yBot;
    private Animator _animator;

    private const float FOOTIKYVALUE = 0.1049219f;

    [SerializeField] private Transform _leftFootIK;
    [SerializeField] private Transform _rightFootIK;

    [SerializeField] private Transform _handShakePosition;
    [SerializeField] private Transform _pickPosition;
    [SerializeField] private Transform _footIKPosition;

    private void Awake()
    {
        _yBot = transform.GetChild(0);
        _animator = GetComponentInChildren<Animator>();
        AnimationRigginController.Instance._SubjectProvider.AddObserver(this);
    }

    public void Notify(ExampleState state)
    {
        ResetValue();

        switch (state)
        {
            case ExampleState.Handshake:
                SetTransform(_handShakePosition);
                break;
            case ExampleState.PickUp:
                SetTransform(_pickPosition);
                break;
            default:
                SetTransform(_footIKPosition);
                _animator.SetBool("IsMoving", true);
                _animator.SetFloat("CurrentSpeed", 1.0f);
                break;
        }
    }

    private void SetTransform(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    private void ResetValue()
    {
        transform.localScale = Vector3.one;
        _leftFootIK.position = new Vector3(_leftFootIK.position.x, FOOTIKYVALUE, _leftFootIK.position.z);
        _rightFootIK.position = new Vector3(_rightFootIK.position.x, FOOTIKYVALUE, _rightFootIK.position.z);
        _animator.SetBool("IsMoving", false);
        _animator.SetFloat("CurrentSpeed", 0.0f);
    }
}
