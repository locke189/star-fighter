using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{

    [SerializeField] AudioClip music;

    private void Awake()
    {
        int gameInstances = FindObjectsOfType<MusicController>().Length;
        if (gameInstances > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        Debug.Log(music.name);
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}
