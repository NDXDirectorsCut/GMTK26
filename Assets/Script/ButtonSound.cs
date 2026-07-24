using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    SpriteButton button;
    AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponentInChildren<SpriteButton>();
        sound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.clicked)
        {
            sound.Play();
        }
    }
}
