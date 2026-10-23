using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform HeadHeight;

    [SerializeField] private Transform PickupAble;

    [SerializeField] private Transform SqaureDefualt;

    [SerializeField] private bool pickup;

    [SerializeField] private bool flop = false;

    [SerializeField] private Rigidbody2D player;

    [SerializeField] private float x_offset;

    
    
    private float rotation;
    void Update()
    {
        Rotate(ref rotation);




        //Sending Raycast
        RaycastHit2D hit = Physics2D.Raycast(HeadHeight.position, Vector2.right, rotation * 2f);


        if (hit.collider != null)
        {
            pickup = hit.collider.gameObject.CompareTag("P");
            
            PickUp(hit);
            //Debug.Log(hit.collider.gameObject.tag);
        }




        PickUp(hit);

       




    }




    private void PickUp(RaycastHit2D hit)
    {
        //If it is LOOKING at the box then Flip flop with E, if it is NOT looking at the box then flop always = false;
        flip(ref flop);

        






    }


    private void flip(ref bool flop)

    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            flop = !flop;
        }
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
