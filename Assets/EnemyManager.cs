using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hp = 3;

    public void TakeDamage(Transform source) {
        hp -= 1;
        
        if (hp <= 0) {
            Destroy(gameObject);
        }

        var rb = transform.GetComponentInChildren<Rigidbody2D>();

        var forceMultiplierX = 10;
        var forceMultiplierY = 3;

        //  playerRb.AddForce((playerRb.transform.position - source.position) * 100);
        Vector2 difference = (rb.transform.position - source.position).normalized;

        Vector2 force = new Vector2(difference.x * forceMultiplierX, 2 * forceMultiplierY);

        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
