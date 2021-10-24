using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
	{

	public GameObject _Prefab;
	public Rigidbody _Rb;
	public float _minRotation, _maxRotation;
	public float _minSpeed, _maxSpeed;

	public float _Speed, _Rotation, _Lives, _Scale, _SpawnLocation;
	public Vector3 _Direction;

	public System.Action destroyed;

	void Start()
		{
		_Rb = GetComponent<Rigidbody>();
		_Rotation = Random.Range(_minRotation, _maxRotation);
		_Speed = Random.Range(_minSpeed, _maxSpeed);
		}
	// Update is called once per frame
	void Update()
		{

		_Rb.AddForce(_Direction * _Speed, ForceMode.Impulse);
	
		}

	private void OnTriggerEnter(Collider other)
		{
		this.destroyed.Invoke();
		Destroy(this.gameObject);
		}
	}