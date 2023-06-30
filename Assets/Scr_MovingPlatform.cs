using UnityEditor;
using UnityEngine;

public class Scr_MovingPlatform : MonoBehaviour
{
    public float speed = 1f;
    public Transform pointA;
    public Transform pointB;
    private Vector2 currentTarget;

    private void FixedUpdate() {
        var step = speed * Time.deltaTime;
        
        if(transform.position == pointA.position) {
            currentTarget = pointB.position;
        } else if(transform.position == pointB.position) {
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            other.transform.SetParent(null);
        }
    }
}
