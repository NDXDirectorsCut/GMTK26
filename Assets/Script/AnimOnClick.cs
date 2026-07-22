using UnityEngine;
using System.Collections.Generic;
using System;

public class AnimOnClick : MonoBehaviour
{
    SpriteButton button;
    public List<Animator> animList = new();
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
            foreach(Animator anim in animList)
            {
                anim.SetTrigger("OnClick");
            }
        }
        
    }
}
