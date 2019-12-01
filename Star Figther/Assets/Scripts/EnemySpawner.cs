using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool loop = false;

    private IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loop);
    }

    private IEnumerator SpawnEnemiesForWave(WaveConfig waveConfig) {

        for (int i = 0; i < waveConfig.GetEnemiesPerWave(); i++) {
            var enemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetInitialWaypoint(), Quaternion.identity);
            enemy.GetComponent<EnemyPath>().setWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnTime());
        }
    }

    private IEnumerator SpawnAllWaves() {
        foreach (WaveConfig waveConfig in waveConfigs) {
            yield return StartCoroutine(SpawnEnemiesForWave(waveConfig));
        }
    }
}
