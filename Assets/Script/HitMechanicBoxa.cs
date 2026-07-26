using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HitMechanicBoxa : MonoBehaviour
{
    public GameObject Explosion;
    public bool Boomed = false;
    bool ok = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SpriteButton>().clicked == true && ok == true)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
            StartCoroutine(Boom());
            ok = false;
            Boomed = true;
            gameObject.GetComponent<IsExploded>().Exploded = true;
        }
    }
    IEnumerator Boom()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(15f);
    }
}
