using UnityEngine;

public class SpriteButton : MonoBehaviour
{
    public bool clicked = false;
    public bool clickDown = false;
    public bool hovered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        clickDown = false;
    }

    void OnMouseDown()
    {
        clicked = true;
        clickDown = true;
    }

    void OnMouseUp()
    {
        clicked = false;
    }

    void OnMouseEnter()
    {
        hovered = true;
    }

    void OnMouseExit()
    {
        hovered = false;
    }
}
