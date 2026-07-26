using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WInConditionPC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> ObjNeeded = new();
    public List<GameObject> ObjNotNeeded = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int cnt = ObjNeeded.Count;
        int ok = 0;
        foreach (GameObject obj in ObjNeeded)
            if (obj.GetComponent<IsExploded>().Exploded == true)
                ok++;
        foreach (GameObject obj in ObjNotNeeded)
        {
            if (obj.GetComponent<IsExploded>().Exploded == true)
            {
                gameObject.GetComponent<MinigameLogic>().successed = false;
                gameObject.GetComponent<MinigameLogic>().failed = true;
            }
        }
        if(ok == cnt && gameObject.GetComponent<MinigameLogic>().failed == false)
            gameObject.GetComponent<MinigameLogic>().successed = true;
    }
}
