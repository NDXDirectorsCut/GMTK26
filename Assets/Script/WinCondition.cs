using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WinCondition : MonoBehaviour
{
    public List<GameObject> RedWires = new();
    public List<GameObject> GreenWires = new();
    public GameObject Bandicam;
    public GameObject Explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int nrFire = RedWires.Count;
        int k = 0;
        foreach (var w in RedWires)
        {
            if (w.activeSelf == false)
            {
                k++;
            }
            if (k == nrFire)
            {
                Bandicam.SetActive(false);
                gameObject.GetComponent<MinigameLogic>().successed = true;
            }
        }
        foreach (var w in GreenWires)
        {
            if (w.activeSelf == false)
            {
                GameObject FunnyBoom = Instantiate(Explosion, Vector3.zero,Quaternion.identity);
                FunnyBoom.transform.localScale = Vector3.one * 85f;
                Destroy(FunnyBoom,2.5f);
                gameObject.GetComponent<MinigameLogic>().successed = false;
                gameObject.GetComponent<MinigameLogic>().failed = true;
            }
        }
    }
}
