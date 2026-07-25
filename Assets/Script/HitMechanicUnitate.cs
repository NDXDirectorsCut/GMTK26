using UnityEngine;

public class HitMechanicUnitate : MonoBehaviour
{
    public GameObject FirstUnit, SecondUnit;
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
                if (HitCounter == 3)
                {
                    FirstUnit.SetActive(true);
                    HitCounter++;
                }
                if (HitCounter == 8)
                {
                    FirstUnit.SetActive(false);
                    SecondUnit.SetActive(true);
                    transform.position = new Vector3 (transform.position.x-1, transform.position.y, transform.position.z);
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
