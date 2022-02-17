using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimationRigginController))]
[CanEditMultipleObjects]
public class AnimationRiggingEditor : Editor
{
    SerializedProperty _property;
    private ExampleState _currentState;

    public void OnEnable()
    {
        _property = serializedObject.FindProperty("_state");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        CheckNowState();
        serializedObject.ApplyModifiedProperties(); 
    }

    private void CheckNowState()
    {
        if((ExampleState)_property.intValue != _currentState)
        {
            _currentState = (ExampleState)_property.intValue;
            AnimationRigginController.Instance._SubjectProvider.CurrentState = _currentState;
        }     
    }
}
