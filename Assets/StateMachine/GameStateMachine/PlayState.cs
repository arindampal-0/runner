using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class PlayState : GameStateMachine
{
    
    private InputAction pauseAction;

    public override void EnterState(GameManager gameManager)
    {
        Debug.Log("PlayState.EnterState");
        gameManager.Playing = true;
        pauseAction = InputSystem.actions.FindAction("Pause", true);

        // Show HUD
        gameManager.UIController.ShowHUD();
    }

    public override void UpdateState(GameManager gameManager)
    {
        if (gameManager.PlatformSpawnTick >= gameManager.PlatformSpawnInterval)
        {
            gameManager.PlatformSpawnTick = 0;
            this.SpawnPlatform(gameManager.PlatformPrefab);
        }

        gameManager.PlatformSpawnTick += Time.deltaTime;

        if (gameManager.ScoreUpdateTick >= gameManager.ScoreUpdateInterval)
        {
            gameManager.ScoreUpdateTick = 0;
            gameManager.IncreaseScore(gameManager.ScoreUpdateInterval);
        }

        gameManager.ScoreUpdateTick += Time.deltaTime;

        float pausePressed = pauseAction.ReadValue<float>();
        if (pausePressed == 1)
        {
            gameManager.PauseGame();
        }
    }

    public override void ExitState(GameManager gameManager)
    {
        gameManager.Playing = false;

        // Hide HUD
        gameManager.UIController.HideHUD();
    }

    private void SpawnPlatform(GameObject platformPrefab)
    {
        if (platformPrefab != null)
        {
            Instantiate(platformPrefab, new Vector3(-70, 0, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogError("Platform Prefab is not set in GameManager.");
        }
    }
}
