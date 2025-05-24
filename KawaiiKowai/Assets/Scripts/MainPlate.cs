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


    private void Start()
    {
        timeLeft = timeToEat;
    }
    private void Update()
    {
        if (occupant)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0)
        {
            manager.AddScore(occupant.points, transform.position);

            if (occupant.points == 0)
                badFood = true;
            else 
                badFood = false;

            Destroy(occupant.gameObject);

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
}
