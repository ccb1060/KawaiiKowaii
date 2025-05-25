using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// This script controls all the major elements of the main game loop
/// </summary>
public class Manager : MonoBehaviour
{
    //The scene's Main Camera
    [SerializeField] Camera mainCam;
    //This is the amount of time the player has to earn points
    [SerializeField] float playTime;

    [SerializeField] GameObject textPref;

    [SerializeField] GameObject mainPlate;

    [SerializeField] Canvas canvas;

    //This is the amount of time left before the next sushi spawns
    private float cooldown = 0;

    //A list containing all the basic versions of the sushi types
    [SerializeField] List<GameObject> sushiPrefabs;

    //A list of all the countdown sushi
    [SerializeField] List<GameObject>? sushiCountdownPrefabs;

    [SerializeField] SoundManager soundManager;

    //Is the countdown happening?
    public bool sushiCountdown = false;

    //Where are we in the countdown
    private int index = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime -= Time.deltaTime;
        cooldown -= Time.deltaTime;

        //Sends player to the end screen when their time is up
        if(playTime < 0)
        { 

            SceneManager.LoadScene("Assets/Scenes/EndScreen.unity");
            
        }
        else if (playTime < 1)
        {
            soundManager.SoundOutOfTime();
        }

        //If it's time, then spawns a sushi and resets the cooldown
        if (cooldown <= 0)
        {
            //
            if (!sushiCountdown && sushiCountdownPrefabs.Count > 1)
            {
                SpawnSushiCountdown();
            }
            else
            {
                SpawnSushi();
            }

            cooldown += 2;
        }
    }

    private void SpawnSushiCountdown()
    {
        GameObject sushi;
        if (index == 0)
        {
            sushi = Instantiate(sushiCountdownPrefabs[index].gameObject);
            soundManager.Three();
            index++;
        }
        else if (index == 1)
        {
            sushi = Instantiate(sushiCountdownPrefabs[index].gameObject);
            soundManager.Two();
            index++;
        }
        else if (index == 2)
        {
            sushi = Instantiate(sushiCountdownPrefabs[index].gameObject);
            soundManager.One();
            index++;
        }
        else
        {
            sushi = Instantiate(sushiCountdownPrefabs[index].gameObject);
            soundManager.Go();
            sushiCountdown = true;
        }


        sushi.transform.position = mainCam.ViewportToScreenPoint(new Vector3(-.015f, .004f, 0));
    }

    /// <summary>
    /// Randomly selects a sushi and spawns it on the conveyor belt.
    /// </summary>
    private void SpawnSushi()
    {
        int rand = Random.Range(0, 100);
        GameObject sushi;
        if (rand < 10)
        {
            sushi = Instantiate(sushiPrefabs[4].gameObject);
        }
        else if (rand < 35)
        {
            sushi = Instantiate(sushiPrefabs[3].gameObject);
        }
        else if (rand < 65)
        {
            sushi = Instantiate(sushiPrefabs[2].gameObject);
        }
        else if (rand < 90)
        {
            sushi = Instantiate(sushiPrefabs[1].gameObject);
        }
        else
        {
            sushi = Instantiate(sushiPrefabs[0].gameObject);
        }

        sushi.transform.position = mainCam.ViewportToScreenPoint(new Vector3(-0.01f, .004f, 0));
    }

    public void AddScore(int input, Vector3 pos)
    {
        ScoreManager.AddScore(input);
        /*GameObject text = Instantiate(textPref, mainPlate.transform.position, mainPlate.transform.rotation, canvas.transform);
        text.GetComponent<TMP_Text>().text = input.ToString();
        text.transform.position = pos;
        text.transform.position = mainCam.ViewportToScreenPoint(new Vector3(0, -.01f, 0));*/
    }

    public void GoToMenu()
    {
        ScoreManager.InitGame();
        SceneManager.LoadScene("Assets/Scenes/TitleScreen.unity");
    }
}
