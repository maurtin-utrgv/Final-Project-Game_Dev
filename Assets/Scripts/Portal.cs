using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject levelCompleteUI;

 private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player reached the portal!");

            levelCompleteUI.SetActive(true); // Enables the root

            // Enable children manually
            foreach (Transform child in levelCompleteUI.transform)
            {
                child.gameObject.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }


    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}
