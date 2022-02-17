using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
	private Animator animator;
	public Transform targetPosition;
    public Transform coin;
	public Transform ikPosition;


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

	public void DisappearCoin()
	{
		if(targetPosition != null)
			targetPosition.gameObject.SetActive(false);
	}

	public void CoinAppear()
	{
		if(targetPosition != null)
			targetPosition.gameObject.SetActive(true);
	}
}
