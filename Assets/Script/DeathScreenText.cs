using UnityEngine;
using TMPro;
using System.Linq;

public class DeathScreenText : MonoBehaviour
{
    MinigameSpawner gameManager;
    public TMP_Text bestText;
    public TMP_Text scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = transform.root.GetComponentInChildren<MinigameSpawner>();
        bestText.text += PlayerPrefs.GetInt("BestScore").ToString();
        scoreText.text += gameManager.gamesPlayed.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
