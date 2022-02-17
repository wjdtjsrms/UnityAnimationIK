using UnityEngine;

public class SingletonGameObject<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Static
    protected static T instance;
    public static T Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(T)) as T;

            if (instance == null)
                instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();

            return instance;
        }
    }
    #endregion
}

public abstract class Singleton<T> where T : class, new()
{
    #region Static

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();

            return instance;
        }
    }
    #endregion

    #region Constructor
    protected Singleton() { }
    #endregion
}