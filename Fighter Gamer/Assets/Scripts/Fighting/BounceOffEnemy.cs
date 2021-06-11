using UnityEngine;

public class BounceOffEnemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 lookDirection = new Vector2(collision.transform.position.x, collision.transform.position.y) - rb2d.position;
            rb2d.AddForce(-50 * lookDirection);
        }
    }
}
