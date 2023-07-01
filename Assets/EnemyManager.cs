using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Image[] hearts;
    public int currentHealth = 3;

    public void TakeDamage(Transform source) {
        currentHealth -= 1;
        var scr = transform.GetComponentInChildren<EnemyPatrol>();
        
        if (currentHealth<= 0) {
            scr.Die();

            return;
            
            // Destroy(gameObject);
        }

        var rb = transform.GetComponentInChildren<Rigidbody2D>();

        //  playerRb.AddForce((playerRb.transform.position - source.position) * 100);

        var horizontal = (rb.position.x - source.position.x) > 0 ? 0.2f : -0.2f;

        Vector2 force = new Vector2(horizontal, 0.4f);

        rb.AddForce(force, ForceMode2D.Impulse);
        scr.isBlocked = true;

        StartCoroutine(ResetBlocked(scr));
    }

    IEnumerator ResetBlocked(EnemyPatrol scr) {
        yield return new WaitForSeconds(1f);
        scr.isBlocked = false;
    }

    void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if (i < currentHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

}
