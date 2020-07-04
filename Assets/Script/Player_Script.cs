using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour{

    public Text current_level;

    public static Player_Script instance;

    void Start(){

        if(instance == null){
            instance = this;
        }  

    } //end void start



    void Update(){

        
        
    } //end void update


}
