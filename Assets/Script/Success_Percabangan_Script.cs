using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Success_Percabangan_Script : MonoBehaviour{

    public static Success_Percabangan_Script instance;

    public GameObject panel_success, panel_game;

    int index_scene;

    
    void Awake(){

        if(instance == null){
            instance = this;
        }
        
    } // end awake



    public void Success(){

        Time.timeScale = 0f;

        panel_game.SetActive(false);

        panel_success.SetActive(true);

    }




    public void Next(){

        Percabangan_Script.instance.current_point = 0;

        Time.timeScale = 1f;

        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        IndexScene();

        SceneManager.LoadScene(index_scene);

    }



    public void Restate(){

        Percabangan_Script.instance.current_point = 0;

        Time.timeScale = 1f;

        IndexScene();

        SceneManager.LoadScene(index_scene);

    }


    public void Main_Menu(){

        Percabangan_Script.instance.current_point = 0;

        Time.timeScale = 1f;

        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

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
