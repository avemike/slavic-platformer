using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Loads a new level when the tagTarget walks onto the triggering collider
public class LevelTransition : MonoBehaviour
{
    public string tagTarget = "Player";
    public SceneAsset sceneToLoad;
    public string playerSpawnTransformName = "NOT SET";

    private bool canEnter = false;

    void Start(){
        Debug.Log("Level Transition Start");
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == tagTarget) {
            canEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == tagTarget) {
            canEnter = false;
        }
    }

    private void Update() {
        if (canEnter && Input.GetKeyDown(KeyCode.E)) {
            LevelEvents.levelExit.Invoke(sceneToLoad, playerSpawnTransformName);
        }
    }
}
