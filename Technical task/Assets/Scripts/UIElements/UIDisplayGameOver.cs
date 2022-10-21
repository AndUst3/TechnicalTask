using System;
using UnityEngine.UI;

public class UIDisplayGameOver
{
    public Text _gameOverLabel;

    public UIDisplayGameOver(Text gameOverLabel)
    {
        _gameOverLabel = gameOverLabel;
        _gameOverLabel.text = String.Empty;
    }

    public void GameOver()
    {
        _gameOverLabel.text = $"YOU DIED";
    }
}
