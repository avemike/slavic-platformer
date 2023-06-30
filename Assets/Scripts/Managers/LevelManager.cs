using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/Manager/LevelManager", order = 1)]
public class LevelManager : ScriptableObject
{
    public GameState GameState { get; set; }

    void OnEnable() {
        // LevelEvents.levelOpened += StartLevel;
        LevelEvents.levelExit += OnLevelExit;
    }

    // Set the playerSpawnLocation in the game state for the next level and load the next level
    private void OnLevelExit(SceneAsset nextLevel, string playerSpawnTransformName)
    {
        GameState.playerSpawnLocation = playerSpawnTransformName;
        SceneManager.LoadScene(nextLevel.name, LoadSceneMode.Single);
    }

    void OnDisable() {
        LevelEvents.levelExit -= OnLevelExit;
    }
}
