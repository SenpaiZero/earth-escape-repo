 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnClickHomeButton()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            musicScript musicScript = GameObject.FindGameObjectWithTag("Music").GetComponent<musicScript>();
            musicScript.changeMusic(musicScript.music.Game);
        }
        SceneManager.LoadScene(0);
    }
}
