using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D touch = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.zero, 0.1f, LayerMask.GetMask("Enemy"));

        if(touch.collider != null) {
            Debug.Log("Enemy hit");
        }
    }
}
