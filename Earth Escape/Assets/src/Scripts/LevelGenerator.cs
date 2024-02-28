using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject solidPlatfom;
    public GameObject crackedPlatform;
    
    public GameObject coins;
    public GameObject treasure;
    public GameObject coinMult;
    public GameObject scoreMult;
    public GameObject trampoline;
    public GameObject jetPack;
    public new GameObject camera;
    public SpriteRenderer background;
    public Sprite tropos, stratos, mesos, thermos, exos;
    public GameObject hotAirBalloon, jettAirplain, meteor, ufo, sun;
    public GameObject bossWarning;

    public int level = 1;
    public int numberOfPlatforms = 20;
    public static float levelWidth = 3f;
    public float minY = 0.5f;
    public float maxY = 2.3f;

    #region Postions
    private Vector3 spawnPosition;
    private int platformPosition = 0;
    private int crackedPlatformPosition = 0;
    //private int coinPosition = 0;
    //private int trampolinePosition = 0;
    //private int jetPackPosition = 0;
    #endregion

    #region List of Generated GameObjects
    private readonly List<GameObject> solidPlatforms = new();
    private readonly List<GameObject> generatedCoins = new();
    private readonly List<GameObject> generatedtrampoline = new();
    private readonly List<GameObject> crackedPlatforms = new();
    private readonly List<GameObject> generatedJetPack = new();
    private readonly List<GameObject> generatedCoinMult = new();
    private readonly List<GameObject> generatedScoreMult = new();
    #endregion

    public static bool isBoss;
    private int generatedPlatformCounter = 0;
    public float zoomAmount = 2.0f;  // Adjust this value to control the zoom amount
    public float zoomDuration = 3.0f;  // Adjust this value to control the duration of the zoom

    public GameObject timerBoss;
    GameObject targetObject;
    private Camera mainCamera;
    private float originalFOV;

    public GameObject[] backgrounds;
    public static string mode { get; set; }

    void Start()
    {
        mainCamera = Camera.main;
        originalFOV = mainCamera.fieldOfView;
        isBoss = false;

        Scorer.addScore = 0;
        if (mode.Equals("troposphere"))
        {
            background.sprite = tropos;
            Scorer.addScore = 0;
        }
        if (mode.Equals("stratosphere"))
        {
            background.sprite = stratos;
            Scorer.addScore = 20000;
        }
        if (mode.Equals("mesosphere"))
        {
            background.sprite = mesos;
            Scorer.addScore = 50000;
        }
        if (mode.Equals("thermosphere"))
        {
            background.sprite = thermos;
            Scorer.addScore = 85000;
        }
        if (mode.Equals("exosphere"))
        {
            background.sprite = exos;
            Scorer.addScore = 200000;
        }


        if (camera == null)
        {
         camera = GameObject.FindWithTag("MainCamera");
        }

        // get camera width
        levelWidth = (camera.GetComponent<Camera>().orthographicSize * Screen.width / Screen.height) / 1.5f;
        
        //spawnPosition = new Vector3();

        for(int i = 0; i < 5; i++)
        {
            GameObject newPlaform = Instantiate(crackedPlatform, new Vector3(0, 0, 0), Quaternion.identity);
            newPlaform.SetActive(false);
            crackedPlatforms.Add(newPlaform);
        }


        //PlatformGenerator();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            if(i == 0)
            {
                spawnPosition.y += -2.5f;
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            } else
            {
                 spawnPosition.y += Random.Range(minY, maxY);
                 spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            }
           
          
  
            GameObject newPlatform = Instantiate(solidPlatfom, spawnPosition, Quaternion.identity);
            solidPlatforms.Add(newPlatform);
            int random = Random.Range(0, 100);
            // 20% can spawn a coin
            if (random <= 20)
            {
                //10% chance for treasure
                int treasureRand = Random.Range(0, 100);
                if(treasureRand <= 10)
                {
                    GameObject newCoin = Instantiate(treasure, new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z), Quaternion.identity);
                    newCoin.transform.parent = newPlatform.transform;
                    generatedCoins.Add(newCoin);
                }
                else
                {
                    GameObject newCoin = Instantiate(coins, new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z), Quaternion.identity);
                    newCoin.transform.parent = newPlatform.transform;
                    generatedCoins.Add(newCoin);
                }

                // make a child of the platform
               
            }
            // 10% chance to make a trampoline
            else if (random <= 30)
            {
                GameObject newTrampoline = Instantiate(trampoline, new Vector3(spawnPosition.x, spawnPosition.y + 0.5f, spawnPosition.z), Quaternion.identity);
                newTrampoline.transform.parent = newPlatform.transform;
                generatedtrampoline.Add(newTrampoline);
                
            } else if( random <= 40)
            {
                
                 GameObject newJetPack = Instantiate(jetPack, new Vector3(spawnPosition.x, spawnPosition.y + 0.6f, spawnPosition.z), Quaternion.identity);
                 newJetPack.transform.parent = newPlatform.transform;
                 generatedJetPack.Add(newJetPack);
            }
            else if (random <= 45)
            {

                GameObject newCoinMult = Instantiate(coinMult, new Vector3(spawnPosition.x, spawnPosition.y + 0.6f, spawnPosition.z), Quaternion.identity);
                newCoinMult.transform.parent = newPlatform.transform;
                generatedCoinMult.Add(newCoinMult);
            }
            else if (random <= 50 )
            {

                GameObject newScoreMult = Instantiate(scoreMult, new Vector3(spawnPosition.x, spawnPosition.y + 0.6f, spawnPosition.z), Quaternion.identity);
                newScoreMult.transform.parent = newPlatform.transform;
                generatedScoreMult.Add(newScoreMult);
            }




        }

        generatedPlatformCounter = numberOfPlatforms;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        if (PositionChecker(solidPlatforms[platformPosition].transform.position))
        {

            // move the platform to the top of the screen
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);

            // 20% chance to spawn a cracked platform
            int random = Random.Range(0, 100);
            if (random < 20 && PositionChecker(crackedPlatforms[crackedPlatformPosition].transform.position))
            {
                crackedPlatforms[crackedPlatformPosition].transform.position = spawnPosition;
                crackedPlatforms[crackedPlatformPosition].SetActive(true);
                crackedPlatformPosition++;
                if (crackedPlatformPosition >= crackedPlatforms.Count)
                {
                    crackedPlatformPosition = 0;
                }
            }
            else
            {
                solidPlatforms[platformPosition].transform.position = spawnPosition;
                solidPlatforms[platformPosition].SetActive(true);
                if (random < 50)
                {
                    solidPlatforms[platformPosition].GetComponent<Platform>().isMovable = true;
                }
                else
                {
                    solidPlatforms[platformPosition].GetComponent<Platform>().isMovable = false;
                }
              
                platformPosition++;
                if (platformPosition >= solidPlatforms.Count)
                {
                    platformPosition = 0;
                }
            }
            // if the platform has a child
            if (solidPlatforms[platformPosition].transform.childCount > 0)
            {
                solidPlatforms[platformPosition].transform.GetChild(0).gameObject.SetActive(true);
            }


            generatedPlatformCounter++;


            if(generatedPlatformCounter % 40 == 0)
            {
                level++;
            }
        }

    }

    private void Update()
    {
        float height = Scorer.score;
        if(mode.Equals("freeplay"))
        {
            if(height > 20000 && height < 50000)
            {
                background.sprite = stratos;
            }
            else if(height > 50000 && height < 85000)
            {
                background.sprite = mesos;
            }
            else if(height > 85000 && height < 200000)
            {
                background.sprite = thermos;
            }
            else if(height > 200000)
            {
                background.sprite = exos;
            }
        }
        else
        {
            if (mode.Equals("troposphere"))
            {
                if(height >= 20000)
                {
                    //spawnBoss(sun);
                    //wag na daw ilagay
                }
            }
            if (mode.Equals("stratosphere"))
            {
                if (height >= 50000)
                {
                    //spawnBoss(jettAirplain);
                    //wag na daw ilagay
                }
            }
            if (mode.Equals("mesosphere"))
            {
                if (height >= 85000)
                {
                    //spawnBoss(meteor);
                    spawnBoss(hotAirBalloon);
                }
            }
            if (mode.Equals("thermosphere"))
            {
                if (height >= 200000)
                {
                    spawnBoss(ufo);
                }
            }
            if (mode.Equals("exosphere"))
            {
                if (height >= 400000)
                {
                    spawnBoss(sun);
                }
            }
        }
    }
    void spawnBoss(GameObject boss)
    {
        if (isBoss) return;
        isBoss = true;

        //mainCamera.GetComponent<CameraUpward>().enabled = false;
        // mainCamera.GetComponent<CameraFollow>().enabled = false;

        StartCoroutine(spawn(boss));
    }
    IEnumerator spawn(GameObject boss)
    {
        Instantiate(bossWarning, mainCamera.transform.position, Quaternion.identity);
        GameObject timerClone = Instantiate(timerBoss);
        bossTimer bClass = timerClone.GetComponentInChildren<bossTimer>();
        if (mode.Equals("mesosphere"))
            bossTimer.setBossName = bClass.hotair();
        else if (mode.Equals("thermosphere"))
            bossTimer.setBossName = bClass.ufo();
        else if (mode.Equals("exosphere"))
            bossTimer.setBossName = bClass.sun();
        else
            bossTimer.setBossName = "";
        yield return new WaitForSeconds(5f);
        GameObject clone = Instantiate(boss, mainCamera.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(30f);
        //animate boss death / dialogue
    }
    private bool PositionChecker(Vector3 position)
    {
        return camera.transform.position.y - 10 > position.y;
    }


}
