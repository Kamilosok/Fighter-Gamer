using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rb2d;
    private List<Transform> targetPositions = new List<Transform>();
    void Start()
    {
        playerTransform = GameObject.Find("Hero").transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        targetPositions.Add(playerTransform);
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        for (int i = 0; i < waypoints.Length; i++)
        {
            targetPositions.Add(waypoints[i].transform);
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = new Vector2(targetPositions[0].position.x, targetPositions[0].position.y) - rb2d.position;
        if ((rb2d.velocity.x < 3 && rb2d.velocity.x > -3) || (rb2d.velocity.y < 3 && rb2d.velocity.y > -3))
        {
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb2d.rotation = angle;
            rb2d.AddForce(lookDirection / 2);
        }
        else
            rb2d.AddForce(lookDirection / 10);
    }
}