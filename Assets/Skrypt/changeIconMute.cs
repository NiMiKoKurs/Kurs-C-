
using UnityEngine;
using UnityEngine.UI;


public class changeIconMute : MonoBehaviour {

    public Image ToChange;
    public Sprite On, Off;
    int zmiana;

	
	
	void Update ()
    {
        zmiana = PlayerPrefs.GetInt("Mute");
		if(zmiana ==1)
        {
            ToChange.sprite = On;
        }
        if (zmiana == 0)
        {
            ToChange.sprite = Off;
        }
    }
    public void ClickToChangeIconZmien()
    {
        if(zmiana ==0)
        {
            PlayerPrefs.SetInt("Mute", 1);//0 off || 1 on
        }
        if (zmiana == 1)
        {
            PlayerPrefs.SetInt("Mute", 0);//0 off || 1 on
        }
    }
}
