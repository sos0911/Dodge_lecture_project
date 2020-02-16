using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{

    public float rotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // y축 기준으로 돌려버리기
        // time.deltatime을 곱했으므로 결국 1초에 rotationspeed만큼 회전하게 됨
        transform.Rotate(0f, rotationSpeed*Time.deltaTime, 0f);

    }
}
