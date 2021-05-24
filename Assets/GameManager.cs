using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform endPointTransform;
    public GameObject baseExplosionEffect;
    private bool gameEnded = false;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

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

    public void WinLevel() 
    {
        Debug.Log("Win!!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        SceneManager.LoadScene(levelToUnlock+1);
    }
}
