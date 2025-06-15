using UnityEngine;

public class GameOverState : GameStateMachine
{
    private GameObject gameOverMenuObject;

    public override void EnterState(GameManager gameManager)
    {
        gameManager.Playing = false;

        // Show GameOverMenu
        gameManager.UIController.ShowGameOverMenu();
        gameManager.SetGameOverUIState();
    }

    public override void UpdateState(GameManager gameManager)
    {
        
    }

    public override void ExitState(GameManager gameManager)
    {
        // Hide GameOverMenu
        gameManager.UIController.HideGameOverMenu();
        gameManager.UIController.ResetGameOverMenuLabels();
    }
}

