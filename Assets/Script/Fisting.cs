using UnityEngine;

public class Fisting : MonoBehaviour
{
    Animator Animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetTrigger("OnClick");
        }
    }
}
