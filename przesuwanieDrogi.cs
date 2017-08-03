
using UnityEngine;

public class przesuwanieDrogi : MonoBehaviour {

    public GameObject[] drogi;
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }

    void Start()
    {
        GameObject nowaDroga = Instantiate(drogi[0], new Vector3(0, 0, 3), new Quaternion(0, 0, 0, 0));
        NowaDroga(0);
    }

    void Update()
    {
    }
    
    public void NowaDroga(int a)
    {
        if (a == 0)
        {
            GameObject nowaDroga = Instantiate(drogi[a], new Vector3(0, 10, 3), new Quaternion(0, 0, 0, 0));
        }
        else
        {
            GameObject nowaDroga = Instantiate(drogi[a], new Vector3(0, 10, 1), new Quaternion(0, 0, 0, 0));
        }
    }

}
