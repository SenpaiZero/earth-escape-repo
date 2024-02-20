using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]


public class Player : MonoBehaviour
{
    enum CharacterState
    {
        Idle,
        JumpUp,
        JumpRight,
        JumpLeft,
        Jetpack
    }

    public AnimatorController[] chars;
    public Sprite[] Defchars;

    public float movementSpeed = 10f;
    public float touchSensitivity = 4f;
    public int jetpackTime = 2;
    private Rigidbody2D rb;
    private float movement = 0f;
    private bool hasJetPack = false;
    public Image scoreMult, coinMult;

    float score;
    CharacterState currentState = CharacterState.Idle;
    public GameObject deadPopup;
    public Text scoreTxt;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = chars[playerPrefScript.getCharacter()];

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = Defchars[playerPrefScript.getCharacter()];

        
    }

    // Update is called once per frame
    void Update()
    {
      
       movement = Input.GetAxis("Horizontal") * movementSpeed;

        // touch input


        score = Scorer.score;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPosition.x > 0)
            {
                movement = touchSensitivity;
            }
            else if (touchPosition.x < 0)
            {
                movement = -touchSensitivity;
            }
        }


    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        if (hasJetPack)
        {
            // change y character position

            rb.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y + 0.3f);

            return;
        }

        if (velocity.x > 0)
        {
            ChangeAnimationState(CharacterState.JumpRight);
        }
        else if (velocity.x < 0)
        {
            ChangeAnimationState(CharacterState.JumpLeft);
        } else
        {
            if (velocity.y > 0)
            {
                ChangeAnimationState(CharacterState.JumpUp);
            } else
            {
                ChangeAnimationState(CharacterState.Idle);
                
            }
                
           
        }


    }
    
    private void ChangeAnimationState(CharacterState newState) {
        if (currentState == newState) return;

        anim.Play(newState.ToString());

        currentState = newState;

    }

    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jetpack"))
        {
            hasJetPack = true;
            collision.gameObject.SetActive(false);
            // jet pack for 2 secs
            ChangeAnimationState(CharacterState.Jetpack);
            StartCoroutine(ActiveCoroutine());
        
        }
        else if(collision.gameObject.CompareTag("coinMult"))
        {
            StartCoroutine(coinMultTrigger(collision.gameObject));
        }
        else if(collision.gameObject.CompareTag("scoreMult"))
        {
            StartCoroutine(scoreMultTrigger(collision.gameObject));
        }
        else if(collision.gameObject.CompareTag("boss"))
        {
            Time.timeScale = 0f;
            //popup
            scoreTxt.text = score.ToString("0");
            deadPopup.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boss"))
        {
            Time.timeScale = 0f;
            //popup
            scoreTxt.text = score.ToString("0");
            deadPopup.SetActive(true);
        }
    }

    IEnumerator coinMultTrigger(GameObject gm)
    {
        StoragePrefs.coinMult = 2;
        Destroy(gm);

        coinMult.fillAmount = 1f;
        while(coinMult.fillAmount >= 0)
        {
            coinMult.fillAmount -= 0.1f;
            yield return new WaitForSeconds(1);
        }
        StoragePrefs.coinMult = 1;
        coinMult.fillAmount = 0f;
    }
    IEnumerator scoreMultTrigger(GameObject gm)
    {
        StoragePrefs.scoreMult = 2;
        Destroy(gm);

        scoreMult.fillAmount = 1f;
        while (scoreMult.fillAmount >= 0)
        {
            scoreMult.fillAmount -= 0.1f;
            yield return new WaitForSeconds(1);
        }
        StoragePrefs.scoreMult = 1;
        scoreMult.fillAmount = 0f;
    }
    IEnumerator ActiveCoroutine()
    {
         yield return new WaitForSeconds(jetpackTime);
         hasJetPack = false;
         ChangeAnimationState(CharacterState.Idle);

    }






}
