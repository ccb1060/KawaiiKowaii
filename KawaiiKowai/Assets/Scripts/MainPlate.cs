using Unity.VisualScripting;
using UnityEngine;

public class MainPlate : MonoBehaviour
{
    [SerializeField] Manager manager;
    private Sushi occupant;

    [SerializeField] float timeToEat;
    private float timeLeft;


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
            manager.AddScore(occupant.points);
            Destroy(occupant.gameObject);
            timeLeft = timeToEat;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sushi food = collision.gameObject.GetComponent<Sushi>();
        if (food && !occupant)
        {
            food.onPlate = true;
            food.gameObject.GetComponent<Rigidbody2D>().mass = 1000000;
            //food.returnPosition = transform.position;
            occupant = food;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Sushi>() == occupant)
        {
            occupant.onPlate = false;
            occupant = null;
            timeLeft = timeToEat;
        }
    }
}
