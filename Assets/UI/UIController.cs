using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    private VisualElement ui;
    private VisualElement mainMenu;
    private Button mainMenuStartButton;
    private Button mainMenuQuitButton;
    private VisualElement hud;
    private Button hudPauseButton;
    private Label hudScoreLabel;
    private Label hudCoinsLabel;
    private VisualElement pauseMenu;
    private Button pauseMenuResumeButton;
    private Button pauseMenuMainMenuButton;
    private VisualElement gameOverMenu;
    private Label gameOverMenuScoreText;
    private Label gameOverMenuCoinsText;
    private Button gameOverMenuRestartButton;
    private Button gameOverMenuMainMenuButton;

    private void Awake()
    {
        this.ui = this.GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        this.mainMenu = this.ui.Q<VisualElement>("MainMenu");

        this.mainMenuStartButton = this.mainMenu.Q<Button>("StartButton");
        this.mainMenuStartButton.clicked += this.OnStartButtonClicked;

        this.mainMenuQuitButton = this.mainMenu.Q<Button>("QuitButton");
        this.mainMenuQuitButton.clicked += this.OnQuitButtonClicked;

        this.hud = this.ui.Q<VisualElement>("HUD");

        this.hudScoreLabel = this.hud.Q<Label>("Score");

        this.hudCoinsLabel = hud.Q<Label>("CoinScore");

        this.hudPauseButton = this.hud.Q<Button>("PauseButton");
        this.hudPauseButton.clicked += this.OnPauseButtonClicked;

        this.pauseMenu = this.ui.Q<VisualElement>("PauseMenu");

        this.pauseMenuResumeButton = this.pauseMenu.Q<Button>("ResumeButton");
        this.pauseMenuResumeButton.clicked += this.OnResumeButtonClicked;

        this.pauseMenuMainMenuButton = this.pauseMenu.Q<Button>("MainMenuButton");
        this.pauseMenuMainMenuButton.clicked += this.OnMainMenuButtonClicked;

        this.gameOverMenu = this.ui.Q<VisualElement>("GameOverMenu");

        this.gameOverMenuScoreText = this.gameOverMenu.Q<Label>("ScoreText");

        this.gameOverMenuCoinsText = this.gameOverMenu.Q<Label>("CoinText");

        this.gameOverMenuRestartButton = this.gameOverMenu.Q<Button>("RestartButton");
        this.gameOverMenuRestartButton.clicked += this.OnRestartButtonClicked;

        this.gameOverMenuMainMenuButton = this.gameOverMenu.Q<Button>("MainMenuButton");
        this.gameOverMenuMainMenuButton.clicked += this.OnMainMenuButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        GameManager.Instance.StartGame();
    }

    private void OnQuitButtonClicked()
    {
        GameManager.Instance.QuitGame();
    }

    private void OnPauseButtonClicked()
    {
        GameManager.Instance.PauseGame();
    }
    private void OnResumeButtonClicked()
    {
        Debug.Log("ResumeButton clicked.");
        GameManager.Instance.ResumeGame();
    }

    private void OnRestartButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    private void OnMainMenuButtonClicked()
    {
        GameManager.Instance.GoToMainMenu();
    }

    public void UpdateHUDScore(uint score)
    {
        this.hudScoreLabel.text = score.ToString();
    }

    public void UpdateHUDCoins(uint coins)
    {
        this.hudCoinsLabel.text = coins.ToString();
    }

    public void SetGameOverMenuScore(uint score)
    {
        this.gameOverMenuScoreText.text = score.ToString();
    }

    public void SetGameOverMenuCoins(uint coins)
    {
        this.gameOverMenuCoinsText.text = coins.ToString();
    }

    public void ShowMainMenu()
    {
        if (this.mainMenu != null)
        {
            this.mainMenu.RemoveFromClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #MainMenu in UI.");
        }
    }

    public void HideMainMenu()
    {
        if (this.mainMenu != null)
        {
            this.mainMenu.AddToClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #MainMenu in UI.");
        }
    }

    public void ShowHUD()
    {
        if (this.hud != null)
        {
            this.hud.RemoveFromClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #HUD in UI.");
        }
    }

    public void HideHUD()
    {
        if (this.hud != null)
        {
            this.hud.AddToClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #HUD in UI.");
        }
    }

    public void ShowPauseMenu()
    {
        if (this.pauseMenu != null)
        {
            this.pauseMenu.RemoveFromClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #PauseMenu in UI.");
        }
    }

    public void HidePauseMenu()
    {
        if (this.pauseMenu != null)
        {
            this.pauseMenu.AddToClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #PauseMenu in UI.");
        }
    }

    public void ShowGameOverMenu()
    {
        if (this.gameOverMenu != null)
        {
            this.gameOverMenu.RemoveFromClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #GameOverMenu in UI.");
        }
    }

    public void HideGameOverMenu()
    {
        if (this.gameOverMenu != null)
        {
            this.gameOverMenu.AddToClassList("hide");
        }
        else
        {
            throw new System.Exception("Could not find #GameOverMenu in UI.");
        }
    }
}
