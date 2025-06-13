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

    [SerializeField] private GameObject platformPrefab;
    
    private const float platformSpawnInterval = 8.0f;

    private float ticks = 0;

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
        if (this.ticks >= GameManager.platformSpawnInterval)
        {
            this.ticks = 0;
            this.SpawnPlatform();
        }

        this.ticks += Time.deltaTime;
    }

    public void CollectCoin()
    {
        this.coinsCollected++;
    }

    private void SpawnPlatform()
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
