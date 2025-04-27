using UnityEngine;

public class M : MonoBehaviour
{
    GameObject myObject; // myObject ist null, weil wir es nicht zugewiesen haben!

    void Start()
    {
        // Hier passiert der Fehler!
        Debug.Log(myObject.name); 
        // myObject ist null → Zugriff auf .name → NullReferenceException!
    }
}
