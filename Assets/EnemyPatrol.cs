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
    private SpriteRenderer spriteRenderer;
    private bool isMovingToPointA = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim.SetBool("Run", true);
    }

    // Update is called once per frame
    void Update()
    {


        if(!isMovingToPointA && rb.velocity.magnitude <= 3) {
            rb.velocity = new Vector2(speed, 0);
        } else if (rb.velocity.magnitude <= 3){
            rb.velocity = new Vector2(-speed, 0);
        }

        if(transform.position.x <= pointA.transform.position.x) {
            isMovingToPointA = false;
            spriteRenderer.flipX = false;
        }
        if (transform.position.x >= pointB.transform.position.x) {
            isMovingToPointA = true;
            spriteRenderer.flipX = true;
        }
    }

    private void DrawGizmos() {
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
