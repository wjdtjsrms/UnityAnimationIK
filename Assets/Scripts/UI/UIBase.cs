using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour,IStateObserver<ExampleState>
{
    private void Awake()
    {
        AnimationRigginController.Instance._SubjectProvider.AddObserver(this);
    }

    public abstract void Init();
    public abstract void Reset();
    public abstract void Notify(ExampleState state);
}
