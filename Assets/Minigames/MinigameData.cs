using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "MinigameData", menuName = "Countdown/MinigameData")]
public class MinigameData : ScriptableObject
{
    public GameObject minigame;
    public Sprite gameCover;
    public int baseTime;
    public int timeDecrease;
}
