using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;
    float radius;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        //rebote izquierda derecha
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topright.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }


        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.y < 0)
        {
            Debug.Log("El jugador de la derecha gana");
            Time.timeScale = 0;
            enabled = false;

        }
        if (transform.position.x > GameManager.topright.x - radius && direction.y > 0)
        {
            Debug.Log("El jugador de la izquierda gana");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<paddle>().isRight;

            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
