using System.Linq;
using UnityEngine;

public class StartState : GameStateMachine
{
    public override void EnterState(GameManager gameManager)
    {
        // Reset ticks
        gameManager.ScoreUpdateTick = 0;
        gameManager.PlatformSpawnTick = 0;

        // Reset score and coins collected
        gameManager.ResetScore();
        gameManager.ResetCoins();

        // Unhook camera from player and reset its transform
        gameManager.CameraObject.transform.SetParent(null);
        gameManager.CameraObject.transform.position = new Vector3(12, 6, 0);
        gameManager.CameraObject.transform.rotation = Quaternion.Euler(0, -90, 0);

        // Remove player and platforms if already exist.
        Destroy(gameManager.Player);
        gameManager.Player = null;
        foreach(GameObject platform in gameManager.Platforms)
        {
            Destroy(platform);
        }
        gameManager.Platforms.Clear();

        // Show MainMenu
        gameManager.UIController.ShowMainMenu();

        // Instantiate new player and platforms
        if (gameManager.PlayerPrefab != null)
        {
            GameObject playerObject = Instantiate(gameManager.PlayerPrefab, new Vector3(0, 1.6f, 0), Quaternion.identity);
            gameManager.Player = playerObject;

            if (gameManager.CameraObject != null)
            {
                gameManager.CameraObject.transform.SetParent(playerObject.transform);
            }
            else
            {
                throw new System.Exception("Camera Object not set in GameManager");
            }
        }
        else
        {
            throw new System.Exception("Player Prefab is not set in GameManager.");
        }

        if (gameManager.PlatformPrefab != null)
        {
            GameObject platformObject = Instantiate(gameManager.PlatformPrefab, new Vector3(10, 0, 0), Quaternion.identity);
            gameManager.Platforms.Add(platformObject);
            platformObject = Instantiate(gameManager.PlatformPrefab, new Vector3(-70, 0, 0), Quaternion.identity);
            gameManager.Platforms.Add(platformObject);
        }
        else
        {
            throw new System.Exception("Platform Prefab is not set in GameManager.");
        }
    }

    public override void UpdateState(GameManager gameManager)
    {
        
    }

    public override void ExitState(GameManager gameManager)
    {
        // Hide MainMenu
        gameManager.UIController.HideMainMenu();
    }
}
