
using UnityEngine;
using UnityEngine.UI;


public class changeIconFuel : MonoBehaviour {

    public Image ToChange;
    public Sprite Full,Empty;
    int zmiana;

	void Start ()
    {
	}

    void Update()
    {
        zmiana = FindObjectOfType<carController>().ileZyc;
        if(zmiana == 1)
        {
            ToChange.sprite = Full;
        }
        else if (zmiana == 0)
        {
            ToChange.sprite = Empty;
        }
    }
}
