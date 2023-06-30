using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyDamage : MonoBehaviour
{
    public PlayerManager playerManager;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerManager.TakeDamage(transform);
        }
    }
}
