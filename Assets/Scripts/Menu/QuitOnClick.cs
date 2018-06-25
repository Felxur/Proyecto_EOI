using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit ();
    }

}