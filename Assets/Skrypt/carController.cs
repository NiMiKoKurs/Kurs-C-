
using UnityEngine;
using UnityEngine.UI;

public class carController : MonoBehaviour {

    public float carSpeed;
    Vector3 position, boom;
    public bool right = false;
    float left = -1.2f;
    public int ileZderzen = 0, ileZyc;
    public float ileKMprzebyto, ileMinelo, ileKMprzebytoDoUderzenia = 2000,mnoznikKilometrow;
    public Text uderzenia;
    public bool isPlayerExist = true;
    public string gameMode;
    public Sprite[] sprites;
    public SpriteRenderer spriteR;
    uiManager UiM;
    GameObject wybuchTu;
    private static AndroidJavaObject vibrator;
    private static AndroidJavaObject currentActivity
    {

        get
        {
            return new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        }

    }
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }
    void Start ()
    {
        mnoznikKilometrow =  40.111f;
        ileZyc = 1;
        ileMinelo = 0;
        UiM = FindObjectOfType<uiManager>();
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[0];
        Screen.orientation = ScreenOrientation.Portrait;
        position = transform.position;
        gameMode = FindObjectOfType<uiManager>().gameMode.text;
        if (gameMode == "Freak Mode")
        {
            IleUderzyc(0);
        }
        ileKMprzebyto = 0;
	}
	
	void Update ()
    {
        if (mnoznikKilometrow < 95)
        {
            mnoznikKilometrow += Time.deltaTime;
        }
        else if (mnoznikKilometrow >= 95 && mnoznikKilometrow <120)
        {
            mnoznikKilometrow += (Time.deltaTime *3);
        }
        TrackCounter();
        ileKMprzebyto = ileMinelo;
        
        if (((ileKMprzebytoDoUderzenia + 0.1f) < ileKMprzebyto))
        {
            spriteR.sprite = sprites[0];
        }
        
        
        if ((Input.GetKeyDown(KeyCode.RightArrow)) && right == false && isPlayerExist == true && Time.timeScale == 1)
        {
            position.x = -left;
            transform.position = position;
            right = true;
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow)) && right == true && isPlayerExist == true && Time.timeScale == 1)
        {
            position.x = left;
            transform.position = position;
            right = false;
        }
        if (gameMode == "Career Mode")
        {
           
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        spriteR.sprite = sprites[1];
        ileKMprzebytoDoUderzenia = ileMinelo;
        boom = new Vector3(coll.transform.position.x, coll.transform.position.y, coll.transform.position.z);
        Vector3 miejsceWybuchu = new Vector3(boom.x + 0.42f, boom.y, boom.z);
        wybuchTu = Instantiate(FindObjectOfType<uiManager>().wybuch, miejsceWybuchu, transform.rotation);
        if (PlayerPrefs.GetInt("Vibro") == 1)
        {
            Vibrate(300);
        }
        
        if (gameMode == "Freak Mode")
        {
            ileZderzen += 1;
            Destroy(wybuchTu, 0.2f);
            IleUderzyc(ileZderzen);
        }
        else if(gameMode == "Career Mode")
        {
            coll.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            if (ileZyc == 0)
            {
                Smierc();
            }
            ileZyc--;
            Destroy(wybuchTu, 0.2f);
        }
        else
        {
            Smierc();
            Destroy(wybuchTu, 0.2f);
        }

    }
    void Smierc()
    {
        FindObjectOfType<carSpawner>().delayTimer = 100000f;
        FindObjectOfType<saveGame>().zapisz(UiM.nrSceny);
        isPlayerExist = false;
        UiM.Dead();
    }
    public void UsunPozostale()
    {
        Destroy(wybuchTu);
    }

    void IleUderzyc(int a)
    {
        uderzenia.text = "Hit : " + a.ToString();
    }
    public void MoveLeft()
    {
        position.x = left;
        transform.position = position;
        right = false;
    }
    public void MoveRight()
    {
        position.x = -left;
        transform.position = position;
        right = true;
    }
    public void DestroyCar()
    {
        position.x = -4;
        transform.position = position;
        right = false;
    }
    public static void Vibrate(long milliseconds)
    {
        if (Application.platform != RuntimePlatform.Android)
            return;
        try
        {
            if (vibrator == null)
                vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
            vibrator.Call("vibrate", milliseconds);
        }
        catch
        {
            Handheld.Vibrate();
        }
    }
    void TrackCounter()
    {
        ileMinelo = (Mathf.Round(Time.timeSinceLevelLoad * mnoznikKilometrow) / 1000) * 10;
        FindObjectOfType<carSpawner>().ileMetrow = ileMinelo;
        if (isPlayerExist == true)
        {
            if (UiM.nrSceny == 3)
            {
                UiM.ileKm.text = (ileMinelo).ToString() + " KM";
            }
            else
            {
                float howManyLeft = 200-(Mathf.Round(Time.timeSinceLevelLoad * mnoznikKilometrow) / 1000) * 10;
                UiM.ileKm.text = (howManyLeft).ToString() + " KM";
            }
        }
        else
        {
            FindObjectOfType<uiManager>().muzykaWGrze.volume = 0.05f;
            ileMinelo = 0;
        }

    }
    
}
