using UnityEngine;

public class HitMechanic : MonoBehaviour
{
    public GameObject FirstScreen,SecondScreen;
    public int HitCounter = 0;
    bool ok = true;
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
