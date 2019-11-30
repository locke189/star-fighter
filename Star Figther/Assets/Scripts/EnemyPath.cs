using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Configs
    WaveConfig waveConfig;
    List<Transform> waypoints;

    // State
    int index = 0;
    float speed = 1f;


    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        speed = waveConfig.GetSpeed();
        transform.position = waypoints[index].transform.position;
    }
    private void Update()
    {
        if (index <= waypoints.Count - 1)
        {
            MoveEnemy();
        }
        else {
            Destroy(gameObject);
        }
    }

    public void setWaveConfig(WaveConfig waveConfig) {
        this.waveConfig = waveConfig;
    }

    private void MoveEnemy() {
        var targetPosition = waypoints[index].transform.position;
        var movementDelta = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementDelta);

        if (transform.position == targetPosition)
        {
            index++;
        }
    }
}
