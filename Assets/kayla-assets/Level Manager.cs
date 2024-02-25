using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;

        // Reset stored coin count to 0 when the game starts
        PlayerPrefs.SetInt("Coins", 0);
        currentCoins = 0; // Also reset the currentCoins variable
    }

    public int currentCoins, coinThreshold = 9999;

    // Start is called before the first frame update
    void Start()
    {
        // Don't update UI here
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetCoin()
    {
        currentCoins++;

        if (currentCoins >= coinThreshold)
        {
            currentCoins -= coinThreshold;
        }

        // Update UI after collecting coin
        UIController.instance.UpdateCoinText(currentCoins);

        PlayerPrefs.SetInt("Coins", currentCoins);
    }
}
