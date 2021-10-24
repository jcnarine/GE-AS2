using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class EnemyFactory : MonoBehaviour
{
	public abstract Enemy GetEnemy();
}
