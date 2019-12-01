using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // settings
    [SerializeField] float speed = 0.1f;

    // references
    Material bgMaterial;

    // state
    Vector2 offset;

    private void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
       
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(0f, speed);
        bgMaterial.mainTextureOffset -= offset * Time.deltaTime;
    }
}
