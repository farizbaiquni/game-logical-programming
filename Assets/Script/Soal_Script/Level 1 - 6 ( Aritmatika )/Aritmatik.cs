using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Aritmatik : MonoBehaviour{

    public Image BarTimer;
    public float maxTimer;
    public float timerLeft;

    public int current_poin, poin_next_level;

    public Text text_current_level, text_current_poin, text_next_level;

    private int variabel_1, variabel_2, hasil;

    public Text var_1, var_2, var_3, simbol, penyataan_soal, opsi_1_text, opsi_2_text, opsi_3_text;

    private int opsi_1, opsi_2, opsi_3;

    public GameObject tanda_tanya_1, tanda_tanya_2, tanda_tanya_3;

    public static Aritmatik instance;



    private void Awake() {
        
        if(instance == null){
            instance = this;
        }

    }


    void Start(){

        current_poin = 0;

        text_current_poin.text = "0";

        AdjustDifficult(PlayerPrefs.GetInt("Level"));

        Leveling(PlayerPrefs.GetInt("Level"));

        timerLeft = maxTimer;
        
    }

    
    void Update(){

        text_current_level.text = PlayerPrefs.GetInt("Level").ToString();

        if(timerLeft > 0f){

            timerLeft -= Time.deltaTime;

            BarTimer.fillAmount = timerLeft / maxTimer;

            if(current_poin == poin_next_level){

                Success_Aritmatik_Script.instance.Success();

            }

        } else {

            Failed_Aritmatik_Script.instance.Failed();

        }
        
    }


    public void SoalTambah(){

        int opsi_salah_1, opsi_salah_2;

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        variabel_1 = Random.Range(0, 25);

        variabel_2 = Random.Range(0, 25);

        int jenis_soal = Random.Range(0, 3);

        int hasil_pertambahan;

        simbol.text = "+";  
        
        switch (jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                hasil_pertambahan = variabel_1 + variabel_2;

                var_2.text = variabel_2.ToString();

                var_3.text = hasil_pertambahan.ToString();

                hasil = variabel_1;

                opsi_salah_1 = hasil + Random.Range(1,10);

                opsi_salah_2 = hasil + Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);            

                break;

            case 1 :

                tanda_tanya_2.SetActive(true);

                hasil_pertambahan = variabel_1 + variabel_2;

                var_1.text = variabel_1.ToString();

                var_3.text = hasil_pertambahan.ToString();

                hasil = variabel_2;

                opsi_salah_1 = variabel_2 + Random.Range(1,10);

                opsi_salah_2 = variabel_2 + Random.Range(1,10);  

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }            

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;

            case 2:

                tanda_tanya_3.SetActive(true);

                var_1.text = variabel_1.ToString();

                var_2.text = variabel_2.ToString();

                hasil = variabel_1 + variabel_2;

                opsi_salah_1 = hasil - Random.Range(1,10);

                opsi_salah_2 = hasil - Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;
     
        } // end switch      
    
    } // end soal tambah

    




    public void SoalKurang(){

        int opsi_salah_1, opsi_salah_2;

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        simbol.text = "-";

        variabel_1 = Random.Range(0, 20);

        variabel_2 = Random.Range(0, 20);

        int jenis_soal = Random.Range(0, 3);

        int hasil_pengurangan;  
        
        switch (jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                hasil_pengurangan = variabel_1 - variabel_2;

                var_2.text = variabel_2.ToString();

                var_3.text = hasil_pengurangan.ToString();

                hasil = variabel_1;

                opsi_salah_1 = hasil + Random.Range(1,10);

                opsi_salah_2 = hasil + Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);            

                break;

            case 1 :

                tanda_tanya_2.SetActive(true);

                hasil_pengurangan = variabel_1 - variabel_2;

                var_1.text = variabel_1.ToString();

                var_3.text = hasil_pengurangan.ToString();

                hasil = variabel_2;

                opsi_salah_1 = variabel_2 + Random.Range(1,10);

                opsi_salah_2 = variabel_2 + Random.Range(1,10);

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }              

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;

            case 2:

                tanda_tanya_3.SetActive(true);

                var_1.text = variabel_1.ToString();

                var_2.text = variabel_2.ToString();

                hasil = variabel_1 - variabel_2;

                opsi_salah_1 = hasil - Random.Range(1,10);

                opsi_salah_2 = hasil - Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;
     
        } // end switch      
    
    } // end soal kurang



    public void soalPerkalian(){

        int opsi_salah_1, opsi_salah_2;

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        simbol.text = "x";

        variabel_1 = Random.Range(1, 10);

        variabel_2 = Random.Range(1, 10);

        int jenis_soal = Random.Range(0, 3);

        int hasil_perkalian; 
        
        switch (jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                hasil_perkalian = variabel_1 * variabel_2;

                var_2.text = variabel_2.ToString();

                var_3.text = hasil_perkalian.ToString();

                hasil = variabel_1;

                opsi_salah_1 = hasil + Random.Range(1,4);

                opsi_salah_2 = hasil + Random.Range(1,4); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);            

                break;

            case 1 :

                tanda_tanya_2.SetActive(true);

                hasil_perkalian = variabel_1 * variabel_2;

                var_1.text = variabel_1.ToString();

                var_3.text = hasil_perkalian.ToString();

                hasil = variabel_2;

                opsi_salah_1 = variabel_2 + Random.Range(1,4);

                opsi_salah_2 = variabel_2 + Random.Range(1,4);

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }              

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;

            case 2:

                tanda_tanya_3.SetActive(true);

                var_1.text = variabel_1.ToString();

                var_2.text = variabel_2.ToString();

                hasil = variabel_1 * variabel_2;

                opsi_salah_1 = hasil - Random.Range(1,4);

                opsi_salah_2 = hasil - Random.Range(1,4); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;
     
        } // end switch      
    
    } // end soal perkalian






    public void soalPembagian(){

        int opsi_salah_1, opsi_salah_2;

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        simbol.text = ":";

        variabel_1 = Random.Range(1, 50);

        variabel_2 = Random.Range(1, 50);

        while(variabel_1 % variabel_2 != 0){

            variabel_1 = Random.Range(1, 50);

            variabel_2 = Random.Range(1, 50);

        }


        int jenis_soal = Random.Range(0, 4);

        int hasil_pembagian; 
        
        switch (jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                hasil_pembagian = variabel_1 / variabel_2;

                var_2.text = variabel_2.ToString();

                var_3.text = hasil_pembagian.ToString();

                hasil = variabel_1;

                opsi_salah_1 = hasil + Random.Range(1,4);

                opsi_salah_2 = hasil + Random.Range(1,4); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);            

                break;

            case 1 :

                tanda_tanya_2.SetActive(true);

                hasil_pembagian = variabel_1 / variabel_2;

                var_1.text = variabel_1.ToString();

                var_3.text = hasil_pembagian.ToString();

                hasil = variabel_2;

                opsi_salah_1 = variabel_2 + Random.Range(1,4);

                opsi_salah_2 = variabel_2 + Random.Range(1,4);

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }              

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;

            case int n when( n == 2 || n == 3):

                tanda_tanya_3.SetActive(true);

                var_1.text = variabel_1.ToString();

                var_2.text = variabel_2.ToString();

                hasil = variabel_1 / variabel_2;

                opsi_salah_1 = hasil - Random.Range(1,4);

                opsi_salah_2 = hasil - Random.Range(1,4); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,4);

                    opsi_salah_2 = hasil + Random.Range(1,4); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;
     
        } // end switch      
    
    } // end soal pembagian






    public void soalSisa(){

        int opsi_salah_1, opsi_salah_2;

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);

        simbol.text = "%";

        variabel_1 = Random.Range(1, 50);

        variabel_2 = Random.Range(1, 50);

        while(variabel_1 < variabel_2){

            variabel_1 = Random.Range(1, 50);

            variabel_2 = Random.Range(1, 50);
        }

        int jenis_soal = Random.Range(0, 3);

        int hasil_sisa; 
        
        switch (jenis_soal){

            case 0:

                tanda_tanya_1.SetActive(true);

                hasil_sisa = variabel_1 % variabel_2;

                var_2.text = variabel_2.ToString();

                var_3.text = hasil_sisa.ToString();

                hasil = variabel_1;

                opsi_salah_1 = hasil + Random.Range(1,10);

                opsi_salah_2 = hasil + Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2 || opsi_salah_1 % variabel_2 == hasil_sisa || opsi_salah_2 % variabel_2 == hasil_sisa){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }


                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);            

                break;

            
            
            case 1 :

                tanda_tanya_2.SetActive(true);

                hasil_sisa = variabel_1 % variabel_2;

                var_1.text = variabel_1.ToString();

                var_3.text = hasil_sisa.ToString();

                hasil = variabel_2;

                opsi_salah_1 = variabel_2 + Random.Range(1,10);

                opsi_salah_2 = variabel_2 + Random.Range(1,10);

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }              

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;

            case 2:

                tanda_tanya_3.SetActive(true);

                var_1.text = variabel_1.ToString();

                var_2.text = variabel_2.ToString();

                hasil = variabel_1 % variabel_2;

                opsi_salah_1 = hasil - Random.Range(1,10);

                opsi_salah_2 = hasil - Random.Range(1,10); 

                while(opsi_salah_1 == opsi_salah_2){

                    opsi_salah_1 = hasil + Random.Range(1,10);

                    opsi_salah_2 = hasil + Random.Range(1,10); 

                }

                RandomOpsiJawaban(opsi_salah_1, opsi_salah_2);

                break;
     
        } // end switch      
    
    } // end soal sisa






    void RandomOpsiJawaban(int opsi_salah_1, int opsi_salah_2){

        int index_opsi;

        string[] array_opsi = {"opsi_1_text", "opsi_2_text", "opsi_3_text"};

        System.Random random = new System.Random();

        index_opsi = random.Next(0, array_opsi.Length);

        if(array_opsi[index_opsi] == "opsi_1_text"){

            opsi_1_text.text = hasil.ToString();

            opsi_1 = hasil;

            if (Random.Range(0, 2) == 0){

                opsi_2_text.text = opsi_salah_1.ToString();

                opsi_3_text.text = opsi_salah_2.ToString();

            } else {

                opsi_2_text.text = opsi_salah_2.ToString();

                opsi_3_text.text = opsi_salah_1.ToString();

            }

        } else if(array_opsi[index_opsi] == "opsi_2_text") {

            opsi_2_text.text = hasil.ToString();
            
            opsi_2 = hasil;

            if (Random.Range(0, 2) == 0){

                opsi_1_text.text = opsi_salah_1.ToString();

                opsi_3_text.text = opsi_salah_2.ToString();

            } else {

                opsi_1_text.text = opsi_salah_2.ToString();

                opsi_3_text.text = opsi_salah_1.ToString();

            }

        } else if(array_opsi[index_opsi] == "opsi_3_text") {

            opsi_3_text.text = hasil.ToString();

            opsi_3 = hasil;

            if (Random.Range(0, 2) == 0){

                opsi_1_text.text = opsi_salah_1.ToString();

                opsi_2_text.text = opsi_salah_2.ToString();

            } else {

                opsi_1_text.text = opsi_salah_2.ToString();

                opsi_2_text.text = opsi_salah_1.ToString();

            }
        }
    }





    public void JawabOpsiSatu(){

        if(hasil == opsi_1){
            current_poin++;
            text_current_poin.text = current_poin.ToString();
        } else {
            if(current_poin == 0){
                current_poin = 0;
                text_current_poin.text = current_poin.ToString();
            } else {
                current_poin--;
                text_current_poin.text = current_poin.ToString();
            } 
        }

        Leveling(PlayerPrefs.GetInt("Level"));
    }


    public void JawabOpsiDua(){

        if(hasil == opsi_2){
            current_poin++;
            text_current_poin.text = current_poin.ToString();
        } else {
            if(current_poin == 0){
                current_poin = 0;
                text_current_poin.text = current_poin.ToString();
            } else {
                current_poin--;
                text_current_poin.text = current_poin.ToString();
            } 
        }

        Leveling(PlayerPrefs.GetInt("Level"));
    }



    public void JawabOpsiTiga(){

        if(hasil == opsi_3){
            current_poin++;
            text_current_poin.text = current_poin.ToString();
        } else {
            if(current_poin == 0){
                current_poin = 0;
                text_current_poin.text = current_poin.ToString();
            } else {
                current_poin--;
                text_current_poin.text = current_poin.ToString();
            } 
        }

        Leveling(PlayerPrefs.GetInt("Level"));
    }



    void Leveling(int level_player){

        text_current_level.text = PlayerPrefs.GetInt("Level").ToString();

        text_next_level.text = poin_next_level.ToString();

        switch(level_player){

            case 1:
                SoalTambah();
                break;

            case 2:
                SoalKurang();
                break;

            case 3:
                soalPerkalian();
                break;

            case 4:
                soalPembagian();
                break;

            case 5:
                soalSisa();
                break;
            

            case 6:
                int jenis_soal = Random.Range(0, 5);

                switch(jenis_soal){

                    case 0:
                        SoalTambah();
                        break;

                    case 1:
                        SoalKurang();
                        break;

                    case 2:
                        soalPerkalian();
                        break;

                    case 3:
                        soalPembagian();
                        break;

                    case 4:
                        soalSisa();
                        break;
                }

                break;

            case int n when(n>10):
                SceneManager.LoadScene(0);
                break;

            case int n when(n>6):
                SceneManager.LoadScene(2);
                break;

        }

    }





    public void AdjustDifficult(int level_player){

        switch(level_player){
            case int n when( n >= 1 && n <= 6):
                maxTimer = 20f;
                poin_next_level = 3;
                break;

        }  

    }

}
