using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{

    [ContextMenu("PlayGame")]
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
