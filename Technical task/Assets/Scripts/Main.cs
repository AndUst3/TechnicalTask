using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    private int _points;

    [SerializeField] private Text _pointsLabel;
    [SerializeField] private Text _gameOverLabel;
    [SerializeField] private Text _endGameLabel;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private Button _restartButtonLose;
    [SerializeField] private Button _restartButtonEnd;
    [SerializeField] private Button _exitButton;

    private UIDisplayCoins _displayCoins;
    private UIDisplayGameOver _displayGameOver;
    private UIDisplayEndGame _displayEndGame;

    private void Awake()
    {
        Time.timeScale = 1f;

        _points = 0;

        _displayCoins = new UIDisplayCoins(_pointsLabel);
        _displayGameOver = new UIDisplayGameOver(_gameOverLabel);
        _displayEndGame = new UIDisplayEndGame(_endGameLabel);

        _gameOverMenu.gameObject.SetActive(false);
        _endGameMenu.gameObject.SetActive(false);
        _restartButtonLose.onClick.AddListener(RestartGame);
        _restartButtonEnd.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);
        _displayCoins.DisplayCoins(_points);
    }

    private void GameOver()
    {
        _gameOverMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void EndGame()
    {
        _endGameMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _points++;
            _displayCoins.DisplayCoins(_points);
        }

        if (other.CompareTag("Thorns"))
        {
            Time.timeScale = 0f;
            _displayGameOver.GameOver();
            GameOver();
        }
    }

    private void Update()
    {
        if (_points == 10)
        {
            _displayEndGame.EndGame();
            EndGame();
        }
    }
}
