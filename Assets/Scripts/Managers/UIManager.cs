using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "UIManager", menuName = "ScriptableObjects/Manager/UIManager", order = 1)]
public class UIManager : ScriptableObject
{
    public GameObject healthDroppedText;
    private Canvas sceneCanvas;

    void OnEnable() {
        CharacterEvents.characterDamaged += OnCharacterDamaged;

        if(healthDroppedText == null) {
            throw new UnassignedReferenceException("Health text prefab is not set on " + this.name);
        }
    }

    // Displays a float text number above the character that was hit
    private void OnCharacterDamaged(float damage, GameObject character) {
        // Find the active canvas
        if(sceneCanvas == null) {
            sceneCanvas = GameObject.FindObjectOfType<Canvas>();
        }

        Debug.Log("Character " + character.name + " hit for " + damage + " damage.");
        // Spawn damage text right above the character
        HealthText healthTextInstance = Instantiate(healthDroppedText).GetComponent<HealthText>();
        RectTransform textTransform = healthTextInstance.GetComponent<RectTransform>();
        textTransform.transform.position = Camera.main.WorldToScreenPoint(character.transform.position);

        textTransform.SetParent(sceneCanvas.transform);
        healthTextInstance.textMesh.text = damage.ToString();
}

    void OnDisable() {
         CharacterEvents.characterDamaged -= OnCharacterDamaged;
    }
}
