using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] float stopCooldown;
    [SerializeField] Vector3 stopPosition;
    private bool stopped;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            stopCooldown -= Time.deltaTime;
        }
        else
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }

        if ((transform.position - stopPosition).magnitude < .1 && stopCooldown > 0)
        {
            stopped = true;
        }
        else
        {
            stopped = false;
        }


    }
}
