using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadProblem(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Main Menu");
        if (objs.Length > 1)
        {
            Destroy(objs[0]);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
