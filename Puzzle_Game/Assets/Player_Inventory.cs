using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
    public int[] key;

   

    public void AddKey(int x, int y )
    {
        key[x] = y;
    }



}
