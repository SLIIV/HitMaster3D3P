using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string RUNNING_ANIMATOR_PARAMETR = "IsRunning";
    private IAnimateble _IAnimateble;
    private Animator _animator;

    private void Start()
    {
        _IAnimateble = GetComponent<IAnimateble>();
        _animator = GetComponent<Animator>();
        _animator.SetBool(RUNNING_ANIMATOR_PARAMETR, true);
    }

    private void Update()
    {
        if(_IAnimateble.IsDestinatedToMovePoint())
        {
            Debug.Log("Stop");
            _animator.SetBool(RUNNING_ANIMATOR_PARAMETR, false);
        }
        if(_IAnimateble.IsReadyForMove())
        {
            Debug.Log("Run");
            _animator.SetBool(RUNNING_ANIMATOR_PARAMETR, true);
        }
    }
}
