using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;
    private Rigidbody bulletrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletrigidbody = GetComponent<Rigidbody>();
        // 방향은 bullet 기준 앞 방향으로 설정됨
        // 속도만 rigidbody에서 설정해주면 자기가 알아서감
        // 이건 처음알았네..
        bulletrigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 총알끼리 부딪힐 수도 있으므로 태그 검사
        if (other.tag == "Player")
        {
            Debug.Log("conflict!");
            // 만약 getcomponent 결과가 없다면 null이 저장됨
            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
                playercontroller.Die();
        }
        // 벽에 닿으면 소멸
        else if (other.tag == "Wall")
            Destroy(gameObject);
    }
}
