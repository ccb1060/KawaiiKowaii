using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string path = "Assets/Scenes/Main.unity";

    public void NewGameButton()
    {
        SceneManager.LoadScene(path);
    }
}
