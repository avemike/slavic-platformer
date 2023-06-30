using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform worldSpaceCanvas;


    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.transform;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
}
