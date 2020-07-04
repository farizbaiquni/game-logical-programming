using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Failed_Script : MonoBehaviour{

    public static Failed_Script instance;

    public GameObject panel_failed;

    public GameObject panel_game;

    int index_scene;
    
    void Awake(){

        if(instance == null){
            instance = this;
        }
        
    }



    public void Failed(){

        panel_game.SetActive(false);

        panel_failed.SetActive(true);

    }



    public void Restate(){

        IndexScene();
    
        SceneManager.LoadScene(index_scene);

    }


    public void Main_Menu(){

        Compare_Script.instance.current_point = 0;

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);

    }


    void IndexScene(){

        switch(PlayerPrefs.GetInt("Level")){
            case int n when( n >= 0 && n <= 6):
                index_scene = 1;
                break;

            case int n when(n > 6 && n <= 10):
                index_scene = 2;
                break;

            case int n when(n > 10 && n <= 15):
                index_scene = 3;
                break;
        }

    }



}
