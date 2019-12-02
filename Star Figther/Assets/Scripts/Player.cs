using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float speed = 15f;
    [SerializeField] float xPadding = 0.8f;
    [SerializeField] float yPadding = 0.8f;

    // State
    float xMin;
    float yMin;
    float xMax;
    float yMax;
    Coroutine ShootingCoroutine;

    // References
    [SerializeField] GameObject laser;
    [SerializeField] float laserXOffset = 0.8f;
    [SerializeField] float laserYOffset = 1.6f;
    [SerializeField] float laserSpeed = 1f;
    [SerializeField] float laserDelay = 0.2f;


    private void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Fire1"))
        {
            ShootingCoroutine = StartCoroutine(ShootingSequence());
        }
        else if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(ShootingCoroutine);
        }
    }


    void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }

    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var newXpos =  Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        var deltaY= Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var newYpos =  Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXpos, newYpos);
    }

    void ShootLaser() {
        Vector2 laserPos = new Vector2(transform.position.x + laserXOffset, transform.position.y + laserYOffset);
        GameObject newLaser = Instantiate(laser, laserPos, transform.rotation);
        newLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        Destroy(newLaser, 3f);
    }


    IEnumerator ShootingSequence()
    {
        while(true)
        {
            ShootLaser();
            yield return new WaitForSeconds(laserDelay);
        }
    }
}
