using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform HeadHeight;

    [SerializeField] private Transform Holding;

    [SerializeField] private Transform SqaureDefualt;

    

    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float x_offset;



    [Header("Bools")]




    [SerializeField] private bool carrying = false;





    [Header("PickUp Rigidbodies/Transforms")]

    [SerializeField] private GameObject square;

    [SerializeField] private GameObject Defualt;

    //If havig null trouble serialze;
    
    


    private float rotation;
    void Update()
    {
        Rotate(ref rotation);




        //Sending Raycast
        RaycastHit2D hit = Physics2D.Raycast(HeadHeight.position, Vector2.right, rotation * 2f);


        if (hit.collider != null)
        {





            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.CompareTag("P") && carrying == false)
            {
               
                PickUp(hit);

                carrying = true;
               
            }
             
         
           
            

            
        }
         if (Input.GetKeyDown(KeyCode.R) && carrying == true )
            {
                
                LetGo(hit);
            carrying = false;
                
            }    
            //plan for later jaxon ----> Use the new bool carrying to create logic within (Pickup) and (LetGo)

            //LetGo(hit);

            
        

       




    }




    private void PickUp(RaycastHit2D hit)
    {
        square = hit.collider.gameObject;
        square.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        square.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        square.transform.position = Holding.transform.position;
        square.transform.SetParent(Holding);

    }
    private void LetGo(RaycastHit2D hit)
    {
        square.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        square.transform.SetParent(SqaureDefualt);

    }

  


    private void Rotate(ref float rotation)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rotation = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rotation = 1;
        }
    }


    




    
}
