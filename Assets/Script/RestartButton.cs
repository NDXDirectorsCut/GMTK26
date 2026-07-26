using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    SpriteButton button;
    MinigameSpawner gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponentInChildren<SpriteButton>();    
        gameManager = transform.root.GetComponentInChildren<MinigameSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.clickDown)
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        gameManager.FadeOut();
        yield return new WaitForSecondsRealtime(0.9f);
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name,LoadSceneMode.Single);
    }
}
