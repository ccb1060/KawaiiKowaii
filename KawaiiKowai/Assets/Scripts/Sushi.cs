using UnityEngine;


/// <summary>
/// This script controls the behavior of each sushi object
/// </summary>
public class Sushi : MonoBehaviour
{
    //How fast the sushi move
    [SerializeField] float speed;

    //How much the sushi is worth when scored
    [SerializeField] int points;

    //The sushi's quality
    [SerializeField] int rank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The conveyor belt movement
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
