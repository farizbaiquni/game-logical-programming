﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_Script : MonoBehaviour{

    void Start(){

        
    } 



    void Update(){
        
    } 


    public void Play(){
        
        if(PlayerPrefs.GetInt("Level") == 0){
            PlayerPrefs.SetInt("Level", 1);
        } 


        switch(PlayerPrefs.GetInt("Level")){

            case int n when( n >= 1 && n <=6):
                SceneManager.LoadScene(1);
                break;

            case int n when( n > 6 && n <= 10):
                SceneManager.LoadScene(2);
                break;
            
            case int n when( n > 10 && n <= 15):
                SceneManager.LoadScene(3);
                break;

            default:
                SceneManager.LoadScene(0);
                break;

        }
    }

}
