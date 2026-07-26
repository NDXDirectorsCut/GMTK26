using System.Collections;
using UnityEngine;

public class MenuChangeButton : MonoBehaviour
{
    public GameObject fromMenu;
    public GameObject toMenu;
    MinigameSpawner gameManager;
    SpriteButton button;
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
            StartCoroutine(ChangeScreen());
        }
    }

    IEnumerator ChangeScreen()
    {
        gameManager.FadeOut();
        yield return new WaitForSeconds(0.9f);
        gameManager.FadeIn();
        fromMenu.SetActive(false);
        toMenu.SetActive(true);
        yield return null;
    }
}
