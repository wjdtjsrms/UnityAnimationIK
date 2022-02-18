using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectProvider<T> : IStateSubject<T>, IDisposable where T : System.Enum
{
    #region Member
    private readonly List<IStateObserver<T>> stateObservers;
    private T _currentState;
    private T _prevState;
    #endregion

    #region Property
    public T CurrentState
    {
        get => _currentState;
        set
        {
            if (_currentState.Equals(value))
                return;

            _prevState = _currentState;
            _currentState = value;

            NotifyChangeState(value);
        }
    }

    public T PrevState => _prevState;
    #endregion

    #region Constructor
    public SubjectProvider()
    {
        stateObservers = new List<IStateObserver<T>>();
    }
    #endregion

    #region Method : Implements
    public void AddObserver(IStateObserver<T> observer)
    {
        if (!stateObservers.Contains(observer))
            stateObservers.Add(observer);
    }

    public void RemoveObserver(IStateObserver<T> observer)
    {
        if (stateObservers.Contains(observer))
            stateObservers.Remove(observer);
    }

    public void NotifyChangeState(T state)
    {
        stateObservers.ForEach((observer) => observer.Notify(state));
    }

    public void Dispose()
    {
        foreach (var observer in stateObservers.ToArray())
            RemoveObserver(observer);
        stateObservers.Clear();
    }
    #endregion
}