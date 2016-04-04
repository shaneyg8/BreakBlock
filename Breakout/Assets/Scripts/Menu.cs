using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Canvas MainCanvas;

    void awake()
    {

    }

    public void LoadOn()
    {
        Application.LoadLevel(1);
    }
}
