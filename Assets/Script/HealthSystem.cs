using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject heartContainer;
    public float dist = 1.5f;
    public GameObject damageEffect;
    MinigameSpawner gameManager;
    int livesCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = transform.root.GetComponentInChildren<MinigameSpawner>();
        livesCount = gameManager.lives;
        PlaceHearts();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(livesCount != gameManager.lives && gameManager.lives<livesCount)
        {
            RemoveHeart();
        }
        livesCount = gameManager.lives;
    }

    void PlaceHearts()
    {
        for(int i=0; i<livesCount; i++)
        {
            Vector3 offset = new Vector3(i*dist,0,0);
            GameObject newHeart = Instantiate(heartContainer,transform.position+offset,Quaternion.identity);
            newHeart.transform.parent = transform;
        }
    }

    void RemoveHeart()
    {
        Transform heart = transform.GetChild(gameManager.lives);
        GameObject tempEffect = Instantiate(damageEffect,heart.position,Quaternion.identity);
        Destroy(heart.gameObject,.1f);
        Destroy(tempEffect,2f);
    }
}
