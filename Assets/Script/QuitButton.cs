using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class QuitButton : MonoBehaviour
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
            StartCoroutine(Quit());
        }
    }

    IEnumerator Quit()
    {
        gameManager.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        Application.Quit();
    }
}
