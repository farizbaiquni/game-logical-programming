using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Compare_Script : MonoBehaviour{
    
    public Image BarTimer;
    public float maxTimer;
    public float timerLeft;

    public int current_point, poin_next_level;

    public Text text_current_poin, text_current_level, text_next_level;

    public Text text_variabel_1, text_variabel_2, text_variabel_3, text_logika;

    public GameObject tanda_tanya_1, tanda_tanya_2, tanda_tanya_3;

    bool variabel_1, variabel_2;

    bool hasil_logika; 
    
    public static Compare_Script instance;


    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }


    void Start(){

        current_point = 0;

        text_current_poin.text = "0";

        AdjustDifficult(PlayerPrefs.GetInt("Level"));

        Leveling(PlayerPrefs.GetInt("Level"));

        timerLeft = maxTimer;
        
    } // end void start





    void Update(){
        

        if(timerLeft > 0f){

            timerLeft -= Time.deltaTime;

            BarTimer.fillAmount = timerLeft / maxTimer;

            if(current_point == poin_next_level){

                Success_Logika_Script.instance.Success();

            }

        } else {

            Failed_Script.instance.Failed();

        }
        
    } // end void update





    void logikaOR(){

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        text_logika.text = "OR";

        bool hasil_or;

        int jenis_soal = Random.Range(0, 4);

        switch(jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                RandomVariabel();

                hasil_or = variabel_1 || variabel_2;

                while( ((true || variabel_2) == hasil_or) && ((false || variabel_2) == hasil_or) ){

                    RandomVariabel();

                    hasil_or = variabel_1 || variabel_2;

                }

                GantiTextSoal(hasil_or);

                hasil_logika = variabel_1;

                break;


            case 1:

                tanda_tanya_2.SetActive(true);

                RandomVariabel();

                hasil_or = variabel_1 || variabel_2;

                while( ((true || variabel_1) == hasil_or) && ((false || variabel_1) == hasil_or) ){

                    RandomVariabel();

                    hasil_or = variabel_1 || variabel_2;

                }

                GantiTextSoal(hasil_or);

                hasil_logika = variabel_2;

                break;
            

            case int n when( n == 2 || n == 3 ):

                tanda_tanya_3.SetActive(true);

                RandomVariabel();

                hasil_logika = variabel_1 || variabel_2;

                GantiTextSoal(hasil_logika);

                break;
        }
    } // end logikaOR






    void logikaAND(){

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        text_logika.text = "AND";

        bool hasil_and;

        int jenis_soal = Random.Range(0, 4);

        switch(jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                RandomVariabel();

                hasil_and = variabel_1 && variabel_2;

                while( ((true && variabel_2) == hasil_and) && ((false && variabel_2) == hasil_and) ){

                    RandomVariabel();

                    hasil_and = variabel_1 && variabel_2;

                }

                GantiTextSoal(hasil_and);

                hasil_logika = variabel_1;

                break;


            case 1:

                tanda_tanya_2.SetActive(true);

                RandomVariabel();

                hasil_and = variabel_1 && variabel_2;

                while( ((true && variabel_1) == hasil_and) && ((false && variabel_1) == hasil_and) ){

                    RandomVariabel();

                    hasil_and = variabel_1 && variabel_2;

                }

                GantiTextSoal(hasil_and);

                hasil_logika = variabel_2;

                break;
            

            case int n when(n == 2 || n == 3):

                tanda_tanya_3.SetActive(true);

                RandomVariabel();

                hasil_logika = variabel_1 && variabel_2;

                GantiTextSoal(hasil_logika);

                break;
        }
    } // end logikaAND





    void logikaNOT(){

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        text_logika.text = "NOT";

        bool hasil_not;

        int jenis_soal = Random.Range(0, 4);

        switch(jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                RandomVariabel();

                hasil_not = variabel_1 != variabel_2;

                while( ((true != variabel_2) == hasil_not) && ((false != variabel_2) == hasil_not) ){

                    RandomVariabel();

                    hasil_not = variabel_1 != variabel_2;

                }

                GantiTextSoal(hasil_not);

                hasil_logika = variabel_1;

                break;


            case 1:

                tanda_tanya_2.SetActive(true);

                RandomVariabel();

                hasil_not = variabel_1 != variabel_2;

                while( ((true != variabel_1) == hasil_not) && ((false != variabel_1) == hasil_not) ){

                    RandomVariabel();

                    hasil_not = variabel_1 != variabel_2;

                }

                GantiTextSoal(hasil_not);

                hasil_logika = variabel_2;

                break;
            

            case int n when(n == 2 || n == 3):

                tanda_tanya_3.SetActive(true);

                RandomVariabel();

                hasil_logika = variabel_1 != variabel_2;

                GantiTextSoal(hasil_logika);

                break;
        }
    } // end logikaNOT




    void RandomVariabel(){

        if(Random.Range(0,2) == 0){
            variabel_1 = false;
        } else {
            variabel_1 = true;
        }


        if(Random.Range(0,2) == 0){
            variabel_2 = false;
        } else {
            variabel_2 = true;
        }

    } // end RandomVariabel





    void GantiTextSoal(bool hasil){

        text_variabel_1.text = variabel_1.ToString();

        text_variabel_2.text = variabel_2.ToString();

        text_variabel_3.text = hasil.ToString();

    } // end GantiTextSoal




    public void Jawaban_True(){

        if(hasil_logika == true){
            current_point++;
            text_current_poin.text = current_point.ToString();
        } else {
            if(current_point == 0){
                current_point = 0;
                text_current_poin.text = current_point.ToString();
            } else {
                current_point--;
                text_current_poin.text = current_point.ToString();
            }   
        }

        Leveling(PlayerPrefs.GetInt("Level"));

    }




    public void Jawaban_False(){

        if(hasil_logika == false){
            current_point++;
            text_current_poin.text = current_point.ToString();
        } else {
            if(current_point == 0){
                current_point = 0;
                text_current_poin.text = current_point.ToString();
            } else {
                current_point--;
                text_current_poin.text = current_point.ToString();
            } 
        }

        Leveling(PlayerPrefs.GetInt("Level"));

    }






    void Leveling(int level_player){

        text_current_level.text = PlayerPrefs.GetInt("Level").ToString();

        text_next_level.text = poin_next_level.ToString();

        switch(level_player){

            case int n when(n < 7):
                SceneManager.LoadScene(1);
                break;

            case 7:
                logikaOR();
                break;

            case 8:
                logikaAND();
                break;

            case 9:
                logikaNOT();
                break;

            case 10:
                int jenis_soal = Random.Range(0, 3);

                switch(jenis_soal){

                    case 0:
                        logikaOR();
                        break;
                    
                    case 1:
                        logikaAND();
                        break;

                    case 2:
                        logikaNOT();
                        break;
                }

                break;

            case int n when(n > 10):
                SceneManager.LoadScene(0);
                break;


        }

    }



    public void AdjustDifficult(int level_player){

        switch(level_player){
            
            case int n when( n >= 7 && n <= 10 ):
                maxTimer = 20f;
                poin_next_level = 3;
                break;

        }      
    } // end AdjustDifficult

    

}
