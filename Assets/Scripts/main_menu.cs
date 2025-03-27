using UnityEngine;
using UnityEngine.SceneManagement;


public class main_menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
