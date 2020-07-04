using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Percabangan_Script : MonoBehaviour {

    public static Percabangan_Script instance;

    public Image BarTimer;
    public float maxTimer;
    public float timerLeft;

    public int current_point, poin_next_level;

    public Text text_current_poin, text_current_level, text_next_level;

    public Text text_var_1_x, text_var_2_y, text_var_3, text_var_4, text_var_5, text_var_6, text_var_7, text_konjungsi_1, text_konjungsi_2, text_konjungsi_3, text_konjungsi_4, text_konjungsi_5, text_print_1, text_print_2, text_print_3, text_tampil;

    public GameObject tanda_tanya_1, tanda_tanya_2, tanda_tanya_3, tanda_tanya_6, tanda_tanya_8, tanda_tanya_9, tanda_tanya_10, tanda_tanya_11, tanda_tanya_12, tanda_tanya_13;

    string print_1, print_2, print_3, tampil;

    string konjungsi_1, konjungsi_2, konjungsi_3, konjungsi_4;

    // Variabel untuk jenis soal boolean
    bool bool_var_1_x, bool_var_2_y, bool_var_3, bool_var_4, bool_var_5, bool_var_6, bool_var_7, bool_kunci, bool_kunci_jawaban;


    // Bantuan
    string[] array_operator_logika = {"||", "&&", "!=", "=="};

    string[] array_operator_konjungsi = {"==", "!="};

    int index_operator_logika, index_operator_konjungsi, index_tanda_tanya;

    bool hasil_part_1, hasil_part_2, hasil_else_if;

    System.Random random = new System.Random();


    // Array yang ditampilkan

    string kata_print_salah_1, kata_print_salah_2, kata_print_kunci;

    
    
    void Awake() {

        if(instance == null){
            instance = this;
        }
        
    }


    void Start(){

        maxTimer = 100;

        current_point = 0;

        text_current_poin.text = "0";

        poin_next_level = 1;

        text_next_level.text = poin_next_level.ToString();

        text_current_level.text = PlayerPrefs.GetInt("Level").ToString();

        SoalBoolean();

        timerLeft = maxTimer;
        

    } // end void start

    


    void Update(){

        if(timerLeft > 0f){

            timerLeft -= Time.deltaTime;

            BarTimer.fillAmount = timerLeft / maxTimer;

            if(current_point == poin_next_level){

                Success_Percabangan_Script.instance.Success();

            }

        } else {

            Failed_Percabangan_Script.instance.Failed();

        }
        
        
    } // end void update



    void SoalBoolean(){

        tanda_tanya_1.SetActive(false);
        tanda_tanya_2.SetActive(false);
        tanda_tanya_3.SetActive(false);
        tanda_tanya_6.SetActive(false);
        tanda_tanya_8.SetActive(false);
        tanda_tanya_9.SetActive(false);
        tanda_tanya_10.SetActive(false);
        tanda_tanya_11.SetActive(false);
        tanda_tanya_12.SetActive(false);
        tanda_tanya_13.SetActive(false);

        int jenis_jawaban = Random.Range(0, 4);

        RandomKata();

        switch(jenis_jawaban){

            //Kunci Jawaban Untuk Benar Pada If
            case 0:
                JawabanPernyataanBenarIf();
                bool_kunci_jawaban = bool_kunci;
                switch(Random.Range(0, 2)){
                    case 0:
                        JawabanPernyataanBenarElseIf();
                        break;
                    
                    case 1:
                        JawabanPernyataanSalahElseIf();
                        break;
                }
                tanda_tanya_9.SetActive(false);
                tanda_tanya_10.SetActive(false);
                tanda_tanya_11.SetActive(false);

                text_print_1.text = kata_print_kunci;
                text_print_2.text = kata_print_salah_1;
                text_print_3.text = kata_print_salah_2;
                text_tampil.text = kata_print_kunci;
                
                break;

            //Kunci Jawaban Untuk Benar Pada Else If
            case 1:
                JawabanPernyataanBenarElseIf();
                bool_kunci_jawaban = bool_kunci;
                JawabanPernyataanSalahIf();

                tanda_tanya_1.SetActive(false);
                tanda_tanya_2.SetActive(false);
                tanda_tanya_3.SetActive(false);
                tanda_tanya_6.SetActive(false);

                text_print_1.text = kata_print_salah_1;
                text_print_2.text = kata_print_kunci;
                text_print_3.text = kata_print_salah_2;
                text_tampil.text = kata_print_kunci;

                break;
        

            //Kunci Jawaban Untuk Salah Pada If
            case 2:
                JawabanPernyataanSalahIf();
                bool_kunci_jawaban = bool_kunci;
                switch(Random.Range(0, 2)){
                    case 0:
                        JawabanPernyataanBenarElseIf();
                        text_print_1.text = kata_print_salah_1;
                        text_print_2.text = kata_print_kunci;
                        text_print_3.text = kata_print_salah_2;
                        text_tampil.text = kata_print_kunci;
                        break;
                    
                    case 1:
                        JawabanPernyataanSalahElseIf();
                        text_print_1.text = kata_print_salah_1;
                        text_print_2.text = kata_print_salah_2;
                        text_print_3.text = kata_print_kunci;
                        text_tampil.text = kata_print_kunci;
                        break;
                }
                tanda_tanya_9.SetActive(false);
                tanda_tanya_10.SetActive(false);
                tanda_tanya_11.SetActive(false);
                break;

            //Kunci Jawaban Untuk Salah Pada Else If
            case 3:
                JawabanPernyataanSalahElseIf();
                bool_kunci_jawaban = bool_kunci;

                JawabanPernyataanSalahIf();
                text_print_1.text = kata_print_salah_1;
                text_print_2.text = kata_print_salah_2;
                text_print_3.text = kata_print_kunci;
                text_tampil.text = kata_print_kunci;

                tanda_tanya_1.SetActive(false);
                tanda_tanya_2.SetActive(false);
                tanda_tanya_3.SetActive(false);
                tanda_tanya_6.SetActive(false);

                break;

        }


        text_var_1_x.text =  bool_var_1_x.ToString();
        text_var_2_y.text =  bool_var_2_y.ToString();
        text_var_3.text = bool_var_3.ToString();
        text_var_4.text = bool_var_4.ToString();
        text_var_5.text = bool_var_5.ToString();
        text_var_6.text = bool_var_6.ToString();
        text_var_7.text = bool_var_7.ToString();



    } // end void soalboolean






// ================================================================================================================================

    public void JawabanPernyataanSalahElseIf(){

        int index_part = Random.Range(0, 2);

        if(index_part == 0){

            RandomBoolVar5();
            RandomBoolVar6();
            RandomBoolVar7();

            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_5.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False Pertama
                        case 0:

                            tanda_tanya_9.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    // ? || true != false   -> cari yg salah
                                    while( ((bool_var_5 || bool_var_6) == bool_var_7) || (((true || bool_var_6) != bool_var_7) == ((false || bool_var_6) != bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    // ? && false != true   -> cari yg salah
                                    while( ((bool_var_5 && bool_var_6) == bool_var_7) || (((true && bool_var_6) != bool_var_7) == ((false && bool_var_6) != bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_5;
                            break;


                        // Tanda Tanya Pada False Kedua
                        case 1:

                            tanda_tanya_10.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) == bool_var_7) || (((true || bool_var_5) != bool_var_7) == ((false || bool_var_5) != bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) == bool_var_7) || (((true && bool_var_5) != bool_var_7) == ((false && bool_var_5) != bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_6;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                

                case 1 :

                    text_konjungsi_5.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False Pertama
                        case 0:
                            tanda_tanya_9.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    // ? || true == true     ->cari yg salah
                                    while( ((bool_var_5 || bool_var_6) != bool_var_7) || (((true || bool_var_6) == bool_var_7) == ((false || bool_var_6) == bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    // ? && false == false    -> cari yg salah
                                    while( ((bool_var_5 && bool_var_6) != bool_var_7) || (((true && bool_var_6) == bool_var_7) == ((false && bool_var_6) == bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_5;
                            break;


                        // Tanda Tanya Pada False Kedua
                        case 1:
                            tanda_tanya_10.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) != bool_var_7) || (((true || bool_var_5) == bool_var_7) == ((false || bool_var_5) == bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) != bool_var_7) || (((true && bool_var_5) == bool_var_7) == ((false && bool_var_5) == bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_6;
                            break;
                    } // end switch tanda tanya     
                
                    break;     
                    
            } // end konjungsi antar part
        
        } else {

            RandomBoolVar5();
            RandomBoolVar6();
            RandomBoolVar7();

            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:
                    text_konjungsi_5.text = "==";

                    tanda_tanya_11.SetActive(true);

                    index_operator_logika = random.Next(0, array_operator_logika.Length);

                    switch(index_operator_logika){
                        case 0:
                            text_konjungsi_4.text = "||";
                            while( (bool_var_5 || bool_var_6) != bool_var_7) {
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 1:
                            text_konjungsi_4.text = "&&";
                            while( (bool_var_5 && bool_var_6) != bool_var_7){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 2:
                            text_konjungsi_4.text = "!=";
                            while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 3:
                            text_konjungsi_4.text = "==";
                            while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        
                    }
                    bool_kunci = bool_var_7;
                    break;




                case 1:
                    text_konjungsi_5.text = "!=";

                    tanda_tanya_11.SetActive(true);

                    index_operator_logika = random.Next(0, array_operator_logika.Length);

                    switch(index_operator_logika){
                        case 0:
                            text_konjungsi_4.text = "||";
                            while( (bool_var_5 || bool_var_6) == bool_var_7) {
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 1:
                            text_konjungsi_4.text = "&&";
                            while( (bool_var_5 && bool_var_6) == bool_var_7){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 2:
                            text_konjungsi_4.text = "!=";
                            while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 3:
                            text_konjungsi_4.text = "==";
                            while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        
                    }
                    bool_kunci = bool_var_7;
                    break;
                    
            }

        }

    }



// ================================================================================================================================

    public void JawabanPernyataanBenarElseIf(){

        int index_part = Random.Range(0, 2);

        if(index_part == 0){

            RandomBoolVar5();
            RandomBoolVar6();
            RandomBoolVar7();

            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_5.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False Pertama
                        case 0:

                            tanda_tanya_9.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) != bool_var_7) || (((true || bool_var_6) == bool_var_7) == ((false || bool_var_6) == bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) != bool_var_7) || (((true && bool_var_6) == bool_var_7) == ((false && bool_var_6) == bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_5;
                            break;


                        // Tanda Tanya Pada False Kedua
                        case 1:

                            tanda_tanya_10.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) != bool_var_7) || (((true || bool_var_5) == bool_var_7) == ((false || bool_var_5) == bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) != bool_var_7) || (((true && bool_var_5) == bool_var_7) == ((false && bool_var_5) == bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_6;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                

                case 1 :

                    text_konjungsi_5.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False Pertama
                        case 0:
                            tanda_tanya_9.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) == bool_var_7) || (((true || bool_var_6) != bool_var_7) == ((false || bool_var_6) != bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) == bool_var_7) || (((true && bool_var_6) != bool_var_7) == ((false && bool_var_6) != bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_5;
                            break;


                        // Tanda Tanya Pada False Kedua
                        case 1:
                            tanda_tanya_10.SetActive(true);

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_4.text = "||";
                                    while( ((bool_var_5 || bool_var_6) == bool_var_7) || (((true || bool_var_5) != bool_var_7) == ((false || bool_var_5) != bool_var_7)) ) {
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_4.text = "&&";
                                    while( ((bool_var_5 && bool_var_6) == bool_var_7) || (((true && bool_var_5) != bool_var_7) == ((false && bool_var_5) != bool_var_7)) ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_4.text = "!=";
                                    while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_4.text = "==";
                                    while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                        RandomBoolVar5();
                                        RandomBoolVar6();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_6;
                            break;
                    } // end switch tanda tanya     
                
                    break;       
                    
            } // end konjungsi antar part
        
        } else {

            RandomBoolVar5();
            RandomBoolVar6();
            RandomBoolVar7();

            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:
                    text_konjungsi_5.text = "==";

                    tanda_tanya_11.SetActive(true);

                    index_operator_logika = random.Next(0, array_operator_logika.Length);

                    switch(index_operator_logika){
                        case 0:
                            text_konjungsi_4.text = "||";
                            while( (bool_var_5 || bool_var_6) != bool_var_7) {
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 1:
                            text_konjungsi_4.text = "&&";
                            while( (bool_var_5 && bool_var_6) != bool_var_7){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 2:
                            text_konjungsi_4.text = "!=";
                            while( (bool_var_5 != bool_var_6) != bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 3:
                            text_konjungsi_4.text = "==";
                            while( (bool_var_5 == bool_var_6) != bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        
                    }
                    bool_kunci = bool_var_7;
                    break;


                case 1:
                    text_konjungsi_5.text = "!=";

                    tanda_tanya_11.SetActive(true);

                    index_operator_logika = random.Next(0, array_operator_logika.Length);

                    switch(index_operator_logika){
                        case 0:
                            text_konjungsi_4.text = "||";
                            while( (bool_var_5 || bool_var_6) == bool_var_7) {
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 1:
                            text_konjungsi_4.text = "&&";
                            while( (bool_var_5 && bool_var_6) == bool_var_7){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 2:
                            text_konjungsi_4.text = "!=";
                            while( (bool_var_5 != bool_var_6) == bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        case 3:
                            text_konjungsi_4.text = "==";
                            while( (bool_var_5 == bool_var_6) == bool_var_7 ){
                                RandomBoolVar5();
                                RandomBoolVar6();
                            }
                            break;
                        
                    }
                    bool_kunci = bool_var_7;
                    break;

            }

        }

    }






// ====================================================================================================================================

    public void JawabanPernyataanSalahIf(){

        int index_part = Random.Range(0, 2);

        if(index_part == 0){

            RandomBoolVar4();
            RandomBoolVar2Y();

            index_operator_logika = random.Next(0, array_operator_logika.Length);

            if(index_operator_logika == 0){
                hasil_part_2 = bool_var_4 || bool_var_2_y;
                text_konjungsi_3.text = "||";
            } else if(index_operator_logika == 1){
                hasil_part_2 = bool_var_4 && bool_var_2_y;
                text_konjungsi_3.text = "&&";
            } else if(index_operator_logika == 2) {
                hasil_part_2 = bool_var_4 != bool_var_2_y;
                text_konjungsi_3.text = "!=";
            } else {
                hasil_part_2 = bool_var_4 == bool_var_2_y;
                text_konjungsi_3.text = "==";
            }


            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_2.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 1)
                        case 0:
                            tanda_tanya_3.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) == hasil_part_2) || (((true || bool_var_1_x) != hasil_part_2) == ((false || bool_var_1_x) != hasil_part_2)) ) {
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) == hasil_part_2) || (((true && bool_var_1_x) != hasil_part_2) == ((false && bool_var_1_x) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_3;
                            break;


                        // Tanda Tanya Pada Variabel x (Part 1)
                        case 1:
                            tanda_tanya_1.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) == hasil_part_2) || (((true || bool_var_3) != hasil_part_2) == ((false || bool_var_3) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) == hasil_part_2) || (((true && bool_var_3) != hasil_part_2) == ((false && bool_var_3) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_1_x;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                

                case 1 :

                    text_konjungsi_2.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 1)
                        case 0:
                            tanda_tanya_3.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) != hasil_part_2) || (((true || bool_var_1_x) == hasil_part_2) == ((false || bool_var_1_x) == hasil_part_2)) ) {
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) != hasil_part_2) || (((true && bool_var_1_x) == hasil_part_2) == ((false && bool_var_1_x) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_3;
                            break;


                        // Tanda Tanya Pada Variabel x (Part 1)
                        case 1:
                            tanda_tanya_1.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) != hasil_part_2) || (((true || bool_var_3) == hasil_part_2) == ((false || bool_var_3) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) != hasil_part_2) || (((true && bool_var_3) == hasil_part_2) == ((false && bool_var_3) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_1_x;
                            break;
                    } // end switch tanda tanya     
                
                    break;


                
                    
            } // end konjungsi antar part
        
        } else {

            RandomBoolVar3();
            RandomBoolVar1X();

            index_operator_logika = random.Next(0, array_operator_logika.Length);

            if(index_operator_logika == 0){
                hasil_part_1 = bool_var_3 || bool_var_1_x;
                text_konjungsi_1.text = "||";
            } else if(index_operator_logika == 1){
                hasil_part_1 = bool_var_3 && bool_var_1_x;
                text_konjungsi_1.text = "&&";
            } else if(index_operator_logika == 2) {
                hasil_part_1 = bool_var_3 != bool_var_1_x;
                text_konjungsi_1.text = "!=";
            } else {
                hasil_part_1 = bool_var_3 == bool_var_1_x;
                text_konjungsi_1.text = "==";
            }


            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_2.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 2)
                        case 0:
                            tanda_tanya_6.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) == hasil_part_1) || (((true || bool_var_2_y) != hasil_part_1) && ((false || bool_var_2_y) != hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) == hasil_part_1) || (((true && bool_var_2_y) != hasil_part_1) && ((false && bool_var_2_y) != hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_4;
                            break;


                        // Tanda Tanya Pada Variabel y (Part 1)
                        case 1:
                            tanda_tanya_2.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) == hasil_part_1) || (((true || bool_var_4) != hasil_part_1) && ((false || bool_var_4) != hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) == hasil_part_1) || (((true && bool_var_4) != hasil_part_1) && ((false && bool_var_4) != hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_2_y;
                            break;
                    } // end switch tanda tanya     
                
                    break;


                case 1:
                    text_konjungsi_2.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 2)
                        case 0:
                            tanda_tanya_6.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) != hasil_part_1) || (((true || bool_var_2_y) == hasil_part_1) && ((false || bool_var_2_y) == hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) != hasil_part_1) || (((true && bool_var_2_y) == hasil_part_1) && ((false && bool_var_2_y) == hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_4;
                            break;


                        // Tanda Tanya Pada Variabel y (Part 1)
                        case 1:
                            tanda_tanya_2.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) != hasil_part_1) || (((true || bool_var_4) == hasil_part_1) && ((false || bool_var_4) == hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) != hasil_part_1) || (((true && bool_var_4) == hasil_part_1) && ((false && bool_var_4) == hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_2_y;
                            break;
                    } // end switch tanda tanya     
                
                    break;


                    
            } // end konjungsi antar part

        } // end if

    }







// ====================================================================================================================================

    public void JawabanPernyataanBenarIf(){

        int index_part = Random.Range(0, 2);

        if(index_part == 0){

            RandomBoolVar4();
            RandomBoolVar2Y();

            index_operator_logika = random.Next(0, array_operator_logika.Length);

            if(index_operator_logika == 0){
                hasil_part_2 = bool_var_4 || bool_var_2_y;
                text_konjungsi_3.text = "||";
            } else if(index_operator_logika == 1){
                hasil_part_2 = bool_var_4 && bool_var_2_y;
                text_konjungsi_3.text = "&&";
            } else if(index_operator_logika == 2) {
                hasil_part_2 = bool_var_4 != bool_var_2_y;
                text_konjungsi_3.text = "!=";
            } else {
                hasil_part_2 = bool_var_4 == bool_var_2_y;
                text_konjungsi_3.text = "==";
            }


            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_2.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 1)
                        case 0:
                            tanda_tanya_3.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) != hasil_part_2) || (((true || bool_var_1_x) == hasil_part_2) == ((false || bool_var_1_x) == hasil_part_2)) ) {
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) != hasil_part_2) || (((true && bool_var_1_x) == hasil_part_2) == ((false && bool_var_1_x) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_3;
                            break;


                        // Tanda Tanya Pada Variabel x (Part 1)
                        case 1:
                            tanda_tanya_1.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) != hasil_part_2) || (((true || bool_var_3) == hasil_part_2) == ((false || bool_var_3) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) != hasil_part_2) || (((true && bool_var_3) == hasil_part_2) == ((false && bool_var_3) == hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) != hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_1_x;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                

                case 1 :

                    text_konjungsi_2.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 1)
                        case 0:
                            tanda_tanya_3.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) == hasil_part_2) || (((true || bool_var_1_x) != hasil_part_2) == ((false || bool_var_1_x) != hasil_part_2)) ) {
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) == hasil_part_2) || (((true && bool_var_1_x) != hasil_part_2) == ((false && bool_var_1_x) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                
                            }
                            bool_kunci = bool_var_3;
                            break;


                        // Tanda Tanya Pada Variabel x (Part 1)
                        case 1:
                            tanda_tanya_1.SetActive(true);

                            RandomBoolVar3();
                            RandomBoolVar1X();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_1.text = "||";
                                    while( ((bool_var_3 || bool_var_1_x) == hasil_part_2) || (((true || bool_var_3) != hasil_part_2) == ((false || bool_var_3) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_1.text = "&&";
                                    while( ((bool_var_3 && bool_var_1_x) == hasil_part_2) || (((true && bool_var_3) != hasil_part_2) == ((false && bool_var_3) != hasil_part_2)) ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_1.text = "!=";
                                    while( (bool_var_3 != bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_1.text = "==";
                                    while( (bool_var_3 == bool_var_1_x) == hasil_part_2 ){
                                        RandomBoolVar3();
                                        RandomBoolVar1X();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_1_x;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                   
            } // end konjungsi antar part
        
        } else {

            RandomBoolVar3();
            RandomBoolVar1X();

            index_operator_logika = random.Next(0, array_operator_logika.Length);

            if(index_operator_logika == 0){
                hasil_part_1 = bool_var_3 || bool_var_1_x;
                text_konjungsi_1.text = "||";
            } else if(index_operator_logika == 1){
                hasil_part_1 = bool_var_3 && bool_var_1_x;
                text_konjungsi_1.text = "&&";
            } else if(index_operator_logika == 2) {
                hasil_part_1 = bool_var_3 != bool_var_1_x;
                text_konjungsi_1.text = "!=";
            } else {
                hasil_part_1 = bool_var_3 == bool_var_1_x;
                text_konjungsi_1.text = "==";
            }


            index_operator_konjungsi = Random.Range(0, 2);

            switch(index_operator_konjungsi){

                case 0:

                    text_konjungsi_2.text = "==";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 2)
                        case 0:
                            tanda_tanya_6.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) != hasil_part_1) || (((true || bool_var_2_y) == hasil_part_1) && ((false || bool_var_2_y) == hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) != hasil_part_1) || (((true && bool_var_2_y) == hasil_part_1) && ((false && bool_var_2_y) == hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_4;
                            break;


                        // Tanda Tanya Pada Variabel y (Part 1)
                        case 1:
                            tanda_tanya_2.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) != hasil_part_1) || (((true || bool_var_4) == hasil_part_1) && ((false || bool_var_4) == hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) != hasil_part_1) || (((true && bool_var_4) == hasil_part_1) && ((false && bool_var_4) == hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) != hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_2_y;
                            break;
                    } // end switch tanda tanya     
                
                    break;


                case 1:
                    text_konjungsi_2.text = "!=";

                    index_tanda_tanya = Random.Range(0, 2);

                    switch(index_tanda_tanya){

                        // Tanda Tanya Pada False (Part 2)
                        case 0:
                            tanda_tanya_6.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) == hasil_part_1) || (((true || bool_var_2_y) != hasil_part_1) && ((false || bool_var_2_y) != hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) == hasil_part_1) || (((true && bool_var_2_y) != hasil_part_1) && ((false && bool_var_2_y) != hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_4;
                            break;


                        // Tanda Tanya Pada Variabel y (Part 1)
                        case 1:
                            tanda_tanya_2.SetActive(true);

                            RandomBoolVar4();
                            RandomBoolVar2Y();

                            index_operator_logika = random.Next(0, array_operator_logika.Length);

                            switch(index_operator_logika){
                                case 0:
                                    text_konjungsi_3.text = "||";
                                    while( ((bool_var_4 || bool_var_2_y) == hasil_part_1) || (((true || bool_var_4) != hasil_part_1) && ((false || bool_var_4) != hasil_part_1)) ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y(); 
                                    }
                                    break;
                                case 1:
                                    text_konjungsi_3.text = "&&";
                                    while( ((bool_var_4 && bool_var_2_y) == hasil_part_1) || (((true && bool_var_4) != hasil_part_1) && ((false && bool_var_4) != hasil_part_1))){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 2:
                                    text_konjungsi_3.text = "!=";
                                    while( (bool_var_4 != bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                                case 3:
                                    text_konjungsi_3.text = "==";
                                    while( (bool_var_4 == bool_var_2_y) == hasil_part_1 ){
                                        RandomBoolVar4();
                                        RandomBoolVar2Y();
                                    }
                                    break;
                            }
                            bool_kunci = bool_var_2_y;
                            break;
                    } // end switch tanda tanya     
                
                    break;
                 
            } // end konjungsi antar part

        } // end if

    }



    public void RandomKata(){

        string[] array_minuman = {"Es Teh", "Jus Mangga", "Es Jeruk", "Es Cendol"};

        string[] array_makanan = {"Sate", "Bakso", "Soto", "Ayam Bakar", "Nasi Goreng", "Mie Goreng"};

        string[] array_buah = {"Mangga", "Semangka", "Jeruk", "Apel", "Anggur"};

        string[] array_kue = {"Bakpao", "Brownis", "Roti Bakar", "Martabak Manis"};

        int indeks_kata, temp_1, temp_2;

        switch(Random.Range(0, 4)){

            case 0:

                indeks_kata = random.Next(0, array_minuman.Length);
                kata_print_kunci = array_minuman[indeks_kata];

                temp_1 = indeks_kata;

                indeks_kata = random.Next(0, array_minuman.Length);
                while(indeks_kata == temp_1){
                    indeks_kata = random.Next(0, array_minuman.Length);
                }

                kata_print_salah_1 = array_minuman[indeks_kata];

                temp_2 = indeks_kata;

                indeks_kata = random.Next(0, array_minuman.Length);
                while(indeks_kata == temp_1 || indeks_kata == temp_2){
                    indeks_kata = random.Next(0, array_minuman.Length);
                }

                kata_print_salah_2 = array_minuman[indeks_kata];

                break;

            
            case 1:
                indeks_kata = random.Next(0, array_makanan.Length);
                kata_print_kunci = array_makanan[indeks_kata];

                temp_1 = indeks_kata;

                indeks_kata = random.Next(0, array_minuman.Length);
                while(indeks_kata == temp_1){
                    indeks_kata = random.Next(0, array_minuman.Length);
                }

                kata_print_salah_1 = array_minuman[indeks_kata];

                temp_2 = indeks_kata;

                indeks_kata = random.Next(0, array_minuman.Length);
                while(indeks_kata == temp_1 || indeks_kata == temp_2){
                    indeks_kata = random.Next(0, array_minuman.Length);
                }

                kata_print_salah_2 = array_minuman[indeks_kata];

                break;

            case 2:
                indeks_kata = random.Next(0, array_buah.Length);
                kata_print_kunci = array_buah[indeks_kata];
                temp_1 = indeks_kata;

                indeks_kata = random.Next(0, array_buah.Length);
                while(indeks_kata == temp_1){
                    indeks_kata = random.Next(0, array_buah.Length);
                }

                kata_print_salah_1 = array_buah[indeks_kata];

                temp_2 = indeks_kata;

                indeks_kata = random.Next(0, array_buah.Length);
                while(indeks_kata == temp_1 || indeks_kata == temp_2){
                    indeks_kata = random.Next(0, array_buah.Length);
                }

                kata_print_salah_2 = array_buah[indeks_kata];

                break;

            case 3:
                indeks_kata = random.Next(0, array_kue.Length);
                kata_print_kunci = array_kue[indeks_kata];
                temp_1 = indeks_kata;

                indeks_kata = random.Next(0, array_kue.Length);
                while(indeks_kata == temp_1){
                    indeks_kata = random.Next(0, array_kue.Length);
                }

                kata_print_salah_1 = array_kue[indeks_kata];

                temp_2 = indeks_kata;

                indeks_kata = random.Next(0, array_kue.Length);
                while(indeks_kata == temp_1 || indeks_kata == temp_2){
                    indeks_kata = random.Next(0, array_kue.Length);
                }

                kata_print_salah_2 = array_kue[indeks_kata];

                break;
        }

    }





    public void RandomBoolVar1X(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_1_x = false;
        } else {
            bool_var_1_x = true;
        }
    }


    public void RandomBoolVar2Y(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_2_y = false;
        } else {
            bool_var_2_y = true;
        }
    }


    public void RandomBoolVar3(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_3 = false;
        } else {
            bool_var_3 = true;
        }
    }


    public void RandomBoolVar4(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_4 = false;
        } else {
            bool_var_4 = true;
        }
    }

    public void RandomBoolVar5(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_5 = false;
        } else {
            bool_var_5 = true;
        }
    }


    public void RandomBoolVar6(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_6 = false;
        } else {
            bool_var_6 = true;
        }
    }


    public void RandomBoolVar7(){
        int random_var = Random.Range(0, 2);
        if(random_var == 0){
            bool_var_7 = false;
        } else {
            bool_var_7 = true;
        }
    }
    

    public void Jawaban_True(){

        if(bool_kunci_jawaban == true){
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

        SoalBoolean();

    }




    public void Jawaban_False(){

        if(bool_kunci_jawaban == false){
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

        SoalBoolean();
    }





}
