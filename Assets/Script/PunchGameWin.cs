using UnityEngine;

public class PunchGameWin : MonoBehaviour
{
    public bool loseOnPunch;
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
            if(loseOnPunch == false)
            {
                transform.root.GetComponentInChildren<MinigameLogic>().successed = true;
            }
            else
            {
                transform.root.GetComponentInChildren<MinigameLogic>().failed = true;
            }
        }        
    }
}
