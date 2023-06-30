using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public Image[] hearts;

    [SerializeField]
    private PlayerStats startingPlayerStats;

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < hearts.Length; i++) {
            if(i < startingPlayerStats.currentHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
