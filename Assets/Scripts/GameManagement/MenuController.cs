using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(int scene) => SceneManager.LoadScene(scene);

    public void QuitGame() => Application.Quit(0);
}
