using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    [SerializeField] private Transform _chestTransform;
    [SerializeField] private Transform _leftFootIKTransform;
    [SerializeField] private Transform _rightFootIKTransform;
    private Animator animator;

	public Transform targetPosition;
    public Transform coin;
	public Transform ikPosition;

    public Transform CharacterChest => _chestTransform;
    public Transform LeftFootIK => _leftFootIKTransform;
    public Transform RightFootIK => _rightFootIKTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.C) && targetPosition != null)
        {
            animator.SetTrigger("ShakeHands");
            ikPosition.position = targetPosition.position;
        }

        if (Input.GetKeyDown(KeyCode.V) && targetPosition != null)
        {
            animator.SetTrigger("PickUp");
            ikPosition.position = coin.position;
        }
    }

    public void DoShakeHands(Vector3 target)
    {
        animator.SetTrigger("ShakeHands");
        targetPosition.position = target;
        targetPosition.localPosition = new Vector3(targetPosition.localPosition.x+0.05f, targetPosition.localPosition.y, targetPosition.localPosition.z);

        ikPosition.position = targetPosition.position;
    }

    public void DoPicKUp()
    {
        animator.SetTrigger("PickUp");
        ikPosition.position = coin.position;
    }
}
