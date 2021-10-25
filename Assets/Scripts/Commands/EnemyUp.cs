using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUp : ICommand
{
    public void Execute()
    {
        EnemyLimiter.Increase();
        //EnemySpawner.enemyLimit++;
    }


    public void Undo()
    {
        EnemyLimiter.Decrease();
    }

}
