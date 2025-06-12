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
    public static GameManager instance { get; private set;}

    //private GameState gameState = GameState.START_SCREEN;

    //private uint score = 0;
    public uint coinsCollected { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.coinsCollected = 0;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectCoin()
    {
        this.coinsCollected++;
    }
}
