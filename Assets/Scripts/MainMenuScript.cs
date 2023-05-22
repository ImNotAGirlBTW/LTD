using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GameObject pauseGame;
    public static bool IsPaused;
    void Start()
    {
        pauseGame.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
    if(IsPaused){
        ResumeGame();
    }else{
        PauseGame();
    }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    
   public void ResetGame(){
        SceneManager.LoadScene(1);
        PlayerHealth.health = 4;
        ResumeGame();
    }   

    public void ResumeGame()
    {
        Cursor.visible = false;
        pauseGame.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void PauseGame()
    {
        Cursor.visible = true;
           IsPaused = true;
            pauseGame.SetActive(true);
            Time.timeScale = 0f;
    }
}
