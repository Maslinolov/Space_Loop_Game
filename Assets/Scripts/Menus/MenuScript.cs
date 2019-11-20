using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    //Части меню
    public GameObject MainMenuPart;
    public GameObject ShopPart;
    public GameObject SettingsPart;
    //Главное меню
    public GameObject GameName;
    public GameObject BestScore;
    public GameObject Settings;
    public GameObject Exit;
    public GameObject Level1;
    public GameObject CoinsAmount;
    public GameObject ShopButton;
    public GameObject GetMoneyButton;
    //Настройки
    public GameObject SettingsText;
    public GameObject Control;
    public GameObject SoundOffOn;
    public GameObject BackFromSettings;
    //Камера    
    public GameObject Camera;
    //Магазин
    public GameObject ShopName;
    public GameObject BackFromShop;
    public GameObject SecondLife;
    public GameObject NotEnoughtGold;
    public GameObject CoinsAmountSp;
    public GameObject LaserBuy;
    public GameObject BigCollarBuy;
    public GameObject AmmoBuy;

    //Объекты звуков
    public GameObject BackFromSettingsSound;
    public GameObject SettingsSound;
    public GameObject ShopSound;
    public GameObject BackShopSound;

    //Переменные
    bool A, B;
    public static int control = 0, sound = 1, ScndLf = 0, Laser = 0, BigCollar = 0, Ammo = 0;
    public static float time;
    public int CAmnt;
    float NEGt;




    void Start ()
    {
        //Главное меню кнопки           
        Button Sett = Settings.GetComponent<Button>();
        Sett.onClick.AddListener(Set);
        Button Exi = Exit.GetComponent<Button>();        
        Exi.onClick.AddListener(Ex);
        Button Shop = ShopButton.GetComponent<Button>();
        Shop.onClick.AddListener(Shp);
        Button GetMoneyBut = GetMoneyButton.GetComponent<Button>();
        GetMoneyBut.onClick.AddListener(GetMoneyB);
        

        //Выбор уровня кнопки
        Button Leve1 = Level1.GetComponent<Button>();
        Leve1.onClick.AddListener(Lev1);       

        //Настройки игры кнопки
        Button Contro = Control.GetComponent<Button>();
        Contro.onClick.AddListener(Contr);
        Button SoundOffO = SoundOffOn.GetComponent<Button>();
        SoundOffO.onClick.AddListener(SoundOff);
        Button BackFromSetting = BackFromSettings.GetComponent<Button>();
        BackFromSetting.onClick.AddListener(BackFromSettin);

        //Магазин кнопки
        Button BackFromSho = BackFromShop.GetComponent<Button>();
        BackFromSho.onClick.AddListener(BackFromSp);
        Button SecondLif = SecondLife.GetComponent<Button>();
        SecondLif.onClick.AddListener(SecondLf);        
        Button LaserBu = LaserBuy.GetComponent<Button>();
        LaserBu.onClick.AddListener(LaserB);
        Button BigCollarBu = BigCollarBuy.GetComponent<Button>();
        BigCollarBu.onClick.AddListener(BigCollarB);
        Button AmmoBu = AmmoBuy.GetComponent<Button>();
        AmmoBu.onClick.AddListener(AmmoB);

        //Загрузка переменных
        time = PlayerPrefs.GetFloat("FirstSave");
        control = PlayerPrefs.GetInt("Control");
        sound = PlayerPrefs.GetInt("Sound");
        CAmnt = PlayerPrefs.GetInt("Coins");
        ScndLf = PlayerPrefs.GetInt("SecondLife");
        Laser = PlayerPrefs.GetInt("Laser");
        BigCollar = PlayerPrefs.GetInt("BigCollar");
        Ammo = PlayerPrefs.GetInt("Ammo");

        CoinsAmount.GetComponentInChildren<Text>().text = "X" + CAmnt;
        CoinsAmountSp.GetComponentInChildren<Text>().text = "X" + CAmnt;
        BestScore.GetComponent<Text>().text = "Best Score: \n" + time;

        //Проверка управления
        if (control == 0)
        {
            Control.GetComponentInChildren<Text>().text = "Accelerometer";
        }
        else
        {
            Control.GetComponentInChildren<Text>().text = "Buttons";
        }

        //Проверка звука
        if (sound == 1)
        {
            Camera.GetComponent<AudioListener>().enabled = true;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound On";
        }
        else
        {
            Camera.GetComponent<AudioListener>().enabled = false;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound Off";
        }

        //Изменения текстов в магазине
        if (ScndLf == 1)
        {
            SecondLife.GetComponentInChildren<Text>().text = " Second Life (50 Coins) \n1 use only - (X1)";
        }
        if (Laser == 1)
        {
            LaserBuy.GetComponentInChildren<Text>().text = " Laser Gun (200 Coins) \n(X1)";
        }
        if (BigCollar == 1)
        {
            BigCollarBuy.GetComponentInChildren<Text>().text = " Big Collar (200 Coins) \n4 Ammo Max  - (X1)";            
        }
        if (Ammo > 0)
        {
            AmmoBuy.GetComponentInChildren<Text>().text = " Ammo (30 Coins) \n+ 1 Ammo - (X" + Ammo + ")";            
        }
    }

    private void Update()
    {
        if (NotEnoughtGold.activeSelf)
        {
            NEGt += Time.timeScale;
            if (NEGt >= 40)
            {
                NotEnoughtGold.SetActive(false);
                NEGt = 0;
            }
        }
    }

    //Главное меню    
    void Set()
    {
        AudioSource Audio = SettingsSound.GetComponent<AudioSource>();
        Audio.Play();
        A = false;
        B = true;
        ActDeacSettings();
    }
    void Ex()
    {
        AudioSource Audio = Exit.GetComponent<AudioSource>();
        Audio.Play();
        Application.Quit();
    }   
    void Lev1()
    {        
        InGameMenuScript.time = 0;
        SceneManager.LoadScene("Level 1");    
    }
    void Shp()
    {
        AudioSource Audio = ShopSound.GetComponent<AudioSource>();
        Audio.Play();
        A = false;
        B = true;
        ActDeacShop();
    }
    void GetMoneyB()
    {
        PlayerPrefs.SetInt("Coins", 9999);
    }


    //Настройки игры
    void Contr()
    {
        AudioSource Audio = Control.GetComponent<AudioSource>();
        Audio.Play();
        if (control == 0)
        {
            control = 1;
            Control.GetComponentInChildren<Text>().text = "Buttons";
        }
        else
        {
            control = 0;
            Control.GetComponentInChildren<Text>().text = "Accelerometer";
        }
    }
    void SoundOff()
    {
        if (Camera.GetComponent<AudioListener>().enabled)
        {
            Camera.GetComponent<AudioListener>().enabled = false;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound off";
            PlayerPrefs.SetInt("Sound", 0);            
        }
        else
        {
            Camera.GetComponent<AudioListener>().enabled = true;
            SoundOffOn.GetComponentInChildren<Text>().text = "Sound on";
            PlayerPrefs.SetInt("Sound", 1);
            AudioSource Audio = SoundOffOn.GetComponent<AudioSource>();
            Audio.Play();
        }
    }
    void BackFromSettin()
    {
        AudioSource Audio = BackFromSettingsSound.GetComponent<AudioSource>();
        Audio.Play();
        A = true;
        B = false;
        ActDeacSettings();
        PlayerPrefs.SetInt("Control", control);
    }

    //Магазин
    void BackFromSp()
    {
        AudioSource Audio = BackShopSound.GetComponent<AudioSource>();
        Audio.Play();
        A = true;
        B = false;
        ActDeacShop();
    }
    void SecondLf()
    {
        if (ScndLf == 0)
        {
            if (CAmnt >= 50)
            {
                AudioSource Audio = SecondLife.GetComponent<AudioSource>();
                Audio.Play();
                CAmnt -= 50;
                CoinsChange();
                SecondLife.GetComponentInChildren<Text>().text = " Second Life (50 Coins) \n1 use only - (X1)";
                PlayerPrefs.SetInt("SecondLife", 1);
                ScndLf = 1;
            }
            else
            {
                NotEnoughtGold.SetActive(true);
            }
        }
    }
    void LaserB()
    {
        if (Laser == 0)
        {
            if (CAmnt >= 200)
            {
                AudioSource Audio = SecondLife.GetComponent<AudioSource>();
                Audio.Play();
                CAmnt -= 200;
                CoinsChange();
                LaserBuy.GetComponentInChildren<Text>().text = " Laser Gun (200 Coins) \n(X1)";
                PlayerPrefs.SetInt("Laser", 1);
                Laser = 1;                
            }
            else
            {
                NotEnoughtGold.SetActive(true);
            }
        }
    }
    void BigCollarB()
    {
        if (BigCollar == 0)
        {
            if (CAmnt >= 200)
            {
                AudioSource Audio = SecondLife.GetComponent<AudioSource>();
                Audio.Play();
                CAmnt -= 200;
                CoinsChange();
                BigCollarBuy.GetComponentInChildren<Text>().text = " Big Collar (200 Coins) \n4 Ammo Max - (X1)";
                PlayerPrefs.SetInt("BigCollar", 1);
                BigCollar = 1;
            }
            else
            {
                NotEnoughtGold.SetActive(true);
            }
        }
    }
    void AmmoB()
    {
        if (Ammo < 2 && BigCollar == 0 || Ammo < 4 && BigCollar == 1)
        {
            if (CAmnt >= 30)
            {
                AudioSource Audio = SecondLife.GetComponent<AudioSource>();
                Audio.Play();
                CAmnt -= 30;
                CoinsChange();
                Ammo++;
                AmmoBuy.GetComponentInChildren<Text>().text = " Ammo (30 Coins) \n + 1 Ammo - (X" + Ammo + ")";                
                PlayerPrefs.SetInt("Ammo", Ammo);
            }
            else
            {
                NotEnoughtGold.SetActive(true);
            }
        }
    }



    //Функции  
    void ActDeacSettings()
    {
        MainMenuPart.SetActive(A);
        SettingsPart.SetActive(B);      
    }
    void ActDeacShop()
    {
        MainMenuPart.SetActive(A);
        ShopPart.SetActive(B);
    }
    void CoinsChange()
    {
        CoinsAmount.GetComponentInChildren<Text>().text = "X" + CAmnt;
        CoinsAmountSp.GetComponentInChildren<Text>().text = "X" + CAmnt;
        PlayerPrefs.SetInt("Coins", CAmnt);
    }
}
