using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public Enemy[] EnemiesOnPoint;
    private int _deadEnemies = 0;

    private void Start()
    {
        Enemy.OnDeath.AddListener(() => CalculateDeadEnemies());
    }

    public void CalculateDeadEnemies()
    {
        _deadEnemies = 0;
        for(int i = 0; i < EnemiesOnPoint.Length; i++)
        {
            if(EnemiesOnPoint[i].Dead)
            {
                _deadEnemies++;
            }
        }
    }

    public bool IsReadyForMove()
    {
        return _deadEnemies == EnemiesOnPoint.Length;
    }

    private void OnDestroy()
    {
        Enemy.OnDeath.RemoveListener(() => CalculateDeadEnemies());
    }
}
