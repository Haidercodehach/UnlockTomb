using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunctions : MonoBehaviour
{
    int currentLevelIndex;
    private void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevelIndex+1);
    }
}
