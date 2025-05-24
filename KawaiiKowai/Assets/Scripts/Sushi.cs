using UnityEngine;

public class Sushi : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int points;
    [SerializeField] int rank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
