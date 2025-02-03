using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	//audio stuff goes here

    public void NewGame()
	{
		SceneManager.LoadScene("MainGame");
	}

}
