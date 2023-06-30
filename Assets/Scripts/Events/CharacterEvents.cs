using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class CharacterEvents {
    // When any character is hit and took damage
    public static UnityAction<float, GameObject> characterDamaged;
}