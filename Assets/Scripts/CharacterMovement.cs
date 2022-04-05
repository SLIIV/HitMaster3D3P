using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private MovePoint[] _movePoints;
    [SerializeField] private Victory _victory;
    private int _currentPoint;
    private NavMeshAgent _movementAI;
    private Animator _animator;

    private void Start()
    {
        _currentPoint = 0;
        Enemy.OnDeath.AddListener(() => CheckForMovingAbility());
        _movementAI = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _movementAI.destination = _movePoints[0].transform.position;
    }

    private void Update()
    {
        _animator.SetBool("IsRunning", !(_movementAI.velocity == Vector3.zero));
        
        if (_currentPoint == _movePoints.Length - 1 && _movementAI.remainingDistance > 0 && _movementAI.remainingDistance < 1)
        {
            _victory.ShowVictory();
        }
    }

    private void CheckForMovingAbility()
    {
        if(_movePoints[_currentPoint].IsReadyForMove())
        {
            MoveToNewPoint();
        }
    }

    private void MoveToNewPoint()
    {
        if (_currentPoint < _movePoints.Length - 1)
        {
            _currentPoint++;
            _movementAI.destination = _movePoints[_currentPoint].transform.position;
            _movementAI.isStopped = false;
            CheckForMovingAbility();
            
        }
    }

    private void OnDestroy()
    {
        Enemy.OnDeath.RemoveAllListeners();
    }
}
