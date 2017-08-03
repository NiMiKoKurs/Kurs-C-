
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    public Image ziemniak,lennyFace;
    bool wlaczLevel;

    void Start()
    {
        lennyFace.enabled = false;
        wlaczLevel = false;
        PlayerPrefs.SetInt("Mute", 1);
        PlayerPrefs.SetInt("Vibro", 1);
    }
    void Update()
    {
        if (transform.position.x >= 300f)
        {
            lennyFace.enabled = true;
        }
        if(transform.position.x <300f)
        {
            lennyFace.enabled = false;
        }
        if (transform.position.x>=590f && wlaczLevel==false)
        {
            SceneManager.LoadSceneAsync(1);
            wlaczLevel = true;
        }

    }
}
