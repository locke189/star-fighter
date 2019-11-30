using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] float randomness = 0.5f;
    // References
    [SerializeField] GameObject laser;
    [SerializeField] float laserXOffset = 0.8f;
    [SerializeField] float laserYOffset = 1.6f;
    [SerializeField] float laserSpeed = -1f;
    [SerializeField] float laserDelay = 0.2f;
    [SerializeField] float laserLifeTime = 3f;



    IEnumerator Start() {
        do
        {
            yield return StartCoroutine(ShootLaser());
        } while (true);
    }

    IEnumerator ShootLaser()
    {
        Vector2 laserPos = new Vector2(transform.position.x + laserXOffset, transform.position.y + laserYOffset);
        GameObject newLaser = Instantiate(laser, laserPos, transform.rotation);
        newLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        Destroy(newLaser, laserLifeTime);
        yield return new WaitForSeconds(CalculateRandomFireCadence());
    }

    float CalculateRandomFireCadence() {
        var randomFactor = Random.Range(-laserDelay * randomness, laserDelay * randomness);
        return laserDelay + randomFactor;
    }
}
