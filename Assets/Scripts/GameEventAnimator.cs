using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class GameEventAnimator : MonoBehaviour
{
    public string Parameter;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetBool(bool value)
    {
        animator.SetBool(Parameter, value);
    }


    public void SetFloat(float value)
    {
        animator.SetFloat(Parameter, value);
    }


    public void SetInt(int value)
    {
        animator.SetInteger(Parameter, value);
    }


    public void SetTrigger()
    {
        animator.ResetTrigger(Parameter);
        animator.SetTrigger(Parameter);
    }

    public void SetParameter(string parameter)
    {
            Parameter = parameter;
    }
}
