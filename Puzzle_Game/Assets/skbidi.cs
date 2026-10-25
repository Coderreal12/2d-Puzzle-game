using UnityEngine;
using UnityEngine.SceneManagement;
public class skbidi : MonoBehaviour
{
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void onclcik()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
