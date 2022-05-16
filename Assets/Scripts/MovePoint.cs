using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesGameObjectsOnPoint; 
    private int _deadEnemies = 0;
    //����� �������, Enemy �� ����� ��� MovePoint, � MovePoint, �������� ������ ����������� ���������� �� ���������� ICalculateble
    private List<ICalculateble> _enemiesOnPoint = new List<ICalculateble>();

    private void Start()
    {
        for(int i = 0; i < _enemiesGameObjectsOnPoint.Length; i++)
        {
            _enemiesOnPoint.Add(_enemiesGameObjectsOnPoint[i].GetComponent<ICalculateble>());
            _enemiesOnPoint[i].OnDeath.AddListener(() => CalculateDeadEnemies());
        }
    }

    public void CalculateDeadEnemies()
    {
        _deadEnemies++;
    }

    public bool IsReadyForMove()
    {
        return _deadEnemies == _enemiesOnPoint.Count;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _enemiesOnPoint.Count; i++)
        {
            _enemiesOnPoint[i].OnDeath.RemoveListener(() => CalculateDeadEnemies());
        }
    }
}
