using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] float randomFactor = 0.3f;
    [SerializeField] int enemiesPerWave = 5;
    [SerializeField] float speed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints()
    {

        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    public Vector2 GetInitialWaypoint() {
        return pathPrefab.transform.GetChild(0).position;
    }
    public float GetSpawnTime() { return spawnTime; }
    public float GetRandomFactor() { return randomFactor; }
    public float GetSpeed() { return speed; }
    public int GetEnemiesPerWave() { return enemiesPerWave; }

}
