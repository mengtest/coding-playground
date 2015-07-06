using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour {
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();

        if (NoCoinsExist())
            HideCoinScore();
    }

    private void HideCoinScore()
    {
        Canvas c = transform.parent.gameObject.GetComponent<Canvas>();
        if (c != null)
            c.enabled = false;
    }

    private bool NoCoinsExist()
    {
        return FindObjectsOfType<Coin>().Length == 0;
    }

	void Update () {
        scoreText.text = Coin.coinScore.ToString();
	}
}
