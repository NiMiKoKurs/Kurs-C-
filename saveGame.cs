
using UnityEngine;

public class saveGame : MonoBehaviour
{
    public void zapisz(int a)
    {
        float zapiszKM = FindObjectOfType<carController>().ileKMprzebytoDoUderzenia;
        int zapiszUderzenia = FindObjectOfType<carController>().ileZderzen;
        switch (a)
        {
            case 1:
                int ileObecnie1 = PlayerPrefs.GetInt("Freak Score 1");
                int ileObecnie2 = PlayerPrefs.GetInt("Freak Score 2");
                int ileObecnie3 = PlayerPrefs.GetInt("Freak Score 3");
                if (zapiszUderzenia > ileObecnie3 && zapiszUderzenia < ileObecnie2 && zapiszUderzenia < ileObecnie1)
                {
                    PlayerPrefs.SetInt("Freak Score 3", zapiszUderzenia);
                }
                else if (zapiszUderzenia > ileObecnie3 && zapiszUderzenia > ileObecnie2 && zapiszUderzenia < ileObecnie1)
                {
                    PlayerPrefs.SetInt("Freak Score 3", ileObecnie2);
                    PlayerPrefs.SetInt("Freak Score 2", zapiszUderzenia);
                }
                else if (zapiszUderzenia > ileObecnie3 && zapiszUderzenia > ileObecnie2 && zapiszUderzenia > ileObecnie1)
                {
                    PlayerPrefs.SetInt("Freak Score 3", ileObecnie2);
                    PlayerPrefs.SetInt("Freak Score 2", ileObecnie1);
                    PlayerPrefs.SetInt("Freak Score 1", zapiszUderzenia);
                }
                
                break;
            case 2:
                float ileObecnieKMCareer = PlayerPrefs.GetFloat("Career Score");
                if (zapiszKM > ileObecnieKMCareer)
                {
                    PlayerPrefs.SetFloat("Career Score", zapiszKM);
                }
                break;
            case 3:
                float ileObecnieKMCUnlimited1 = PlayerPrefs.GetFloat("Unlimited Score 1");
                float ileObecnieKMCUnlimited2 = PlayerPrefs.GetFloat("Unlimited Score 2");
                float ileObecnieKMCUnlimited3 = PlayerPrefs.GetFloat("Unlimited Score 3");

                if (zapiszKM > ileObecnieKMCUnlimited3 && zapiszKM < ileObecnieKMCUnlimited2 && zapiszKM < ileObecnieKMCUnlimited1)
                {
                    PlayerPrefs.SetFloat("Unlimited Score 3", zapiszKM);
                }
                else if (zapiszKM > ileObecnieKMCUnlimited3 && zapiszKM > ileObecnieKMCUnlimited2 && zapiszKM < ileObecnieKMCUnlimited1)
                {
                    PlayerPrefs.SetFloat("Unlimited Score 3", ileObecnieKMCUnlimited2);
                    PlayerPrefs.SetFloat("Unlimited Score 2", zapiszKM);
                }
                else if (zapiszKM > ileObecnieKMCUnlimited3 && zapiszKM > ileObecnieKMCUnlimited2 && zapiszKM > ileObecnieKMCUnlimited1)
                {
                    PlayerPrefs.SetFloat("Unlimited Score 3", ileObecnieKMCUnlimited2);
                    PlayerPrefs.SetFloat("Unlimited Score 2", ileObecnieKMCUnlimited1);
                    PlayerPrefs.SetFloat("Unlimited Score 1", zapiszKM);
                }
                break;
        }
    }
    public void UsunDaneFreak()
    {
        PlayerPrefs.DeleteKey("Freak Score 1");
        PlayerPrefs.DeleteKey("Freak Score 2");
        PlayerPrefs.DeleteKey("Freak Score 3");
        PlayerPrefs.DeleteKey("Unlimited Score 1");
        PlayerPrefs.DeleteKey("Unlimited Score 2");
        PlayerPrefs.DeleteKey("Unlimited Score 3");
       
        startGame.FindObjectOfType<startGame>().ScoreMenu();
        
    }
   
}
