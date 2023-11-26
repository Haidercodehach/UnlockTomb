using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variable
    Rigidbody2D rb;
    public int speed=1000;
    bool isTouchMoved = false;
    float touchMoveThreshold = .5f;
    Vector3 posA, posB;
    float lockpos = 0f;
    bool isWinScreenShown=false;
    bool isLoseScreenShown =false;
    //Reference
    [SerializeField] GameManager manager;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isWinScreenShown==false&&isLoseScreenShown==false)
        {
            HandleTouch();
            HandleKeyboard();
            // LockPos();

        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WinPoint")
        {
            manager.ActiveWinScreen();
            isWinScreenShown = true;
        }
        if(collision.gameObject.tag == "Enemny")
        {
            manager.ActiveLoseScreen();
            isLoseScreenShown =true;
        }
    }
    void HandleKeyboard()
    {
        if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * speed*-1);
            //transform.rotation= Quaternion.Euler(0,0,0);
        }else if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        { 
            rb.AddForce(transform.up * speed);
            // transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed);
            // transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * speed * -1);
            // transform.rotation = Quaternion.Euler(0, 0, -90);

        }
    }
    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                posA = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                isTouchMoved = true;
            }
            else
            {
                posB = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                float dx = Mathf.Abs(posA.x - posB.x);
                float dy = Mathf.Abs(posA.y - posB.y);
                if (isTouchMoved && (dx > touchMoveThreshold || dy > touchMoveThreshold))
                {
                    Debug.Log("Swiped");
                    if (dx > dy)
                    {
                        if ((posA.x < posB.x))
                        {
                                Debug.Log("Left to Right");
                                rb.AddForce(transform.right * speed);

                        }
                        else
                        {
                            
                                rb.AddForce(transform.right * speed * -1);
                                Debug.Log("Right to Left");
                        }
                    }
                    else
                    {
                        if ((posA.y > posB.y ))
                        {
                            Debug.Log("Top to Bottom");
                            rb.AddForce(transform.up* speed *-1);
                        }
                        else
                        {
                            Debug.Log("Bottom to Top");
                            rb.AddForce(transform.up* speed);
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Debug.Log("Touched");

                    Vector2 pos2D = new Vector2(posB.x, posB.y);
                    RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);
                    //RaycastHit2D hit = Physics2D.Raycast (Input.GetTouch (0).position, Vector2.zero);
                    if (hit.collider != null)
                    {
                        Debug.Log("Touched " + hit.collider.name);
                    }
                }
                isTouchMoved = false;
            }
        }
    }
    void LockPos()
    {
        transform.rotation = Quaternion.Euler(lockpos, lockpos, lockpos);
    }
    int Rotation()
    {
        return 90;
    }
}
