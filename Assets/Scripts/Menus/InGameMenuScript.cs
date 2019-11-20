using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenuScript : MonoBehaviour {

    public GameObject BestScore;
    public GameObject Left;
    public GameObject Right;
    public GameObject Fire;
    public GameObject AmmoAmnt;
    public GameObject YouScore;
    public GameObject YADead;
    public GameObject Score;
    public GameObject PauseText;
    public GameObject Pause;
    public GameObject Resume;
    public GameObject SoundOffOn;
    public GameObject ExitToMM;
    public GameObject Camera;
    public GameObject Exit;
    public GameObject TryAgain;
    public GameObject Ship;
    public GameObject Explosion;
    public GameObject CoinsAmount;
    public GameObject NewRecord;

    //Звуковые объекты
    public GameObject PauseSound;
    public GameObject ResumeSound;

    //Переменные
    bool A, B, nrb = true;
    public static bool GlobalPause;
    public static float time;
    public static int sound = 1, CAmnt = 0;
    int r = 0;
    float nr = 0;

    void Start ()
    {
       
        CAmnt = PlayerPrefs.GetInt("Coins");        

        Button Paus = Pause.GetComponent<Button>();
        Paus.onClick.AddListener(Pau);
        Button Resum = Resume.GetComponent<Button>();
        Resum.onClick.AddListener(Resu);
        Button SoundOffO  = SoundOffOn.GetComponent<Button>();
        SoundOffO.onClick.AddListener(SoundOff);
        Button ExitToM = ExitToMM.GetComponent<Button>();       
        ExitToM.onClick.AddListener(ExitTo);
        Button Exi = Exit.GetComponent<Button>();
        Exi.onClick.AddListener(Ex);
        Button TryAgai = TryAgain.GetComponent<Button>();
        TryAgai.onClick.AddListener(TryAga);

        sound = PlayerPrefs.GetInt("Sound");
        if (sound == 1)
        {
            Camera.GetComponent<AudioListener>().enabled = true;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound on";

        }
        else
        {
            Camera.GetComponent<AudioListener>().enabled = false;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound off";
        }
    }
    
    //Функции кнопок
    void Pau()
    {
        CoinsAmount.GetComponentInChildren<Text>().text = "X" + CAmnt;       
        AudioSource SShip = Ship.GetComponent<AudioSource>();
        SShip.Stop();
        AudioSource Audio = PauseSound.GetComponent<AudioSource>();
        Audio.Play();
        Time.timeScale = 0.0F;
        GlobalPause = true;
        A = false;
        B = true;
        ActDeac();
    }
    void Resu()
    {        
        AudioSource Audio = ResumeSound.GetComponent<AudioSource>();
        Audio.Play();
        AudioSource SShip = Ship.GetComponent<AudioSource>();
        SShip.Play();
        Time.timeScale = 1.0F;
        GlobalPause = false;
        A = true;
        B = false;
        ActDeac();
        
    }
    void SoundOff()
    {
        if (Camera.GetComponent<AudioListener>().enabled)
        {
            Camera.GetComponent<AudioListener>().enabled = false;
            PlayerPrefs.SetInt("Sound", 0);
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound off";
        }
        else
        {
            AudioSource Audio = SoundOffOn.GetComponent<AudioSource>();
            Audio.Play();
            Camera.GetComponent<AudioListener>().enabled = true;
            PlayerPrefs.SetInt("Sound", 1);
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound on";
        }
    }
    void ExitTo()
    {
        BTMMenu();
        SceneManager.LoadScene("Main_Menu");
    }

    void Ex()
    {
        BTMMenu();
        SceneManager.LoadScene("Main_Menu");
    }

    void TryAga()
    {
        BTMMenu();
        time = 0;
        SceneManager.LoadScene("Level 1");
    }

    //Функции
    void ActDeac()
    {
        if (MenuScript.control == 1)
        {
            Right.SetActive(A);
            Left.SetActive(A);
        }
        Pause.SetActive(A);
        Fire.SetActive(A);
        PauseText.SetActive(B);
        Resume.SetActive(B);
        SoundOffOn.SetActive(B);
        ExitToMM.SetActive(B);
        CoinsAmount.SetActive(B);
    }
    void BTMMenu()
    {
        PlayerPrefs.SetInt("Coins" , CAmnt);
        Time.timeScale = 1.0F;
        GlobalPause = false;
        PlayerScript.death = false;        
    }

    private void Update()
    {
        if (time > MenuScript.time && nrb)
        {
            nr += Time.timeScale;
            if (nr < 40)
            {
                NewRecord.SetActive(true);                
            }
            else
            {
                NewRecord.SetActive(false);
                nrb = false;
            }
        }
        time += Time.deltaTime * 10;
        time = float.Parse(time.ToString("f2"));
        Score.GetComponent<Text>().text = "Score:\n" + time;
        AmmoAmnt.GetComponent<Text>().text = "X" + MenuScript.Ammo;
        if (PlayerScript.death == true)
        {            
            if (r == 0)
            {
                AudioSource SExplosion = Explosion.GetComponent<AudioSource>();
                SExplosion.Play();
                r = 1;
            }
            AudioSource SShip = Ship.GetComponent<AudioSource>();
            SShip.Stop();            
            CreateRemoveScript.time = 1;
            YouScore.GetComponent<Text>().text = "Your Score    " + time;
            BestScore.GetComponent<Text>().text = "Best Score:    " + MenuScript.time;
            if (time > MenuScript.time)
            {
                MenuScript.time = time;
                PlayerPrefs.SetFloat("FirstSave", time);
            }
            Time.timeScale = 0;            
            CoinsAmount.GetComponentInChildren<Text>().text = "X" + CAmnt;
            CoinsAmount.SetActive(true);
            GlobalPause = true;
            AmmoAmnt.SetActive(false);
            Pause.SetActive(false);
            Score.SetActive(false);
            BestScore.SetActive(true);
            YADead.SetActive(true);
            Exit.SetActive(true);
            TryAgain.SetActive(true);
            YouScore.SetActive(true);
            Left.SetActive(false);
            Right.SetActive(false);
            Fire.SetActive(false);
        }
    }

}

