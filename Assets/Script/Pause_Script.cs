using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Script : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject Panel_Pause;

    public GameObject Panel_Game;

    int index_scene;

    
    void Start(){
        
    }

    
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
        
                Resume();
            
            } else {
            
                Pause();
            
            }
        }  
    }


    public void TekanPause(){

        if(GameIsPaused){
        
            Resume();
            
        } else {
            
            Pause();
            
        }
    }


    public void Resume(){
        Panel_Pause.SetActive(false);
        Panel_Game.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    public void Pause(){
        Panel_Pause.SetActive(true);
        Panel_Game.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestateGame(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        IndexScene();
        SceneManager.LoadScene(index_scene);
        
    }


    public void MainMenuGame(){
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }


    void IndexScene(){

        switch(PlayerPrefs.GetInt("Level")){
            case int n when( n >= 0 && n <= 6):
                index_scene = 1;
                break;

            case int n when(n > 5 && n <=10):
                index_scene = 2;
                break;
            
            case int n when(n > 10 && n <=15):
                index_scene = 3;
                break;

            default:
                index_scene = 0;
                break;
        }

    }


}
