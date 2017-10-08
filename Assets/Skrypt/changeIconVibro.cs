
using UnityEngine;
using UnityEngine.UI;


public class changeIconVibro : MonoBehaviour {

    public Image ToChange;
    public Sprite On, Off;
    int zmiana;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        zmiana = PlayerPrefs.GetInt("Vibro");
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
            PlayerPrefs.SetInt("Vibro", 1);//0 off || 1 on
        }
        if (zmiana == 1)
        {
            PlayerPrefs.SetInt("Vibro", 0);//0 off || 1 on
        }
    }
}
