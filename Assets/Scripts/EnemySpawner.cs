using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;

    private int nextWaveIndex = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    private float checkEnemyAliveRate = 1f; // Every second we check if any Enemy left

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // Check Enemies Alive
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }

            else { return; }

        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWaveIndex]));
            }

        }

        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if(nextWaveIndex + 1 > waves.Length - 1)
        {
            nextWaveIndex = 0;
            Debug.Log("All Waves Complete!");
            return;
        }

        nextWaveIndex++;
    }

    bool EnemyIsAlive()
    {
        checkEnemyAliveRate -= Time.deltaTime;

        if(checkEnemyAliveRate <= 0)
        {
            checkEnemyAliveRate = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Enemy spawned" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}