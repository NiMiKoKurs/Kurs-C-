
using UnityEngine;

public class trackMove : MonoBehaviour {

    public GameObject droga;
    public float speed;
    public Vector2 offset;
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }
   
	void Update () {
        offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
      
    }
  
}
