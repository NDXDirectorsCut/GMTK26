using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WInConditionPC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> ObjNeeded = new();
    public List<GameObject> ObjNotNeeded = new();
    public GameObject Explosion;
    bool boobed = true;
    int cnt, ok;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cnt = ObjNeeded.Count;
        ok = 0;

        foreach (GameObject obj in ObjNeeded)
            if (obj.GetComponent<IsExploded>().Exploded == true)
                ok++;
        foreach (GameObject obj in ObjNotNeeded)
        {
            if (obj.GetComponent<IsExploded>().Exploded == true && boobed == true)
            {
                gameObject.GetComponent<MinigameLogic>().successed = false;
                gameObject.GetComponent<MinigameLogic>().failed = true;
                GameObject FunnyBoom = Instantiate(Explosion, Vector3.zero, Quaternion.identity);
                FunnyBoom.transform.localScale = Vector3.one * 85f;
                Destroy(FunnyBoom, 2.5f);
                boobed = false;
            }
        }
        if (ok == cnt && gameObject.GetComponent<MinigameLogic>().failed == false)
        {

            gameObject.GetComponent<MinigameLogic>().successed = true;
        }
    }
}
