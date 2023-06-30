using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameState startingState;
    
    // Active game state persistent while the game is running
    public GameState GameState { get; private set; }

    public LevelManager levelManager;
    public PlayerManager playerManager;
    public UIManager uiManager;

    void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
        // Set up game state
        GameState = Instantiate(startingState);
        levelManager.GameState = GameState;
        playerManager.GameState = GameState;
    }

}
