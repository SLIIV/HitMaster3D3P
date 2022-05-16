using UnityEngine;
using UnityEngine.AI;

public interface IAnimateble
{
    public bool IsDestinatedToMovePoint();
    public bool IsReadyForMove();
}

public interface IVictory
{
    public bool IsDestinatedToFinalMovePoint();
}

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovement : MonoBehaviour, IVictory, IAnimateble
{
    [SerializeField] private MovePoint[] _movePoints;
    private int _currentPoint = 0;
    private bool _isRunning;
    private NavMeshAgent _movementAI;

    private void Start()
    {
        _isRunning = true;
        _movementAI = GetComponent<NavMeshAgent>();
        _movementAI.destination = _movePoints[0].transform.position;
    }

    private void LateUpdate()
    {
        CheckForMovementAbility();
    }

    public void CheckForMovementAbility()
    {
        if (IsReadyForMove())
        {
            MoveToNewPoint();
        }
    }

    public bool IsReadyForMove()
    {
        return _movePoints[_currentPoint].IsReadyForMove();
    }

    public void MoveToNewPoint()
    {
        if (_currentPoint < _movePoints.Length - 1)
        {
            _isRunning = true;
            _currentPoint++;
            _movementAI.destination = _movePoints[_currentPoint].transform.position;
            _movementAI.isStopped = false;
            CheckForMovementAbility();
        }
    }

    public bool IsDestinatedToFinalMovePoint()
    {
        if (_movementAI.remainingDistance > 0 && _movementAI.remainingDistance < 1 && _currentPoint == _movePoints.Length - 1)
            return true;
        return false;
    }

    public bool IsDestinatedToMovePoint()
    {
        if (_movementAI.remainingDistance >= 0 && _movementAI.remainingDistance < 1 && _isRunning)
        {
            _isRunning = false;
            return true;
        }
        return false;
    }
}
