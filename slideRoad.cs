
using UnityEngine;

public class slideRoad : MonoBehaviour {

    Vector3 pozStartDrogi,checkPos;
    Vector3 pozZero = new Vector3(0, 0, 1);
    Vector3 pozZeroBeton = new Vector3(0, 0, 3);
    Vector3 pozKoniecDrogi = new Vector3(0, -9.9f, 1);
    Vector3 pozKoniecDrogiBeton = new Vector3(0, -9.9f, 3);
    float SlideSpeed = 3f;
    float startTime, startTimeToBottom;
    public float speed = 1;
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }
    void Start ()
    {
        startTime = Time.timeSinceLevelLoad;
        pozStartDrogi = transform.position;
	}
	
	void Update ()
    {
        checkPos = transform.position;
        if (checkPos.z == 3)
        {
            if (checkPos.y > pozZeroBeton.y)
            {
                RollToCenter3();
            }

            else
            {
                RollToBottom3();
            }
        }
        else
        {
            if (checkPos.y > pozZero.y)
            {
                RollToCenter1();
            }

            else
            {
                RollToBottom1();
            }
        }
        if (checkPos.y == pozKoniecDrogi.y|| checkPos.y == pozKoniecDrogiBeton.y)
        {
            DestroyMyself();
        }
    }
    void RollToCenter1()
    {
        float dlugoscDrogi = Vector3.Distance(pozStartDrogi, pozZero);
        float distCovered = (Time.timeSinceLevelLoad - startTime) * SlideSpeed;
        float slideIt = (distCovered / dlugoscDrogi)*speed;
        transform.position = Vector3.Lerp(pozStartDrogi, pozZero,  slideIt);
        startTimeToBottom = Time.timeSinceLevelLoad;
    }
    void RollToBottom1()
    {
        float dlugoscDrogi = Vector3.Distance(pozZero, pozKoniecDrogi);
        float distCovered = (Time.timeSinceLevelLoad - startTimeToBottom) * SlideSpeed;
        float slideIt = (distCovered / dlugoscDrogi)*speed;
        transform.position = Vector3.Lerp(pozZero, pozKoniecDrogi,  slideIt);
    }
    void RollToCenter3()
    {
        float dlugoscDrogi = Vector3.Distance(pozStartDrogi, pozZeroBeton);
        float distCovered = (Time.timeSinceLevelLoad - startTime) * SlideSpeed;
        float slideIt = distCovered / dlugoscDrogi;
        transform.position = Vector3.Lerp(pozStartDrogi, pozZeroBeton, slideIt);
        startTimeToBottom = Time.timeSinceLevelLoad;
    }
    void RollToBottom3()
    {
        float dlugoscDrogi = Vector3.Distance(pozZeroBeton, pozKoniecDrogiBeton);
        float distCovered = (Time.timeSinceLevelLoad - startTimeToBottom) * SlideSpeed;
        float slideIt = distCovered / dlugoscDrogi;
        transform.position = Vector3.Lerp(pozZeroBeton, pozKoniecDrogiBeton, slideIt);
    }
    void DestroyMyself()
    {
        Destroy(this.gameObject);
        NowaDroga();
    }
    void NowaDroga()
    {
        int los = Random.Range(0, 2);
        przesuwanieDrogi.FindObjectOfType<przesuwanieDrogi>().NowaDroga(los);
        
    }

}
