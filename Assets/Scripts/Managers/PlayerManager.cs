using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Create one at the start of game or load game and keep active throughout the active game to manager
// player statistics and spawning
[CreateAssetMenu(fileName = "PlayerManager", menuName = "ScriptableObjects/Manager/PlayerManager", order = 1)]
public class PlayerManager : ScriptableObject
{
    [SerializeField]
    private GameObject playerPrefab;
    public GameObject ActivePlayer { get; private set; }

    [SerializeField]
    private PlayerStats startingPlayerStats;

    public PlayerStats PlayerStats { get; private set; }
    public GameState GameState { get; set; }

    // Tag of Transforms that are locations where the player can spawn
    public string spawnTag;

    public void TakeDamage(Transform source) {
        Debug.Log("Damage taken");
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        LevelEvents.levelLoaded += SpawnPlayer;

        // Duplicate on start so values do not change in the editor
        PlayerStats = Instantiate(startingPlayerStats);
    }

    // Spawns player at the game state spawn location if it is set or the defaultSpawnTransform location for the current level
    protected void SpawnPlayer(Transform defaultSpawnTransform) {
        if (GameState.playerSpawnLocation != "") {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(spawnTag);
            bool foundSpawn = false;

            foreach(GameObject spawn in spawns) {
                // If matching spawn name
                if(spawn.name == GameState.playerSpawnLocation) {
                    foundSpawn = true;
                    
                    // Spawn location set, so spawn player there
                    ActivePlayer = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
                    break;
                }
            }
            if(!foundSpawn) {
                throw new MissingReferenceException("Could not find the player spawn location with the name " + GameState.playerSpawnLocation);
            } 
        } else {
            // Create instance of player prefab at default spawn location for level
            ActivePlayer = Instantiate(playerPrefab, defaultSpawnTransform.position, Quaternion.identity);
            Debug.Log("Player spawned at default location: " + defaultSpawnTransform);
        }
        
        if(ActivePlayer) {
            // Set camera to look at track player

            PlayerEvents.onPlayerSpawned.Invoke(ActivePlayer.transform);
        } else {
            throw new MissingReferenceException("No ActivePlayer in PlayerManager. May have failed to spawn!");
        }
        
    }

    void OnDisable(){
        LevelEvents.levelLoaded -= SpawnPlayer;
    }
}
