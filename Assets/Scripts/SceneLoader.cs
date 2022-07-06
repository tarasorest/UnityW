using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PrevScene()
    {
        SceneManager.LoadScene(0);
    }
}
