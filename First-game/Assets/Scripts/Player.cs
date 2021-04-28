using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   // vitesse de notre player 
   
   
    

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float moveSpeed=10f  ;




    void Start ()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    // Update is called once per frame
    void Update()
    {
        // movement = Input.GetAxisRaw("Horizontal"); 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
