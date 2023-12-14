using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configs")]
    public GameObject[] enemies;
    public Transform cannon;
    float first_wave_duration = 11f;
    float second_wave_duration = 24f;
    float third_wave_duration = 37f;
    float timer;
    void Start()
    {
        InvokeRepeating("FirstWave", 1f, 2f);
        InvokeRepeating("SecondWave", 12f, 1.5f);
        InvokeRepeating("ThirdWave", 25f, 1f);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > first_wave_duration && timer < first_wave_duration + 2)
        {
            Debug.Log("FIRST WAVE DONE!");
            EndWave("FirstWave");
        }
        else if (timer > second_wave_duration && timer < second_wave_duration + 2)
        {
            Debug.Log("SECOND WAVE DONE!");
            EndWave("SecondWave");
        }
        else if (timer > third_wave_duration && timer < third_wave_duration + 2)
        {
            Debug.Log("SECOND WAVE DONE!");
            EndWave("ThirdWave");
        }
        else return;
    }

    void EndWave(string WaveNumber)
    {
        if (WaveNumber == "FirstWave")
        {
            Debug.Log("FIRST WAVE DONE!");
            CancelInvoke("FirstWave");
            return;
        }
        else if (WaveNumber == "SecondWave")
        {
            Debug.Log("SECOND WAVE DONE!");
            CancelInvoke("SecondWave");
            return;
        }
        else if (WaveNumber == "ThirdWave")
        {
            Debug.Log("THIRD WAVE DONE!");
            CancelInvoke("ThirdWave");
            return;
        }
    }

    private void FirstWave()
    {
        Debug.Log("First Wave Start");
        InstantiateEnemy();
    }
    private void SecondWave()
    {
        Debug.Log("Second Wave Start");
        InstantiateEnemy();
    }
    private void ThirdWave()
    {
        Debug.Log("Third Wave Start");
        InstantiateEnemy();
    }
    private void InstantiateEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 randomSpawnPosition = new(transform.position.x + Random.Range(-5, 6), transform.position.y + 1f, transform.position.z);

        Instantiate(enemies[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}
