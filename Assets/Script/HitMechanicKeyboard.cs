using UnityEngine;

public class HitMechanicKeyboard : MonoBehaviour
{
    public GameObject FirstKey, SecondKey,ThirdKey;
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
            if (ok == true)
            {
                if (gameObject.GetComponent<SpriteButton>().clicked == true)
                    HitCounter++;
                if (HitCounter == 1)
                {
                    FirstKey.SetActive(true);
                    HitCounter++;
                }
                if (HitCounter == 4)
                {
                    FirstKey.SetActive(false);
                    SecondKey.SetActive(true);
                    HitCounter++;
                }
                if(HitCounter == 8)
                {
                    SecondKey.SetActive(false);
                    ThirdKey.SetActive(true);
                    HitCounter++;
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
