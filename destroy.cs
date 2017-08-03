
using UnityEngine;

public class destroy : MonoBehaviour {

 
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
    }
    
}
