using UnityEngine;

public class PauseState : GameStateMachine
{
    private GameObject pauseMenuObject;
    public override void EnterState(GameManager gameManager)
    {
        Debug.Log("PauseState.EnterState");
        gameManager.Playing = false;

        // Show PauseMenu
        gameManager.UIController.ShowPauseMenu();
    }

    public override void UpdateState(GameManager gameManager)
    {
        
    }

    public override void ExitState(GameManager gameManager)
    {
        Debug.Log("PauseState.ExitState");
        // Hide PauseMenu
        gameManager.UIController.HidePauseMenu();
    }
}

