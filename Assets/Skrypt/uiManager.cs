
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    [Header("Guziki")]
    public Button lewo, prawo, pause_btn, btn_backToMenu, btn_Exit, btn_Restart;
    [Header("Napisy")]
    public Text ileKm, hitOnGame,scoreBoard,MaxHit;
    [Header("Obrazki")]
    public Image pauseMenu,loadingAnimation,deadScene,loadnigOnDead,winScene,loadAnimationOnWin,pauseText,winSceneFreak,rezerwa;


    public AudioSource muzykaWGrze;
    public Text gameMode;
    public GameObject wybuch;
    bool dead,win,mute;
    public int nrSceny;
    public float szybkoscSwiatla = 1f;
    startGame SG;
    private static AndroidJavaObject currentActivity
    
    {

        get
        {
            return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        }

    }
   

    void Start ()
    {
        int muteint = PlayerPrefs.GetInt("Mute");
        if(muteint==0)
        {
            muzykaWGrze.mute = true;
        }
        if(muteint==1)
        {
            muzykaWGrze.mute = false;
        }
        if (gameMode.text != "Freak Mode")
        {
            loadnigOnDead.enabled = false;
            scoreBoard.enabled = false;
            deadScene.enabled = false;
        }
        if (gameMode.text == "Career Mode")
        {
            winScene.enabled = false;
            rezerwa.enabled = true;
        }
        if(gameMode.text=="Freak Mode")
        {
            MaxHit.enabled = false;
            winSceneFreak.enabled = false;
        }
        loadingAnimation.enabled = false;
        carController.FindObjectOfType<carController>().ileMinelo = 0;
        ileKm.text = "0 KM";
        pauseText.enabled = false;
        lewo.image.enabled = true;
        lewo.enabled = true;
        prawo.image.enabled = true;
        prawo.enabled = true;
        pauseMenu.enabled = false;
        btn_backToMenu.image.enabled = false;
        btn_Exit.image.enabled = false;
        btn_Restart.image.enabled = false;
        muzykaWGrze.volume = 1f;
        Time.timeScale = 1;
        dead = false;
        win = false;
        if (gameMode.text == "Freak Mode")
        {
            nrSceny = 1;
        }
        else if(gameMode.text == "Career Mode")
        {
            nrSceny = 2;
        }
        else if(gameMode.text == "Unlimited")
        {
            nrSceny = 3;
        }
        
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && dead == false && win==false)
        {
            Pause();
        }
        if(FindObjectOfType<carSpawner>().ileMetrow >= 200f && dead==false && gameMode.text =="Career Mode") 
        {
            PlayerPrefs.SetInt("Czy Wygra", 1);
            Win();
        }
        if (FindObjectOfType<carSpawner>().ileMetrow >= 200f && dead == false && gameMode.text == "Freak Mode")
        {
            WinFreak();
        }
    }

   

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            SetPause();
        }
        else if(Time.timeScale == 0)
        {
            UnPause();
        }
    }
    public void Dead()
    {
        Invoke("ImaDead", 0.5f);
    }
    void ImaDead()
    {
        dead = true;
        carController.FindObjectOfType<carController>().DestroyCar();
        btn_backToMenu.image.enabled = true;
        btn_Exit.image.enabled = true;
        btn_Restart.image.enabled = true;
        if (nrSceny == 3)
        {
            scoreBoard.text = "Score : " + ileKm.text;
        }
        if(nrSceny == 2)
        {
            scoreBoard.text = ileKm.text + " LEFT";
            rezerwa.enabled = false;
        }
        
        ileKm.enabled = false;
        gameMode.enabled = false;
        scoreBoard.enabled = true;
        deadScene.enabled = true;
        pause_btn.enabled = false;
        pause_btn.image.enabled = false;
        lewo.image.enabled = false;
        lewo.enabled = false;
        prawo.image.enabled = false;
        prawo.enabled = false;
        muzykaWGrze.volume = 0.3f;
        UsunpozostaleWybuchy();
    }
    public void Win()
    {
        win = true;
        carController.FindObjectOfType<carController>().DestroyCar();
        rezerwa.enabled = false;
        winScene.enabled = true;
        btn_backToMenu.image.enabled = true;
        btn_Exit.image.enabled = true;
        btn_Restart.image.enabled = true;
        ileKm.enabled = false;
        gameMode.enabled = false;
        pause_btn.enabled = false;
        pause_btn.image.enabled = false;
        lewo.image.enabled = false;
        lewo.enabled = false;
        prawo.image.enabled = false;
        prawo.enabled = false;
        muzykaWGrze.volume = 0.7f;
        UsunpozostaleWybuchy();
    }
    void WinFreak()
    {
        win = true;
        carController.FindObjectOfType<carController>().DestroyCar();
        winSceneFreak.enabled = true;
        MaxHit.enabled = true;
        MaxHit.text = FindObjectOfType<carController>().ileZderzen.ToString();
        btn_backToMenu.image.enabled = true;
        btn_Exit.image.enabled = true;
        btn_Restart.image.enabled = true;
        ileKm.enabled = false;
        gameMode.enabled = false;
        pause_btn.enabled = false;
        pause_btn.image.enabled = false;
        lewo.image.enabled = false;
        lewo.enabled = false;
        prawo.image.enabled = false;
        prawo.enabled = false;
        muzykaWGrze.volume = 0.7f;
        UsunpozostaleWybuchy();
    }
    public void SetPause()
    {
        pauseText.enabled = true;
        lewo.image.enabled = false;
        lewo.enabled = false;
        prawo.image.enabled = false;
        prawo.enabled = false;
        btn_backToMenu.image.enabled = true;
        btn_Exit.image.enabled = true;
        btn_Restart.image.enabled = true;
        muzykaWGrze.volume = 0.3f;
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        pauseText.enabled = false;
        lewo.image.enabled = true;
        lewo.enabled = true;
        prawo.image.enabled = true;
        prawo.enabled = true;
        pauseMenu.enabled = false;
        btn_backToMenu.image.enabled = false;
        btn_Exit.image.enabled = false;
        btn_Restart.image.enabled = false;
        muzykaWGrze.volume = 1f;
        Time.timeScale = 1;
    }
   
    public void KlikWMenu()
    {
        carController.FindObjectOfType<carController>().DestroyCar();
        btn_Exit.image.enabled = false;
        btn_Exit.enabled = false;
        btn_Restart.enabled = false;
        btn_Restart.image.enabled = false;
        pause_btn.enabled = false;
        pause_btn.image.enabled = false;
        loadingAnimation.enabled = true;
        hitOnGame.enabled = false;
        ileKm.enabled = false;
        gameMode.enabled = false;
        lewo.image.enabled = false;
        lewo.enabled = false;
        prawo.image.enabled = false;
        prawo.enabled = false;
        btn_backToMenu.image.enabled = true;
        muzykaWGrze.volume = 0f;

    }

    public void ExitApp()
    {
        if (nrSceny == 1)
        {
            FindObjectOfType<saveGame>().zapisz(1);
        }
        Application.Quit();
    }
    public void ExitToMenu()
    {
        SceneManager.LoadSceneAsync(0);
        if(nrSceny == 1)
        {
            FindObjectOfType<saveGame>().zapisz(1);
        }
        
            Time.timeScale = 1;
            btn_Exit.image.enabled = false;
            btn_Exit.enabled = false;
            btn_Restart.enabled = false;
            btn_Restart.image.enabled = false;
            pause_btn.enabled = false;
            pause_btn.image.enabled = false;
            KlikWMenu();
            UsunpozostaleWybuchy();
            if (dead == true)
            {
                loadnigOnDead.enabled = true;
            }
       
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(nrSceny);
        if (nrSceny == 1)
        {
            FindObjectOfType<saveGame>().zapisz(1);
        }
        if (dead==false)
        {
            UsunpozostaleWybuchy();
        }
        if(dead ==true)
        {
            loadnigOnDead.enabled=true;
        }
    }
    void UsunpozostaleWybuchy()
    {
        FindObjectOfType<carController>().UsunPozostale();

    }
}
