using UnityEngine;

public class ClockHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SpriteButton>().clicked == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (transform.position.y < -1.5f)
            Destroy(gameObject);
    }
}
