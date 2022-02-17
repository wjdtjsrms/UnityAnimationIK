using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerObject : MonoBehaviour, IStateObserver<ExampleState>
{
    private Transform _yBot;
    [SerializeField] private Transform _startPosition;

    private void Awake()
    {
        _yBot = transform.GetChild(0);
        AnimationRigginController.Instance._SubjectProvider.AddObserver(this);
    }

    public void Notify(ExampleState state)
    {
        if(state == ExampleState.Handshake)
        {
            transform.position = _startPosition.position;
            transform.rotation = _startPosition.rotation;
        }
        _yBot.gameObject.SetActive(state == ExampleState.Handshake);
    }
}
