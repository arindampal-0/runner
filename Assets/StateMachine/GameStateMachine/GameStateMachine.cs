using UnityEngine;

public abstract class GameStateMachine : MonoBehaviour
{
    public abstract void EnterState(GameManager gameManager);

    public abstract void UpdateState(GameManager gameManager);

    public abstract void ExitState(GameManager gameManager);
}
