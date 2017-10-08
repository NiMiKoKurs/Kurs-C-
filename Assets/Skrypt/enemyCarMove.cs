
using UnityEngine;

public class enemyCarMove : MonoBehaviour
{

    public float speedEnemy;
    public Vector3 EnemySpeed;
    void Awake()
    {
        Application.targetFrameRate = 45;
        QualitySettings.vSyncCount = 1;
    }
  
	
	void Update ()
    {
        EnemySpeed = new Vector3(0, 1, 0) * speedEnemy * Time.deltaTime;
        transform.Translate(EnemySpeed);
	}
}
