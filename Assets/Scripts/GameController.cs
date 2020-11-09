using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool gameEnded ;
    public static bool gameStarted ;

    public GameObject gameOverScreen;


    private void Start() {
        gameEnded = false;
        gameStarted= false;
    }

    private void Update() {
        if(gameEnded)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy Cell");
        if(enemies.Length == 0)
        {
            StartCoroutine(EndLevel());
        }

    }

    IEnumerator EndLevel()
    {
        gameEnded=true;
        yield return new WaitForSeconds(1.0f);
        gameOverScreen.SetActive(true);
    }

}
