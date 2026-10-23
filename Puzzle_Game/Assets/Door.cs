using System.Net.NetworkInformation;
using UnityEngine;

public class Door : MonoBehaviour
{
    //LogIn Code for THIS door.
    

    [Header("Scripts")]

    [SerializeField] private Connect_Door door;

    [SerializeField] private Transform up;

    [SerializeField] private float speed;

    [SerializeField] private Transform OrignalPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OrignalPosition.transform.position = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

       if (door.ispressed())
        {
            transform.position = Vector3.MoveTowards(transform.position, up.position, speed * Time.deltaTime);
        }
       else
        {
            transform.position = Vector3.MoveTowards(transform.position, OrignalPosition.transform.position, speed * Time.deltaTime);
        }
        
    }
}
