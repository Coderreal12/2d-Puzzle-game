using System.ComponentModel;
using UnityEngine;

public class Connect_Door : MonoBehaviour
{
    private bool pressed = false;
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
            {
            pressed = true;
        } 
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        pressed = false;
    }




    public bool ispressed()
    {

        return pressed;
    }




}
