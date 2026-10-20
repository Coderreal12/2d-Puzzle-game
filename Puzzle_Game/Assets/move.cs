using JetBrains.Annotations;
using UnityEngine;

public class move : MonoBehaviour
{
    //Movmment Variables
    private float x;
    private float y;
    [Header("Rigid Bodies")]
    [SerializeField] private Rigidbody2D player;

    [Header("Variabels")]

    [SerializeField] private float speed;

    [SerializeField] private float Jump_Height;

    [SerializeField] private bool isgrounded;

    [Header("Animators")]

    [SerializeField] private Animator animation;
    void Start()
    {
        
    }

   
    void Update()
    {
        //Input from player
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        isgrounded = send();
        
        Move(x);
        Jump(y, isgrounded);



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


    private void Jump(float y, bool isgrounded)
    {
        if (y == 1 && isgrounded == true)
        {
            //If Y is equal to one then you are able to jump up
            player.linearVelocity = new Vector2(player.linearVelocity.x, y * Jump_Height);
        }
    }    

    private bool send()
    {
        //Creating A vector2 of player position, this is becasue subtraction doesnt translate well.
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);    

        //Setting temporary variable to the raycast.
        bool temp = Physics2D.Raycast(transform.position, Vector2.down, .2f, LayerMask.GetMask("Ground"));

        //Drawing Line * Will get Removed Soon *
        Debug.DrawLine(transform.position,  pos +  Vector2.down * .2f, Color.red);

        //returning temporary bool.
        return temp ;
    }
}
