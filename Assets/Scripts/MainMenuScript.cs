using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GameObject pauseGame;
    public static bool IsPaused;
    public static bool BackToM = false;
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
        Time.timeScale = 1f;
    }

    public void ResetGame(){
        SceneManager.LoadScene(1);
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
