using System.Collections;
using UnityEngine;

public class CoolBoomFontIdeea : MonoBehaviour
{
    Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        while(1>0)
        {
            transform.position = new Vector3(1000, 1000, 0);
            yield return new WaitForSeconds(1f);
            transform.position = pos;
            yield return new WaitForSeconds(1f);
        }
    }
}
