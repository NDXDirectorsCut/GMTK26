using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigameSpawner : MonoBehaviour
{
    public int level = 0;
    public int levelUp = 3;
    public int lives = 3;
    public int gamesPlayed = 0;
    public List<MinigameData> minigames = new();
    public MinigameLogic activeMinigame;
    public GameObject transitionScreen;
    public GameObject fadeOutScreen;
    public GameObject fadeInScreen;
    public float transitionTime = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeMinigame != null)
        {
            if(activeMinigame.failed == true || activeMinigame.successed == true)
            {
               StartCoroutine(Transition(activeMinigame));
               activeMinigame = null;
               gamesPlayed++;
               level = gamesPlayed/levelUp;
            }
        }
    }

    void FadeOut()
    {
        GameObject tempFade = Instantiate(fadeOutScreen,Vector3.zero,Quaternion.identity);
        Destroy(tempFade,1f);
    }

    void FadeIn()
    {
        GameObject tempFade = Instantiate(fadeInScreen,Vector3.zero,Quaternion.identity);
        Destroy(tempFade,1f);
    }

    IEnumerator Transition(MinigameLogic game)
    {
        GameObject minigameObject = game.gameObject;
        MonoBehaviour[] scripts = minigameObject.GetComponentsInChildren<MonoBehaviour>();
        foreach(MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
        Destroy(game.gameObject,1f);
        
        FadeOut();

        GameObject tempTransition = Instantiate(transitionScreen, Vector3.zero, Quaternion.identity);
        tempTransition.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);

        FadeIn();
        tempTransition.SetActive(true);
        Destroy(tempTransition,transitionTime);
        StartCoroutine(PickNewMinigame());
        yield return null;
    }

    IEnumerator PickNewMinigame()
    {
        int id = Random.Range(1,minigames.Count);
        MinigameData newGameData = minigames[id];
        GameObject newGame = Instantiate(newGameData.minigame, Vector3.zero, Quaternion.identity);
        newGame.SetActive(false);
        MinigameLogic newGameLogic = newGame.GetComponentInChildren<MinigameLogic>();
        newGameLogic.gameTime = newGameData.baseTime - newGameData.timeDecrease * level;
        if(newGameLogic.gameTime <= 0)
            newGameLogic.gameTime = 1;
        yield return new WaitForSecondsRealtime(transitionTime);
        newGame.SetActive(true);
        activeMinigame = newGameLogic;  
        yield return null;
    }
}
