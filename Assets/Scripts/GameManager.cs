using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [HideInInspector] public static GameManager Instance { get { return _instance; } }

    [SerializeField] private GameStateMachine CurrentState;
    [HideInInspector] public StartState StartState;
    [HideInInspector] public PlayState PlayState;
    [HideInInspector] public PauseState PauseState;
    [HideInInspector] public RestartState RestartState;
    [HideInInspector] public GameOverState GameOverState;

    [HideInInspector] public uint Score { get; private set; }
    [HideInInspector] public uint CoinsCollected { get; private set; }

    [HideInInspector] public uint PlatformSpawnInterval = 8;
    [HideInInspector] public float PlatformSpawnTick = 0;
    [HideInInspector] public uint ScoreUpdateInterval = 1;
    [HideInInspector] public float ScoreUpdateTick = 0;

    [HideInInspector] public Boolean Playing;

    [HideInInspector] public GameObject CameraObject;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public List<GameObject> Platforms;

    public UIController UIController;
    public GameObject PlayerPrefab;
    public GameObject PlatformPrefab;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else if (_instance == null)
        {
            _instance = this;

            StartState = this.AddComponent<StartState>();
            PlayState = this.AddComponent<PlayState>();
            PauseState = this.AddComponent<PauseState>();
            GameOverState = this.AddComponent<GameOverState>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.CoinsCollected = 0;
        this.Score = 0;

        Platforms = new List<GameObject>();
        CurrentState = StartState;
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void SwitchState(GameStateMachine nextState)
    {
        Debug.Log("SwitchState");
        Debug.Log(nextState);
        CurrentState.ExitState(this);
        CurrentState = nextState;
        CurrentState.EnterState(this);
    }

    public void StartGame()
    {
        if (this.CurrentState is StartState)
        {
            this.SwitchState(this.PlayState);
        }
    }

    public void PauseGame()
    {
        if (this.CurrentState is PlayState)
        {
            this.SwitchState(this.PauseState);
        }
    }

    public void ResumeGame()
    {
        if (this.CurrentState is PauseState)
        {
            this.SwitchState(this.PlayState);
        }
    }

    public void RestartGame()
    {
        if (this.CurrentState is GameOverState)
        {
            this.SwitchState(this.RestartState);
        }
    }

    public void GameOver()
    {
        if (this.CurrentState is PlayState)
        {
            this.SwitchState(this.GameOverState);
        }
    }

    public void GoToMainMenu()
    {
        if (this.CurrentState is PauseState || this.CurrentState is GameOverState)
        {
            this.SwitchState(this.StartState);
        }
    }

    public void QuitGame()
    {
        if (this.CurrentState is StartState)
        {
            // Quit game

#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }

    public void ResetCoins()
    {
        this.CoinsCollected = 0;
    }

    public void CollectCoin()
    {
        this.CoinsCollected++;
        // Update UI
    }

    public void IncreaseScore(uint scoreIncrement)
    {
        this.Score += scoreIncrement;
        // Update UI
    }
}
