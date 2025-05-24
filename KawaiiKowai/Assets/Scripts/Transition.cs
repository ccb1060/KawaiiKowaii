using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Assets/Scenes/Main.unity");
    }

    public void GoToHell()
    {
        Application.Quit();
    }

}
