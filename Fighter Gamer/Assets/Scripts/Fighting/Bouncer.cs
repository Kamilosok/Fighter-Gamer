using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private Transform bouncerPos;
    private Vector2 fromWhereBounce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bouncerPos = GetComponentInChildren<Transform>();
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            fromWhereBounce = new Vector2((((bouncerPos.position.x + collision.transform.position.x) / 2) + 1) % 5, (((bouncerPos.position.y + collision.transform.position.y) / 2) + 1) % 5);
            collision.GetComponent<Rigidbody2D>().AddForce(fromWhereBounce * -80);
        }
    }
}
