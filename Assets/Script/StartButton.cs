using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour
{
    MinigameSpawner gameManager;
    SpriteButton button;
    public AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = transform.root.GetComponentInChildren<MinigameSpawner>();
        button = GetComponentInChildren<SpriteButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.clickDown)
        {
            StartCoroutine(StartGame());    
        }
    }

    IEnumerator StartGame()
    {
        StartCoroutine(gameManager.Transition(null));
        yield return new WaitForSeconds(0.9f);
        transform.parent.parent.gameObject.SetActive(false);
        music.Play();
    }
}
