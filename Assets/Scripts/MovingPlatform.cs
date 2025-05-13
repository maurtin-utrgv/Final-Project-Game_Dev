using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform point0;
    public Transform point1;
    public float speed = 2f;
    private Vector3 nextPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextPosition = point1.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        
        if(transform.position == nextPosition)
        {
            nextPosition = (nextPosition == point0.position)? point1.position : point0.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
