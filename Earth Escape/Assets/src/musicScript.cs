using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicScript : MonoBehaviour
{
    public AudioSource passiveBgm;
    public AudioSource gameBgm;

    private void Start()
    {
        GameObject[] musics = GameObject.FindGameObjectsWithTag("Music");
        if (musics.Length > 1)
        {
            for (int i = 1; i < musics.Length; i++)
            {
                Destroy(musics[i]);
            }
        }

        DontDestroyOnLoad(gameObject);
        StartCoroutine(changeMusic());
    }
    IEnumerator changeMusic()
    {
        while(true)
        {
            string scene = SceneManager.GetActiveScene().name;
            if (scene.Equals("MainMenus"))
            {
                if (!passiveBgm.isPlaying)
                {
                    passiveBgm.Play();
                    gameBgm.Stop();
                }
            }
            else if (scene.Equals("InGameScene"))
            {
                if (!gameBgm.isPlaying)
                {
                    gameBgm.Play();
                    passiveBgm.Stop();
                }
            }

            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

}
