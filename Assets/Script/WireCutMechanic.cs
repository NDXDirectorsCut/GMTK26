using UnityEngine;

public class WireCutMechanic : MonoBehaviour
{
    SpriteButton Button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button = GetComponent<SpriteButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Button.clicked == true)
        {
            gameObject.SetActive(false);
        }
    }
}
