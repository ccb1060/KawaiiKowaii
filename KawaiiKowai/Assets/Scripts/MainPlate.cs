using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlate : MonoBehaviour
{
    [SerializeField] Manager manager;
    private Sushi occupant;

    [SerializeField] float timeToEat;
    [SerializeField] float timeLeft;

    private bool badFood;

    [SerializeField] SoundManager soundManager;

    [SerializeField] List<GameObject> textPrefs;

    [SerializeField] GameObject timerPref;
    private GameObject timer;
    private EatingTimer timerScript; 

    private void Start()
    {
        timeLeft = timeToEat;

        //Instantiates a new timer
        spawnTimer();
        timer.SetActive(false);
    }
    private void Update()
    {
        if (occupant)
        {
            if (timer.activeSelf == false)
            {
                timer.SetActive(true);
            }

            timeLeft -= Time.deltaTime;
            updateIndicator(); 
        }

        if (timeLeft < 0)
        {
            manager.AddScore(occupant.points, transform.position);

            switch (occupant.rank)
            {
                case 1:
                    soundManager.Kawaii();
                    
                    break;
                case 2:
                    soundManager.Excellent();
                    break;
                case 3:
                    soundManager.Good();
                    break;
                case 4:
                    soundManager.Normal();
                    break;
                case 5:
                    soundManager.Kowai();
                    badFood = true;
                    break;
            }
            spawnText(occupant.rank);
            Destroy(occupant.gameObject);

            Debug.Log("Resetting timer after sushi eaten");
            timerScript.ResetTimer();
            timer.SetActive (false);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sushi food = collision.gameObject.GetComponent<Sushi>();
        if (food && !occupant)
        {
            Debug.Log("Entering");

            food.onPlate = true;
            food.returnPosition = transform.position;
            food.gameObject.GetComponent<Rigidbody2D>().mass = 1000000;
            //food.returnPosition = transform.position;
            occupant = food;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Sushi>() == occupant)
        {
            Debug.Log("Leaving");
            occupant = null;
            if (badFood)
            {
                timeLeft = 2 * timeToEat;
            }
            else
            {
                timeLeft = timeToEat;
            }

        }
    }

    void spawnText(int rank)
    {
        GameObject text = Instantiate(textPrefs[rank-1]);
        text.transform.position = Camera.main.ViewportToScreenPoint(new Vector3(.015f, 0, 0));
    }

    /// <summary>
    /// Updates the eating icon based on how much time is left to eat the sushi
    /// </summary>
    void updateIndicator()
    {

        float timeFraction = timeLeft / timeToEat;
        Debug.Log(timeFraction);

        if (timeFraction > 0.75f)
        {
            timerScript.ChangeImage(0);
        }
        else if (timeFraction > 0.5f)
        {
            timerScript.ChangeImage(1);
        }
        else if (timeFraction > 0.25f)
        {
            timerScript.ChangeImage(2);
        }
        else if (timeFraction > 0)
        {
            timerScript.ChangeImage(3);
        }
    }

    /// <summary>
    /// Spawns the timer at the start of the plate eating sequence
    /// </summary>
    void spawnTimer()
    {
        timer = Instantiate(timerPref);
        timerScript = timer.GetComponent<EatingTimer>();
    }
}
