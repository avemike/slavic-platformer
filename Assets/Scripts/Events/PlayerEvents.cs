using System;
using UnityEngine;
using UnityEngine.Events;

// Static events related to the player

public class PlayerEvents { 
    public static UnityAction<Transform> onPlayerSpawned;
    public static UnityAction onPlayerDespawned;

    /*
    public delegate void OnPlayerSpawned(Transform playerTransform);
    public static event OnPlayerSpawned onPlayerSpawned;

    public delegate void PlayerDespawned();
    public static event PlayerDespawned playerDespawned;
    */
}