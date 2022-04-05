using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public Enemy[] EnemiesOnPoint;

    public bool IsReadyForMove()
    {
        int deadEnemies = 0;
        for(int i = 0; i < EnemiesOnPoint.Length; i++)
        {
            if(EnemiesOnPoint[i].Dead)
            {
                deadEnemies++;
            }
        }
        if (deadEnemies == EnemiesOnPoint.Length)
            return true;
        return false;
    }
}
