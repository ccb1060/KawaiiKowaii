using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// This script controls the behavior of each sushi object
/// </summary>
public class Sushi : MonoBehaviour
{
    //How fast the sushi move
    [SerializeField] float speed;

    //How much the sushi is worth when scored
    [SerializeField] public int points;

    //The sushi's quality
    [SerializeField] public int rank;


    [SerializeField] public Sprite[] possibleSprites;
    [SerializeField] public SpriteRenderer spriteRenderer; 

    private bool dragging = false;
    public bool onPlate = false;
    public Vector3 offset;

    //The position the sushi will return to when no longer being dragged
    public Vector3 returnPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position -= new Vector3(0, -1, 0);
        GenerateTexture(); 
    }

    // Update is called once per frame
    void Update()
    {
        //The conveyor belt movement
        if (!onPlate)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            returnPosition += new Vector3(speed * Time.deltaTime, 0, 0);
        }
            
        if (dragging)
        {
            // Move object, taking into account original offset.
            
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }

        if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnMouseDown()
    {
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
        //dragged = true;
        if(!onPlate)
            returnPosition = transform.position;
        gameObject.GetComponent<Rigidbody2D>().mass = 0;
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        dragging = false;
        transform.position = returnPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sushi")
        {
            Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>()); 
        }
    }

    /// <summary>
    /// Generates a random texture for the sushi
    /// </summary>
    private void GenerateTexture()
    {
        int random = Random.Range(1, 3);

        if (random == 1)
        {
            spriteRenderer.sprite = possibleSprites[0];
        }
        else
        {
            spriteRenderer.sprite = possibleSprites[1];
        }
    }
}
