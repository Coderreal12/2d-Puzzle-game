using System;
using Unity.VisualScripting;
using UnityEngine;

public class UnLock : MonoBehaviour
{
    
    public Player_Inventory Player_Inventory;

    [SerializeField] private int Lock;
    private void Update()
    {
        //For each int in the array key.
        foreach (int key in Player_Inventory.key)
        {
            
            //If the key is = to the lock (lock Id) Then destroy it
            if(key == Lock)
            { 
                Destroy(gameObject);
                
            }
            
            

        }
        
    }
}
