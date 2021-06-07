using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    public float WOW = 5f;
    [Tooltip("М/C")][SerializeField] float Speed = 9f;
    [SerializeField] float xClamp = -15f;
    [SerializeField] float yClamp = -10f;
    [SerializeField] float xRotFactor = 5f;
    [SerializeField] float yRotFactor = 4f;
    [SerializeField] float zRotFactor = 5f;
    [SerializeField] float xMoveSpeed = 20f;
    float xMove,yMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     MoveShip();
     RotateShip();   
    
    }
    void MoveShip()
    {
        float xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float yMove = CrossPlatformInputManager.GetAxis("Vertical");
        print(yMove);

        float yOffset = Speed * yMove * Time.deltaTime;
        float xOffset = Speed * xMove * Time.deltaTime;

        float NewYPos = transform.localPosition.y + yOffset;
        float NewXPos = transform.localPosition.x + xOffset;
        
        float clampYPos = Mathf.Clamp(NewYPos,yClamp,-yClamp);
        float clampXPos = Mathf.Clamp(NewXPos,xClamp,-xClamp);

        transform.localPosition = new Vector3 (clampXPos,clampYPos,transform.localPosition.z);
    }
    void RotateShip()
    {
        float xRot = transform.localPosition.y * xRotFactor + yMove*xMoveSpeed;
        float yRot = 0f;
        float zRot = 0f;
        transform.localRotation = Quaternion.Euler(xRot,0,0);
    }
}
