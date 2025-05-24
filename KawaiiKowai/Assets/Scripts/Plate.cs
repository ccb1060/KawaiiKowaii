using UnityEngine;

public class Plate : MonoBehaviour
{

    private Sushi occupant;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Sushi food = collision.gameObject.GetComponent<Sushi>();
        if (food && !occupant)
        {
            Debug.Log("Entering");

            food.onPlate = true;
            food.gameObject.GetComponent<Rigidbody2D>().mass = 1000000;
            food.returnPosition = transform.position;
            occupant = food;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Sushi>() == occupant)
        {
            Debug.Log("Leaving");
            occupant = null;
        }
    }
}
