using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
	{

	public float _minX = -1056f, _maxX = 1056;
	public int _minSize = 15, _maxSize = 30;
	public float _minSpeed, _maxSpeed;
	public float _minRotation, _maxRotation;
	public float _Lives;
	public Vector3 _Direction;

	public GameObject asteroidPrefab, enemyPrefab;
	public string sceneName;

	public TextMeshProUGUI WaveText;
	public float spawnTimer; 
	public float waveTimer;
	public int wave = 1;

	// Start is called before the first frame update
	void Start()
		{
		Invoke("SpawnEnemies", spawnTimer);
		Invoke("nextWave", waveTimer);
		}

	// Update is called once per frame
	void Update()
		{

		}

	void nextWave()
		{
		if (wave < 5)
			{ wave += 1; WaveText.text = "Wave "+wave;
			  Invoke("nextWave", waveTimer);
			}
		else
			{SceneManager.LoadScene("YouWon");}
		}

	void SpawnEnemies()
		{

		float pos__X = Random.Range(_minX, _maxX);

		if (Random.Range(0, 2) > 0)

			{

			float _tempSize = Random.Range(_minSize, _maxSize);
			float _tempSpeed = Random.Range(_minSpeed, _maxSpeed);
			float _tempRotation = Random.Range(_minRotation, _maxRotation);

			_Direction = new Vector3(0, -1, 0);
			_Lives = 1f;

			AsteroidFactory asteroidFactory = new AsteroidFactory(_tempRotation, _tempSpeed, _tempSize, _Lives, pos__X, _Direction);
			Invoke("SpawnEnemies", spawnTimer);
			}
		else
			{
			//Instantiate(enemyPrefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));
			//Invoke("SpawnEnemies", spawnTimer);
			}
		}
	}

