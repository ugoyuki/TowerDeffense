using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = LevelManager.i.path[pathIndex];
    }

    private void Update()
    {
        if(Vector2.Distance(target.position,transform.position) <= .1f)
        {
            pathIndex++;
            if (pathIndex >= LevelManager.i.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.i.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

}
