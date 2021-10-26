using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ObjectFactory : MonoBehaviour
	{
	protected int hi;
	public abstract Object GetObject();
	}

