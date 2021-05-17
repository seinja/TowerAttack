using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform endPointTransform;
    public GameObject baseExplosionEffect;
    private bool gameEnded = false;

    public GameObject GameOverUI;

    void Update()
    {
        if (gameEnded) return;

        if (PlayerStats.Lives <= 0) 
        {
            EndGame();
        }

        
    }

    void EndGame() 
    {
        GameOverUI.SetActive(true);
        GameObject baseExplosion = (GameObject)Instantiate(baseExplosionEffect, endPointTransform.position, Quaternion.identity);
        Destroy(baseExplosion, 0.9f);
        gameEnded = true;
        Debug.Log("GameOver");
        
    }
}
