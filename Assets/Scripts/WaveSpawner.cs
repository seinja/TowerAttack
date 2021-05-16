using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeDelay = 5f;
    private float countdown = 1f;

    private int waveNumver = 1;

    public Text waveCountDownText;

    private void Update()
    {

        if (PlayerStats.Lives > 0)
        {
            // По срабатыванию таймера запускаем куротину, которая спавнит врагов.
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeDelay;
            }


            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            waveCountDownText.text = string.Format("{0:00:00}", countdown);
        }
       
        
    }

    // Куротина, которая спавнит волны врагов, каждая новая итерация увеличивает кол-во врагов на 1
    IEnumerator SpawnWave() 
    {
        for (int i = 0; i < waveNumver; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumver++;

    }

    // Спавн врагов
    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
