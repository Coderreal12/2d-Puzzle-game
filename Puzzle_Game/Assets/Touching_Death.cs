using UnityEngine;
using TMPro;

using System;
using UnityEditor;


public class Touching_Death : MonoBehaviour
{
    [Header("Canvasas")]
    [SerializeField] private GameObject Death_Screen;

    [SerializeField] private GameObject time;

    [SerializeField] private GameObject win_text;

    [SerializeField] private GameObject Respawn_Button;

    [SerializeField] private GameObject dead;

    [SerializeField] private GameObject Menu;

    [SerializeField] private GameObject respawn;

    [SerializeField] private GameObject BUGUIOHSDI;


    [Header("Scripts")]
    [SerializeField] private move Move_Script;

    //Variables
    private bool EnableDeath = false;
    private float tiempo;

    private bool win = false;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI score;

    private void Start()
    {
       // BUGUIOHSDI.SetActive(false);
         dead.SetActive(false);
        Menu.SetActive(false);
        Respawn_Button.SetActive(false);
    }
    private void Update()
    {
        tiempo +=  Time.deltaTime;
        
        score.SetText("Score: " + Convert.ToString(tiempo));
        win_text.SetActive(win);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.CompareTag("Kill"))
        {
            
            EnableDeath = true;
            Move_Script.Die();
            Time.timeScale = 0;
            Respawn_Button.SetActive(true);
            dead.SetActive(true);
            Menu.SetActive(true);
            respawn.SetActive(true);
            //BUGUIOHSDI.SetActive(true);
        }
      else if(collision.gameObject.CompareTag("Win"))
        {
            win = true;
            Time.timeScale = 0;
            Move_Script.Die();
            Respawn_Button.SetActive(true);
            Menu.SetActive(true);
            //BUGUIOHSDI.SetActive(true);
        }

    }



}
