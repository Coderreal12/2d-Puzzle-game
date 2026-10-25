using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.Rendering;

public class move : MonoBehaviour
{
    //Movmment Variables
    private float x;
    private float y;

    private float First_Speed;

    private float Double_Speed;

    [Header("Transforms")]
    [SerializeField] private Transform wall_Jump;
            
    



    [Header("Rigid Bodies")]
    [SerializeField] private Rigidbody2D player;

    [Header("Variabels")]


    [Header("Floats")]

[SerializeField] private float Wall_Jump_Length;

    [SerializeField] private float speed;

    [SerializeField] private float Jump_Height;

    [SerializeField] private float jumpCount;

    [SerializeField] private float Y_offset;

    [SerializeField] private float x_offset;

    [SerializeField] private float amountofjumps;

    [Header("Bools")]

    [SerializeField] private bool isgrounded;

    [SerializeField] private bool onplatform;

    [SerializeField] private bool walljump;

   [SerializeField] private bool dead = false;

    [Header("String")]

    [SerializeField] private string[] layermasks;

    

    [SerializeField] private Vector2 offset;
    [Header("Animators")]

    [SerializeField] private Animator animation;

    

    void Start()
    {
        First_Speed = speed;

        Double_Speed = speed * 1.25f;
    }

   
    void Update()
    {

        
        //Input from player
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        
        Double_Jump(isgrounded, ref jumpCount, ref walljump);

       
        isgrounded = send();

     
        onplatform = onplat();

        
sprint(ref speed);

       if(dead == true)
        {
            speed = 0;
        }
        Move(x);

        
        Jump(y, isgrounded,onplatform);

       


    }

    private void Move(float x)
    {
        //Setting the player velocity equal to x multiplied by the speed.


        player.linearVelocity = new Vector2(x * speed, player.linearVelocity.y);
        // VISUALS Setting animation to true or false.
        if (x != 0)
        {
            animation.SetBool("Run", true);
        }
        else
        {
            animation.SetBool("Run", false);
        }

        //VISUAL Looking left/ right
        if (x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0,0);
        }
        else if (x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }




    }


    private void Jump(float y, bool isgrounded,bool onplatform)
    {
        if (y == 1 && isgrounded == true)
        {
            //If Y is equal to one then you are able to jump up
            player.linearVelocity = new Vector2(player.linearVelocity.x, y * Jump_Height);
        }
        else if (y == 1 && walljump == true)
        {
            player.linearVelocity = new Vector2(player.linearVelocity.x, y * Jump_Height);
        }


    }    

    private bool send()
    {
        //Creating A vector2 of player position, this is becasue subtraction doesnt translate well.
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);    

        //Setting temporary variable to the raycast.
        bool temp = Physics2D.Raycast(transform.position, Vector2.down, .2f, LayerMask.GetMask(layermasks));

        //Drawing Line * Will get Removed Soon *
        Debug.DrawLine(transform.position,  pos +  Vector2.down * .2f, Color.red);

        //returning temporary bool.
        return temp ;
    }



    private bool onplat()
    {
        bool temp = Physics2D.Raycast(transform.position, Vector2.down, .2f, LayerMask.GetMask("Platform"));
        return temp;
    }



    public void display(ref bool e)
    {
        

        e = onplatform;
    }

    public void Die()
    {
        
        dead = true;
        
    }

    private bool WallJump()
    {


        bool temp = Physics2D.Raycast(wall_Jump.position, wall_Jump.right, Wall_Jump_Length, LayerMask.GetMask("Ground"));

        Vector2 pos = new Vector2(wall_Jump.position.x, wall_Jump.position.y);


        //Right here
        Debug.DrawLine(pos, pos + Vector2.right * Wall_Jump_Length);
        return temp;
    }

    private void Double_Jump(bool isgrounded, ref float jumpcount, ref bool walljump)
    {
        //If it is on the ground set wall jump to 0
        if (isgrounded == true)
        {
            jumpCount = amountofjumps;
        }

        // if you are looking at wall, pressing W, and you have a 1 jump count, then jump!
        if (WallJump() && Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            walljump = true;
            jumpCount--;
            
        }
        
        //If Jump Count is 0 then dont jump :(.
        else if (jumpCount == 0)
        {
            walljump = false;
        }
        else if (WallJump() == false)
        {
            walljump = false;
        }
    }

    void sprint(ref float speed)
    {

        if(dead== true)
        {
            speed = 0;
        }
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {

            speed = Double_Speed;

            
        }
        else 
        {
            speed = First_Speed;
        }
    }



}
