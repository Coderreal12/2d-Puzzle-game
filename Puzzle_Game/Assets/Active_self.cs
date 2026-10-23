using UnityEngine;
using UnityEngine.SceneManagement;
public class Active_self : MonoBehaviour
{
    private int Level_1 = 0;
    [SerializeField] private GameObject Respawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn.SetActive(false);
    }

    public void respawn()
    {
        SceneManager.LoadScene(Level_1);
    }




}
