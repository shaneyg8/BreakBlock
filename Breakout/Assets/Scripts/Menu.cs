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

	public void LoadLeader()
	{
		Application.LoadLevel ("LeaderboardMenu");
	}

	public void LoadBack()
	{
		Application.LoadLevel ("Main Menu");
	}

    public void Quit()
    {
        Application.Quit();
    } 

}
