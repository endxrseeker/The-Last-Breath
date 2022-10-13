using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class o2Manager : MonoBehaviour
{
    public float currentOxygen;
    float maxOxygen = 100;

    public GameObject gameOver;
    public Text scoreText;
    public Image amount;

    float score = 0;
    int scoreint;

    public PlayerLook look;

    public void Start()
    {
        currentOxygen = maxOxygen;
    }

    public void Update()
    {
        currentOxygen -= Time.deltaTime;

        if(currentOxygen < 0)
        {
            die();
        }
        else gameOver.SetActive(false);

        amount.rectTransform.sizeDelta = new Vector2(25, currentOxygen);

        score += Time.deltaTime;
        scoreint = Mathf.RoundToInt(score);

        scoreText.text = scoreint.ToString();
    }

    public void o2PickUp()
    {
        currentOxygen = maxOxygen;
        score += 10;
    }

    public void die()
    {
        gameOver.SetActive(true);   
        look.isAlive = false;
        Time.timeScale = 0f;
    }
}
