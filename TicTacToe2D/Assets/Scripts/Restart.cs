using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
    
	public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
