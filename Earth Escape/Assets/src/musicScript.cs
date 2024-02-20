using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicScript : MonoBehaviour
{
    public enum music {
        Passive,
        Game
    }

    music MusicType;

    public AudioClip[] clips;
    public AudioSource audio;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static music newState { get; set; }
    public void changeMusic(music game)
    {
        int index = 0;
        if (newState == music.Passive)
            index = 0;
        else
            index = 1;
        audio.clip = clips[index];
        audio.Play();
    }

}
