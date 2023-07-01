using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManagerEnemy : MonoBehaviour {
    public Image[] hearts;
    public int currentHealth = 3;

    // Update is called once per frame
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
