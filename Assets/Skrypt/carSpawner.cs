
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    public GameObject[] cars;
    int carNo;
    float[] carSpawPos = new float[2] { -1.2f, 1.2f };
    Vector3 carPos;
    public float delayTimer = 0.5f;
    float timer;
    public float ileMetrow;
    GameObject zPradem, podPrad;
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }

    void Start ()
    {
        delayTimer = 1.2f;
        timer = delayTimer;
	}
	
	void Update ()
    {
            delayTimer -= ileMetrow / 100000;
            //Debug.Log(delayTimer);
            if (delayTimer <= 0.4)
            {
                delayTimer = 0.4f;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnCar();
                timer = delayTimer;
            }
        
    }
    void SpawnCar()
    {
       
        carNo = Random.Range(0, cars.Length);
        float result = carSpawPos[Random.Range(0, carSpawPos.Length)];
        //Debug.Log(result);
        if (result == -1.2f)
        {
            zPradem = cars[carNo];
            //Debug.Log("lewo");
            Vector3 carPos = new Vector3(result, transform.position.y, transform.position.z);
            zPradem.GetComponent<SpriteRenderer>().flipY = false;
            Instantiate(zPradem, carPos, transform.rotation);
        }
        else
        {
            podPrad = cars[carNo];
            //Debug.Log("prawo");
            Vector3 carPos = new Vector3(result, transform.position.y, transform.position.z);
            podPrad.GetComponent<SpriteRenderer>().flipY = true;
            Instantiate(podPrad, carPos, transform.rotation);
            
        }
    }
}
