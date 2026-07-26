using UnityEngine;

public class FullscreenButton : MonoBehaviour
{
    SpriteButton button;
    bool mode = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponentInChildren<SpriteButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.clickDown)
        {
            if(mode == true)
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
            else
            {
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            }
        }
    }
}
