using UnityEngine;

public class HitMechanicMouse : MonoBehaviour
{
    public GameObject Explosion;
    public int HitCounter = 0;
    public GameObject FirstMouse, SecondMouse;
    bool ok = true;
    public bool Boomed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HitCounter < 4)
        {
            if (ok == true)
            {
                if (gameObject.GetComponent<SpriteButton>().clicked == true)
                    HitCounter++;
                if (HitCounter == 1)
                {
                    FirstMouse.SetActive(true);
                    HitCounter++;
                }
                if (HitCounter == 3)
                {
                    FirstMouse.SetActive(false);
                    SecondMouse.SetActive(true);
                    GameObject FunnyBoom = Instantiate(Explosion, transform.position, Quaternion.identity);
                    FunnyBoom.transform.localScale = Vector3.one * 5f;
                    transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                    HitCounter++;
                    gameObject.SetActive(false);
                    Boomed = true;
                    gameObject.GetComponent<IsExploded>().Exploded = true;
                }
                ok = false;
            }
            if (gameObject.GetComponent<SpriteButton>().clicked == false)
            {
                ok = true;
            }
        }
    }
}
