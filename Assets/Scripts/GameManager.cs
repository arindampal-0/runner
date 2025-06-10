using UnityEngine;

enum GameState
{
    START_SCREEN = 0,
    PLAY_SCREEN,
    PAUSE_SCREEN,
    GAMEOVER_SCREEN
}

public class GameManager : MonoBehaviour
{
    private GameState gameState = GameState.START_SCREEN;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
