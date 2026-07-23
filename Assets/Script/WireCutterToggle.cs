using UnityEngine;

public class WireCutterToggle : MonoBehaviour
{
    public GameObject WireCutterOpen;
    public GameObject WireCutterClosed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            WireCutterOpen.SetActive(false);
            WireCutterClosed.SetActive(true);
        }
        else
        {
            WireCutterOpen.SetActive(true);
            WireCutterClosed.SetActive(false);
        }
    }
}
