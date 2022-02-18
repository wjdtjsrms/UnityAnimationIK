using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerObject : MonoBehaviour, IStateObserver<ExampleState>
{
    [SerializeField] private Transform _yBotMesh;
    [SerializeField] private Transform _startPosition;

    private void Awake()
    {
        AnimationRigginController.Instance._SubjectProvider.AddObserver(this);
    }

    public void Notify(ExampleState state)
    {
        if (state == ExampleState.Handshake)
        {
            transform.localScale = Vector3.one;
            transform.position = _startPosition.position;
            transform.rotation = _startPosition.rotation;
        }
        _yBotMesh.gameObject.SetActive(state == ExampleState.Handshake);
    }
}
