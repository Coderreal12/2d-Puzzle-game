using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Active_self : MonoBehaviour
{
    private int Level_1 = 1;
    [SerializeField] private GameObject Respawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn.SetActive(false);
    }

    public void respawn()
    {
        SceneManager.LoadScene(Level_1);
        Time.timeScale = 1;
    }

    public void Main()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }




}
