using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject : MonoBehaviour,IStateObserver<ExampleState>
{
    private MeshRenderer _meshRender;
    [SerializeField] private Transform _startPosition;

    private void Awake()
    {
        _meshRender = GetComponent<MeshRenderer>();
        _meshRender.enabled = false;
        AnimationRigginController.Instance._SubjectProvider.AddObserver(this);
    }

    public void Notify(ExampleState state)
    {
        if(state == ExampleState.PickUp)
        {
            transform.position = _startPosition.position;
            transform.rotation = _startPosition.rotation;
        }
        _meshRender.enabled = state == ExampleState.PickUp;
    }
}
