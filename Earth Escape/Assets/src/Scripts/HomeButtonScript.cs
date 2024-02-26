 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnClickHomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
