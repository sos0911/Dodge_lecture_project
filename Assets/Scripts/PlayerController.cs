using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody PlayerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody caching
        PlayerRigidbody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput= Input.GetAxis("Vertical");

        // xinput, yinput은 -1~1 사이값 (keyboard는 -1,0,1이지만 joystick은 그 사이의 숫자도 가능)
        // input*speed = 그 축의 speed
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        PlayerRigidbody.velocity = newVelocity;
        // 이동이 되나?
    }

    public void Die()
    {
        // player 비활성화
        // destroy와는 다르다.
        gameObject.SetActive(false);
    }
}
