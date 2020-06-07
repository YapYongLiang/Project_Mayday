using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Camera mainCam;
    
    public float thrust = 50.0f;
    public float rotatespeed = 80.0f;
    private Rigidbody2D rb2D;
    private float addangle = 180;
    public Texture2D cursorTexture;
    private SpriteRenderer SR;
 
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        rb2D = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
        
        //Vector2 dir = Input.mousePosition - mainCam.WorldToScreenPoint(transform.position);
        //float angle = Mathf.Atan2(dir.x , dir.y) * Mathf.Rad2Deg + addangle;
        //transform.rotation = Quaternion.AngleAxis(angle , -Vector3.forward);

        
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(Input.mousePosition.y - mainCam.WorldToScreenPoint(transform.position).y, Input.mousePosition.x - mainCam.WorldToScreenPoint(transform.position).x);
        
        // Rotate Object
        float AngleDeg = (180 / Mathf.PI) * AngleRad + addangle;        
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        Debug.Log(AngleDeg);

        if(AngleDeg >= 180 && AngleDeg < 270)
        {
           SR.flipY = true;
        }  
        else if(AngleDeg >= 90 && AngleDeg < 180)  
        {
           SR.flipY = true;
        }   
        else
        {
           SR.flipY = false;
        }
        

       
    }



    void FixedUpdate()
    {
       
         if(Input.GetKey(KeyCode.A))
        {
               
                rb2D.AddForce( -transform.right * thrust, ForceMode2D.Force);
        }
        else if(Input.GetKey(KeyCode.D))
        {
               
                rb2D.AddForce(transform.right * thrust, ForceMode2D.Force);
        }
        
        if(Input.GetKey(KeyCode.S))
        {
               
                rb2D.velocity = rb2D.velocity * 0.93f;
        }
    
      

    }
}
