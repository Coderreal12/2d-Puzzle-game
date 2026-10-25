using System.ComponentModel;
using UnityEngine;

public class Connect_Door : MonoBehaviour
{
    private bool pressed = false;

    [SerializeField] private string[] colliders;
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        foreach (string colliders in colliders)
        {

if (collision.gameObject.CompareTag(colliders))
            {
            pressed = true;
        } 

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
