using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigameSpawner : MonoBehaviour
{
    public int level = 0;
    public int levelUp = 5;
    public int lives = 3;
    public int gamesPlayed = 0;
    public List<MinigameData> minigames = new();
    public MinigameLogic activeMinigame;
    public GameObject transitionScreen;
    public GameObject speedUpScreen;
    public GameObject deathScreen;
    public GameObject fadeOutScreen;
    public GameObject fadeInScreen;
    public float transitionTime = 2.5f;
    public float speedUpTime = 3.5f;

    int levelTrack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeIn();
        Application.targetFrameRate = 60;
        levelTrack = level;
    }

    // Update is called once per frame
    void Update()
    {
        if(activeMinigame != null)
        {
            if(activeMinigame.failed == true || activeMinigame.successed == true)
            {
                if(activeMinigame.failed == true)
                {
                    lives--;
                }
                level = gamesPlayed/levelUp;

                if(level!=levelTrack)
                {
                    StartCoroutine(LevelUp(activeMinigame));
                }
                else
                {
                    StartCoroutine(Transition(activeMinigame));
                }
                activeMinigame = null;
            }
        }
        levelTrack = level;
    }

    public void FadeOut()
    {
        GameObject tempFade = Instantiate(fadeOutScreen,Vector3.zero,Quaternion.identity);
        Destroy(tempFade,1f);
    }

    public void FadeIn()
    {
        GameObject tempFade = Instantiate(fadeInScreen,Vector3.zero,Quaternion.identity);
        Destroy(tempFade,1f);
    }

    public IEnumerator LevelUp(MinigameLogic game)
    {
        if(game != null)
        {
            GameObject minigameObject = game.gameObject;
            MonoBehaviour[] scripts = minigameObject.GetComponentsInChildren<MonoBehaviour>();
            foreach(MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            Destroy(game.gameObject,1f);
        }

        FadeOut();

        GameObject tempTransition = Instantiate(speedUpScreen, Vector3.zero, Quaternion.identity);
        tempTransition.SetActive(false);

        yield return new WaitForSecondsRealtime(0.9f);

        FadeIn();
        tempTransition.SetActive(true);
        Destroy(tempTransition,speedUpTime);

        yield return new WaitForSecondsRealtime(speedUpTime-1.1f);

        StartCoroutine(Transition(null));

        yield return null;
    }

    public IEnumerator Transition(MinigameLogic game)
    {
        if(game != null)
        {
            GameObject minigameObject = game.gameObject;
            MonoBehaviour[] scripts = minigameObject.GetComponentsInChildren<MonoBehaviour>();
            foreach(MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }
            Destroy(game.gameObject,1f);
        }

        FadeOut();
        
        GameObject tempTransition = Instantiate(transitionScreen, Vector3.zero, Quaternion.identity);
        tempTransition.SetActive(false);
        
        int id = Random.Range(1,minigames.Count);
        MinigameData newGameData = minigames[id];
        tempTransition.transform.Find("Cover").GetComponentInChildren<SpriteRenderer>().sprite = newGameData.gameCover;

        yield return new WaitForSecondsRealtime(0.9f);

        FadeIn();

        if(lives == 0)
        {
            StartCoroutine(Death());
        }
        else
        {
            gamesPlayed++;
            tempTransition.SetActive(true);
            Destroy(tempTransition,transitionTime);
            StartCoroutine(SpawnMinigame(id));
        }
        yield return null;
    }

    IEnumerator Death()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        GameObject newScreen = Instantiate(deathScreen,Vector3.zero,Quaternion.identity);
        newScreen.transform.parent = transform;

        if(gamesPlayed>bestScore)
        {
            PlayerPrefs.SetInt("BestScore",gamesPlayed);
            bestScore = gamesPlayed;
        }
        yield return null;
    }

    IEnumerator SpawnMinigame(int id)
    {
        MinigameData newGameData = minigames[id];
        GameObject newGame = Instantiate(newGameData.minigame, Vector3.zero, Quaternion.identity);
        newGame.SetActive(false);
        MinigameLogic newGameLogic = newGame.GetComponentInChildren<MinigameLogic>();
        newGameLogic.gameTime = newGameData.baseTime - newGameData.timeDecrease * level;
        if(newGameLogic.gameTime <= newGameData.minTime)
            newGameLogic.gameTime = newGameData.minTime;
        yield return new WaitForSecondsRealtime(transitionTime-0.1f);
        newGame.SetActive(true);
        activeMinigame = newGameLogic;  
        yield return null;
    }
}
