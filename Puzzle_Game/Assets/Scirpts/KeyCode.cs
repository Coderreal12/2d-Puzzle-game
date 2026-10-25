using UnityEngine;

public class OnCollision_Enter : MonoBehaviour
{

    [SerializeField] public Player_Inventory Inventory;

    [SerializeField] private int Invetory_Slot;

    [SerializeField] private int key_ID;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
            {

            Inventory.AddKey(Invetory_Slot,key_ID);
            Destroy(gameObject);
        }  
    }
    
}
