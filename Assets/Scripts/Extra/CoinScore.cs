using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour {
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

	void Update () {
        scoreText.text = Coin.coinScore.ToString();
	}
}
