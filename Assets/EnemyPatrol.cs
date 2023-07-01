using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
        anim.SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == pointB.transform) {
            rb.velocity = new Vector2(speed, 0);
        } else {
            rb.velocity = new Vector2(-speed, 0);
        }

        Debug.Log(Vector2.Distance(transform.position, currentPoint.position));
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) {
            currentPoint = pointA.transform;
            spriteRenderer.flipX = true;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform) {
            currentPoint = pointB.transform;
            spriteRenderer.flipX = false;
        }
    }

    private void DrawGizmos() {
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
