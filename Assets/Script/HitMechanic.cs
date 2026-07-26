using UnityEngine;

public class HitMechanic : MonoBehaviour
{
    public GameObject FirstScreen,SecondScreen;
    public int HitCounter = 0;
    bool ok = true;
    public GameObject Explosion;
    public bool Boomed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HitCounter < 9)
        {
            if(ok == true)
            {
                if (gameObject.GetComponent<SpriteButton>().clicked == true)
                    HitCounter++;
                if (HitCounter == 3)
                {
                    FirstScreen.SetActive(true);
                    HitCounter++;
                }
                if (HitCounter == 8)
                {
                    FirstScreen.SetActive(false);
                    SecondScreen.SetActive(true);
                    HitCounter++;
                    GameObject FunnyBoom = Instantiate(Explosion, transform.position, Quaternion.identity);
                    FunnyBoom.transform.localScale = Vector3.one * 10f;
                    Boomed = true;
                    gameObject.GetComponent<IsExploded>().Exploded = true;
                }
                ok = false;
            }
            if(gameObject.GetComponent<SpriteButton>().clicked == false)
            {
                ok = true;
            }
        }
    }
}
