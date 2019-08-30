using UnityEngine;

public class Car : MonoBehaviour
{

    public float moveSpeed = 5f;
    public bool moveRight = false;


    void Start()
    {

    }


    void Update()
    {
        Vector2 pos = transform.localPosition;

        if (moveRight)
        {
            pos.x += Vector2.right.x * moveSpeed * Time.deltaTime;
            if (pos.x >= 7)
            {
                pos.x = -7;
            }
        }
        else
        {
            pos.x += Vector2.left.x * moveSpeed * Time.deltaTime;
            if (pos.x <= -7)
            {
                pos.x = 7;
            }
        }



        transform.localPosition = pos;

    }
}
