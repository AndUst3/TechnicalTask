using System;
using UnityEngine.UI;

public class UIDisplayCoins
{
    public Text _pointsLabel;

    public UIDisplayCoins(Text pointsLabel)
    {
        _pointsLabel = pointsLabel;
        _pointsLabel.text = String.Empty;
    }

    public void DisplayCoins(int value)
    {
        _pointsLabel.text = $"{value}";
    }
}
