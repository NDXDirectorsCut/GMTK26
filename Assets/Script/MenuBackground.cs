using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuBackground : MonoBehaviour
{
    public List<SpriteButton> buttons = new();
    public List<GameObject> menuBackgrounds = new();
    [Range(0,1)]
    public float lerp;
    int currSelected = 0;
    Color transparent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transparent = new Color(0f,0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<buttons.Count; i++)
        {
            if(buttons[i].hovered == true)
            {
                currSelected = i;
            }

            SpriteRenderer currBG = menuBackgrounds[i].GetComponentInChildren<SpriteRenderer>();
            if(i!=currSelected)
                currBG.color = Color.Lerp(currBG.color,transparent,lerp);
            
            SpriteRenderer selBG = menuBackgrounds[currSelected].GetComponentInChildren<SpriteRenderer>();
            selBG.color = Color.Lerp(selBG.color,Color.white,lerp);
        }
    }
}
