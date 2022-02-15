using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CharacterMoveControl : MonoBehaviour
{
    private float smoothDirection;
    private float velocityDir = 0.0F;
    private float smoothSpeed;
    private float velocitySpeed = 0.0F;
    private bool inLocomotion;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        smoothDirection = 0.1f;
        smoothSpeed = 0.1f;
        inLocomotion = false;
    }

    void Update()
    {
        if ((anim.GetFloat("Direction") > 0.1f || anim.GetFloat("Direction") < -0.1f) || (anim.GetFloat("Speed") > 0.1f || anim.GetFloat("Speed") < -0.1f))
        {
            inLocomotion = true;
        }
        else
        {
            inLocomotion = false;
        }

        float h = Input.GetAxis("Horizontal");
        h = Mathf.SmoothDamp(anim.GetFloat("Direction"), h, ref velocityDir, smoothDirection);
        anim.SetFloat("Direction", h);

        float v = Input.GetAxis("Vertical");
        v = Mathf.SmoothDamp(anim.GetFloat("Speed"), v, ref velocitySpeed, smoothSpeed);
        anim.SetFloat("Speed", v);
    }
}
