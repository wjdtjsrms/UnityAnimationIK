using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ExampleState { Handshake, PickUp, FootIK }

public class AnimationRigginController : SingletonGameObject<AnimationRigginController>
{
    [SerializeField] private CharacterActions _playerCharacterAction;
    [SerializeField] private CharacterActions _testPlayerCharacterAction;
    [SerializeField] public ExampleState _state;

    public SubjectProvider<ExampleState> _SubjectProvider { get; private set; } = new SubjectProvider<ExampleState>();
    public CharacterActions _PlayerAction => _playerCharacterAction;
    public CharacterActions _TestPlayerAction => _testPlayerCharacterAction;
}
