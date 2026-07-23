using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Vector3 Offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -9;
        transform.position = mousePos+Offset;
    }
}
