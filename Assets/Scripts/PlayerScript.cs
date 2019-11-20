using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public GameObject Player;
    public GameObject Left;
    public GameObject Right;
    public GameObject FireButton;
    public GameObject CoinSound;
    public GameObject Explosion;
    public GameObject LaserBlast;
    public GameObject LaserExplosion;

    //Переменные
    Vector3 control;
    Vector3 cl;
    Vector3 LsrPosition;
    public static bool death, LsrExplsn;
    int contr;
    float rotate = 0, t = 0;


    // Use this for initialization
    void Start ()
    {
        LsrPosition.x = -0.003f;
        LsrPosition.y = 0.13f;
        Button FireButto = FireButton.GetComponent<Button>();
        FireButto.onClick.AddListener(FireButt);
        MenuScript.ScndLf = PlayerPrefs.GetInt("SecondLife");
        MenuScript.Ammo = PlayerPrefs.GetInt("Ammo");
        MenuScript.Laser = PlayerPrefs.GetInt("Laser");
        control.x = 0;
        control.z = 0;
        cl.x = 1;
        cl.z = 0;    
        Player.transform.localScale -= ScreenResolutionScript.PScale;
        if (MenuScript.control == 1)
        {
            Left.SetActive(true);
            Right.SetActive(true);
        }    
    }

    // Update is called once per frame
    void Update ()
    {        
        if (InGameMenuScript.GlobalPause == false)
        {
            if(rotate > 0)
            {
                rotate -= 0.5F;
                Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
            }
            if (rotate < 0)
            {
                rotate += 0.5F;
                Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
            } 
            control.x = Input.acceleration.x;
            cl.x *= Time.timeScale;
            float A = Player.transform.position.x;            
            //Управление акселерометром
            if (MenuScript.control == 0)
            {
                if (A <= ScreenResolutionScript.RightBorder)
                {
                    if (Input.GetKey(KeyCode.D) || control.x > 0.1F)
                    {                        
                        Player.transform.Translate(cl * 3F, Space.World);
                        if (rotate <= 25)
                        {
                            rotate += 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
                        }                       
                    }                    
                }
                else
                {
                    if (Input.GetKey(KeyCode.A) || control.x < -0.1F)
                    {
                        Player.transform.Translate(cl * -3F, Space.World);
                        if (rotate >= -25)
                        {
                            rotate -= 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
                        }
                    }                    
                }
                if (A >= ScreenResolutionScript.LeftBorder)
                {
                    if (Input.GetKey(KeyCode.A) || control.x < -0.1F)
                    {
                        Player.transform.Translate(cl * -3F, Space.World);
                        if (rotate >= -25)
                        {
                            rotate -= 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
                        }
                    }                    
                }
                else
                {
                    if (Input.GetKey(KeyCode.D) || control.x > 0.1F)
                    {
                        Player.transform.Translate(cl * 3F, Space.World);
                        if (rotate <= 25)
                        {
                            rotate += 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate/3);
                        }
                    }                    
                }
            }
            //Управление кнопками   
            if (MenuScript.control == 1)
            {
                if (A <= ScreenResolutionScript.RightBorder)
                {
                    if (contr == 1)
                    {
                        Player.transform.Translate(cl * 3F, Space.World);
                        if (rotate <= 25)
                        {
                            rotate += 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate / 3);
                        }
                    }
                }
                
                if (A >= ScreenResolutionScript.LeftBorder)
                {
                    if (contr == -1)
                    {
                        Player.transform.Translate(cl * -3F, Space.World);
                        if (rotate >= -25)
                        {
                            rotate -= 2;
                            Player.transform.rotation = Quaternion.Euler(0, rotate, -rotate / 3);
                        }
                    }
                }               
                                
            }
            //Звук взрыва метеориты / монеты
            if (LsrExplsn)
            {
                AudioSource LaserExplosio = LaserExplosion.GetComponent<AudioSource>();
                LaserExplosio.Play();
                LsrExplsn = false;
            }
        }
	}

    //Управление кнопками voidы
    public void Move(int InputAxis)
    {
        contr = InputAxis;
    }
    void FireButt()
    {
        if (MenuScript.Laser == 1 && MenuScript.Ammo > 0)
        {
            AudioSource Audio = FireButton.GetComponent<AudioSource>();
            Audio.Play();
            LsrPosition = Player.transform.position;
            LsrPosition.y += 20;
            Instantiate(LaserBlast, LsrPosition, Quaternion.Euler(0, 0, 0));
            MenuScript.Ammo--;
            PlayerPrefs.SetInt("Ammo", MenuScript.Ammo);
        }
    }


    //Метеориты и монеты
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Meter"))
        {
            if (MenuScript.ScndLf == 0)
            {
                death = true;
            }
            else
            {
                t += Time.timeScale;
                AudioSource SExplosion = Explosion.GetComponent<AudioSource>();
                SExplosion.Play();
                Destroy(other.gameObject);
                t = 0;
                MenuScript.ScndLf = 0;
                PlayerPrefs.SetInt("SecondLife", 0);
            }
        }
        
        if (other.CompareTag("Coin"))
        {                        
            t += Time.timeScale;
            if(t == 5)
            {
                AudioSource Coin =  CoinSound.GetComponent<AudioSource>();
                Coin.Play();
                InGameMenuScript.CAmnt++;
                Destroy(other.gameObject);
                t = 0;
            }
            
        }
    }
    //Функции
    
}
