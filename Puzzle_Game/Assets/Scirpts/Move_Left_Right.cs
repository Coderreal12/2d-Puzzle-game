using Unity.VisualScripting;
using UnityEngine;

public class Move_Left_Right : MonoBehaviour
{
    [Header("Scripts")]

    [SerializeField] move plat;

    [Header("Variabels")]

    [SerializeField] private float speed;

    

    [Header("Transforms")]
    [SerializeField] private Transform target;

    [SerializeField] private Transform pointA;

    [SerializeField] private Transform pointB;

    [SerializeField] private GameObject charecter;

    [SerializeField] private GameObject temp;

    [SerializeField] private GameObject self;

    private bool touch;

    private void Awake()
    {
        target.position = pointA.position;

        self = gameObject;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        Change_Target(ref target, pointA, pointB);

        plat.display(ref touch);

        
        SetParent(charecter, touch, temp);
        






    }


    private void Change_Target(ref Transform target, Transform pointA, Transform pointB)
    {
        if(transform.position == pointA.position)
        {
            target.position = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            target.position = pointA.position;
        }

    }

    void SetParent(GameObject player, bool onplatform, GameObject temp)
    {


        if (onplatform)
        {
            player.transform.parent = self.transform;
        }
        else
        {
            player.transform.parent = temp.transform.parent;
        }

       
    }


}
