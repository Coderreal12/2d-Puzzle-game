using UnityEngine;

public class Touching_Death : MonoBehaviour
{
    [Header("Canvasas")]
    [SerializeField] private GameObject Death_Screen;

    [Header("Scripts")]
    [SerializeField] private move Move_Script;

    //Variables
    private bool EnableDeath = false;



    private void Update()
    {
        Death_Screen.SetActive(EnableDeath);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Kill"))
        {
            Debug.Log("I am dead");
            EnableDeath = true;
            Move_Script.Die();

        }
    }



}
