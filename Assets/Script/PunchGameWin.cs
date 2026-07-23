using UnityEngine;

public class PunchGameWin : MonoBehaviour
{
    SpriteButton button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponentInChildren<SpriteButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(button.clicked)
        {
            transform.root.GetComponentInChildren<MinigameLogic>().successed = true;
        }        
    }
}
