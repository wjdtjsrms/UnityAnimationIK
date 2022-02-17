using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ExampleState { Handshake, PickUp, FootIK }

public class AnimationRigginController : SingletonGameObject<AnimationRigginController>
{
    [SerializeField] public ExampleState _state;
    public SubjectProvider<ExampleState> _SubjectProvider { get; private set; } = new SubjectProvider<ExampleState>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
