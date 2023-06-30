using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCollider : MonoBehaviour
{
    bool isPlayerColliding = false;


    private void Start() {
        var canvas = GetComponentInChildren<Canvas>();
        if(canvas != null) {
            
            canvas.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
     
        if(collision.gameObject.tag == "Player") {
            var canvas = GetComponentInChildren<Canvas>();
            isPlayerColliding = true;

            if (canvas != null) {
                canvas.enabled = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        // if player clicks space then load scene
        if (collision.gameObject.tag == "Player") {
            
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("Pressed");
                //SceneManager.LoadScene("Level1");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            var canvas = GetComponentInChildren<Canvas>();
            isPlayerColliding = false;

            if (canvas != null) {
                canvas.enabled = false;
            }
        }
    }
}
