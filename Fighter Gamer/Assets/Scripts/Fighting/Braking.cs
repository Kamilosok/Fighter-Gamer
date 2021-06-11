using UnityEngine;

public class Braking : MonoBehaviour
{
    public float speedOfBraking;
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(speedOfBraking!=0)
            rb2d.velocity -= rb2d.velocity / speedOfBraking;
    }
}
