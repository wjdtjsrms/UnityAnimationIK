using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFeatureProvider : MonoBehaviour
{
    public enum MoveStyle { XAxis, YAxis, Free }

    [SerializeField] private MoveStyle _moveStype = MoveStyle.XAxis;
    [SerializeField] [Range(0f, 3f)] private float _moveSpeed = 0.0f;
    [SerializeField] private bool _useNavigation = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
