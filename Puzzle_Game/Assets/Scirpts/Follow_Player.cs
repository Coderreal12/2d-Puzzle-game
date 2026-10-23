using UnityEngine;

public class Follow_Player : MonoBehaviour
{

    [SerializeField] private Transform player;
    private void Update()
    {
        //Transfrom to the player position
        transform.position = new Vector3(player.position.x, player.position.y, -1);
    }
}
