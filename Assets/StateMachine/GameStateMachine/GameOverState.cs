using UnityEngine;

public class GameOverState : GameStateMachine
{
    private GameObject gameOverMenuObject;

    public override void EnterState(GameManager gameManager)
    {
        gameManager.Playing = false;

        // Show GameOverMenu
        gameManager.UIController.ShowGameOverMenu();
    }

    public override void UpdateState(GameManager gameManager)
    {
        
    }

    public override void ExitState(GameManager gameManager)
    {
        // Hide GameOverMenu
        gameManager.UIController.HideGameOverMenu();
    }
}

