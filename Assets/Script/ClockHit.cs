using UnityEngine;

public class ClockHit : MonoBehaviour
{
    public GameObject Explosion;
    public bool Boomed = false;
    bool Okay = true;
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
        if (transform.position.y < -1.5f && Okay == true)
        {
            GameObject FunnyBoom = Instantiate(Explosion,transform.position, Quaternion.identity);
            FunnyBoom.transform.localScale = Vector3.one * 4f;
            Boomed = true;
            gameObject.GetComponent<IsExploded>().Exploded = true;
            Okay = false;
        }
        if (transform.position.y < -10000f)
            Destroy(gameObject);
    }
}
