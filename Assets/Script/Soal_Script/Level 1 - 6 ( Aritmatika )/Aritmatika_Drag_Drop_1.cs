using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aritmatika_Drag_Drop_1 : MonoBehaviour{
    

    public GameObject current_form;

    private bool moving;

    private bool finish;

    private float start_pos_x;

    private float start_pos_y;

    private Vector3 reset_position;


    void Start(){
        
        reset_position = this.transform.localPosition;

    }

    
    void Update() { 

        if (finish == false){
            if(moving){
                Vector3 mouse_pos;
                mouse_pos = Input.mousePosition;
                mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

                this.gameObject.transform.localPosition = new Vector3 (mouse_pos.x - start_pos_x, mouse_pos.y - start_pos_y,this.gameObject.transform.localPosition.z);

            }
        }        
    }


    private void OnMouseDown(){

        if(Input.GetMouseButtonDown(0)){
            Vector3 mouse_pos;
            mouse_pos = Input.mousePosition;
            mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);

            start_pos_x = mouse_pos.x - this.transform.localPosition.x;
            start_pos_y = mouse_pos.y - this.transform.localPosition.y;

            moving = true;

        }       
    }




    private void OnMouseUp(){

        moving = false;

        if(Mathf.Abs(this.transform.localPosition.x - current_form.transform.localPosition.x) <= 0.5f && Mathf.Abs(this.transform.localPosition.y - current_form.transform.localPosition.y) <= 0.5f){
            
            this.transform.localPosition = new Vector3(current_form.transform.localPosition.x, current_form.transform.localPosition.y, current_form.transform.localPosition.z);

            finish = true;

        } else {

            this.transform.localPosition = new Vector3(reset_position.x, reset_position.y, reset_position.z);

         }
    }

}
