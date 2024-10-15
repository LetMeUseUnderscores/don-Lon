using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public void SwapScene() {
        SceneManager.LoadScene(scene);
    }
}
