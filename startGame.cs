using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public int wyborSceny, wygrana;
    int ustawieniaMuzyki;
    public AudioSource music;
    [Header("Main")]
    public Image mainImg;
    [Header("Play")]
    public Button play_btn, btn_score, exit_btn, btn_setting;
    [Header("chooseLevel")]
    public Button freakMode, careerMode, unlimitedMode, btn_BackToMenuFromMenu;
    public Image loadingFreak, loadingCareer, loadingUnlimited, godziny, loading_animation;
    [Header("Score")]
    public Button btn_BackToMenuFromScore, btn_Delete;
    public Image mainImgOnScore, pucharek;
    public Text firstPlace, secondPlace, thirdPlace, howManyHit1, howManyHit2, howManyHit3;
    [Header("Setting")]
    public Image tlo_Setting;
    public Button backToPlayFromSetting,  btn_music, btn_vibro;
    

    

    void Start()
    {
        wygrana = PlayerPrefs.GetInt("Czy Wygra", 0);
        AtStartGame();
    }
    void Update()
    {
        ustawieniaMuzyki = PlayerPrefs.GetInt("Mute");
        if (ustawieniaMuzyki == 1)
        {
            music.mute = false;
        }
        if (ustawieniaMuzyki == 0)
        {
            music.mute = true;
        }
        
    }
    public void AtStartGame()
    {
        tlo_Setting.enabled = false;
        backToPlayFromSetting.enabled = false;
        backToPlayFromSetting.image.enabled = false;
       
        btn_music.enabled = false;
        btn_music.image.enabled = false;
        btn_vibro.enabled = false;
        btn_vibro.image.enabled = false;
        pucharek.enabled = false;
        firstPlace.enabled = false;
        secondPlace.enabled = false;
        thirdPlace.enabled = false;
        howManyHit1.enabled = false;
        howManyHit2.enabled = false;
        howManyHit3.enabled = false;
        mainImgOnScore.enabled = false;
        btn_setting.enabled=true;
        btn_setting.image.enabled = true;
        btn_BackToMenuFromScore.enabled = false;
        btn_BackToMenuFromScore.image.enabled = false;
        btn_Delete.enabled = false;
        btn_Delete.image.enabled = false;
        btn_BackToMenuFromMenu.enabled = false;
        btn_BackToMenuFromMenu.image.enabled = false;
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.Portrait;
        if (ustawieniaMuzyki == 1)
        {
            music.mute = false;
        }
        mainImg.enabled = true;
        exit_btn.image.enabled = true;
        exit_btn.enabled = true;
        play_btn.enabled = true;
        play_btn.image.enabled = true;
        btn_score.enabled = true;
        btn_score.image.enabled = true;
        freakMode.enabled = false;
        careerMode.enabled = false;
        unlimitedMode.enabled = false;
        freakMode.image.enabled = false;
        careerMode.image.enabled = false;
        unlimitedMode.image.enabled = false;
        godziny.enabled = false;
        loadingUnlimited.enabled = false;
        loadingCareer.enabled = false;
        loading_animation.enabled = false;
        loadingFreak.enabled = false;
        wyborSceny = 0;

    }
    public void Setting()
    {
        tlo_Setting.enabled = true;
        backToPlayFromSetting.enabled = true;
        backToPlayFromSetting.image.enabled = true;
     
        btn_music.enabled = true;
        btn_music.image.enabled = true;
        btn_vibro.enabled = true;
        btn_vibro.image.enabled = true;
       
        careerMode.enabled = false;
        unlimitedMode.enabled = false;
        freakMode.image.enabled = false;
        careerMode.image.enabled = false;
        unlimitedMode.image.enabled = false;
        godziny.enabled = false;
        loadingUnlimited.enabled = false;
        loadingCareer.enabled = false;
        loading_animation.enabled = false;
        loadingFreak.enabled = false;
        wyborSceny = 0;
        exit_btn.image.enabled = false;
        exit_btn.enabled = false;
        Time.timeScale = 1;
        play_btn.enabled = false;
        play_btn.image.enabled = false;
        freakMode.enabled = true;
        careerMode.enabled = true;
        unlimitedMode.enabled = true;
        freakMode.image.enabled = true;
        careerMode.image.enabled = true;
        unlimitedMode.image.enabled = true;
        btn_score.enabled = false;
        btn_score.image.enabled = false;
        loading_animation.enabled = false;
    }
    public void Credits()
    {
       
        tlo_Setting.enabled = false;
        backToPlayFromSetting.enabled = false;
        backToPlayFromSetting.image.enabled = false;
 
        btn_music.enabled = false;
        btn_music.image.enabled = false;
        btn_vibro.enabled = false;
        btn_vibro.image.enabled = false;

    }
    public void PlayGame()
    {
        btn_setting.image.enabled = false;
        btn_setting.enabled = false;
        btn_BackToMenuFromMenu.enabled = true;
        btn_BackToMenuFromMenu.image.enabled = true;
        exit_btn.image.enabled = false;
        exit_btn.enabled = false;
        Time.timeScale = 1;
        play_btn.enabled = false;
        play_btn.image.enabled = false;
        freakMode.enabled = true;
        careerMode.enabled = true;
        unlimitedMode.enabled = true;
        freakMode.image.enabled = true;
        careerMode.image.enabled = true;
        unlimitedMode.image.enabled = true;
        btn_score.enabled = false;
        btn_score.image.enabled = false;
        loading_animation.enabled = false;
    }
    public void StartGame(int scena)
    {
        btn_BackToMenuFromMenu.enabled = false;
        btn_BackToMenuFromMenu.image.enabled = false;
        freakMode.enabled = false;
        careerMode.enabled = false;
        unlimitedMode.enabled = false;
        freakMode.image.enabled = false;
        careerMode.image.enabled = false;
        unlimitedMode.image.enabled = false;
        music.mute = true;
        godziny.enabled = true;
        wyborSceny = scena;
        WyborSceny();
    }
    public void ScoreMenu()
    {
        if(wygrana==1)
        {
            pucharek.enabled = true;
        }
        firstPlace.enabled = true;
        secondPlace.enabled = true;
        thirdPlace.enabled = true;
        howManyHit1.enabled = true;
        howManyHit2.enabled = true;
        howManyHit3.enabled = true;
        firstPlace.text= PlayerPrefs.GetFloat("Unlimited Score 1").ToString();
        secondPlace.text = PlayerPrefs.GetFloat("Unlimited Score 2").ToString();
        thirdPlace.text = PlayerPrefs.GetFloat("Unlimited Score 3").ToString();
        howManyHit1.text = PlayerPrefs.GetInt("Freak Score 1").ToString();
        howManyHit2.text = PlayerPrefs.GetInt("Freak Score 2").ToString();
        howManyHit3.text = PlayerPrefs.GetInt("Freak Score 3").ToString();
        mainImgOnScore.enabled = true;
        btn_BackToMenuFromScore.enabled = true;
        btn_BackToMenuFromScore.image.enabled = true;
        btn_Delete.enabled = true;
        btn_Delete.image.enabled = true;
        mainImg.enabled = false;
        exit_btn.image.enabled = false;
        exit_btn.enabled = false;
        Time.timeScale = 1;
        play_btn.enabled = false;
        play_btn.image.enabled = false;
        freakMode.enabled = false;
        careerMode.enabled = false;
        unlimitedMode.enabled = false;
        freakMode.image.enabled = false;
        careerMode.image.enabled = false;
        unlimitedMode.image.enabled = false;
        godziny.enabled = false;
        loadingUnlimited.enabled = false;
        loadingCareer.enabled = false;
        loading_animation.enabled = false;
        loadingFreak.enabled = false;
        btn_score.enabled = false;
        btn_score.image.enabled = false;
        loading_animation.enabled = false;
    }
    void WyborSceny()
    {
        

        switch (wyborSceny)
        {
            case 1:
                Invoke("freak_log", 1f);
                break;
            case 2:
                Invoke("career_log", 1f);
                break;
            case 3:
                Invoke("unlimited_log", 1f);
                break;
        }
        Invoke("zaladujScene", 3f);
        loading_animation.enabled = true;
    }
    void freak_log()
    {
        loadingFreak.enabled = true;
    }
    void career_log()
    {
        loadingCareer.enabled = true;
    }
    void unlimited_log()
    {
        loadingUnlimited.enabled = true;
    }
    void zaladujScene()
    {
        SceneManager.LoadSceneAsync(wyborSceny);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OtworzStroneYTZiemniaka()
    {
    }
}
