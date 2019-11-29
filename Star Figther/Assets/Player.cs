using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float speed = 15f;
    [SerializeField] float xPadding = 1.6f;
    [SerializeField] float yPadding = 1.6f;

    // State
    float xMin;
    float yMin;
    float xMax;
    float yMax;
    

    private void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        MovePlayer();
    }


    void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
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
}
