using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
    private Animator animator;
    private const string IS_FLYING = "IsFlying";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_FLYING, Bird.Instance.GetIsFlying());
    }
}
