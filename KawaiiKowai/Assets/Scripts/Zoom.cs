using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float stopCooldown;
    [SerializeField] Vector3 stopPosition;
    private bool stopped;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            stopCooldown -= Time.deltaTime;

            if (stopCooldown < 0)
                stopped = false;
        }


    }
}
