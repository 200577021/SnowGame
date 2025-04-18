using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    // Level Variable
    public int level;
 
    // Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    // Load Game Complete
    public void BackToMainMenu()
    {
        GameManager.Instance.Level = 1;
        GameManager.Instance.WinScore = 10;
        GameManager.Instance.Score = 0;
        GameManager.Instance.collisionCounter = 0;
        GameManager.Instance.Lives = 50;
        GameManager.Instance.RestartGame();
        // Load the main menu scene
        SceneManager.LoadScene(0);
    }
 
    public void PlayBtnClicked()
    {
        if (level < 1)
        {
            // Load Level 1
        LoadLevel1();
        } else if (level == 10)
        {
            // Game over / Game complete, so back to the main menu
            BackToMainMenu();
        }
        
    }
 
void Update()
    {
        // handling back button behaviour
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit the application
            Application.Quit();
        }
    }
}
 