using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ball ball;
    public paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topright;

    // Start is called before the first frame update
    void Start()
    {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topright = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        Instantiate(ball);

        paddle paddle1 = Instantiate(paddle) as paddle;
        paddle paddle2 = Instantiate(paddle) as paddle;

        paddle1.Init(false);
        paddle2.Init(true);
        


    }

    
}
