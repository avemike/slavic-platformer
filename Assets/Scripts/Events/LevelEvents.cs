using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class LevelEvents {
    // Vector3 Location for Spawn
    public static UnityAction<Transform> levelLoaded;

    // String name of target transform to spawn player at in new level
    public static UnityAction<SceneAsset, string> levelExit;
}