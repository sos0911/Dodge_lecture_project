using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletprefab;
    public float spawnRateMin = 0.5f; // 탄알 최소생성주기
    public float spawnRateMax = 3f; // 탄알 최대생성주기

    private Transform target; // 탄알이 날아갈 대상의 위치
    private float spawnRate; // 생성주기
    private float timeAfterSpawn; // 최근 생성 후 경과시간

    // Start is called before the first frame update
    void Start()
    {
        // 처음에는 탄알을 쏘지 않았으므로 0f
        timeAfterSpawn = 0f;
        // min <= spawnrate < max
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 타입의 오브젝트 하나를 scene에서 찾아 tranform 컴포넌트를 caching
        // 어차피 player는 맵상에 하나밖에 존재하지 않음
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 각 프레임 간의 시간 = deltatime
        // ex : 120fps라면 deltatime=1/120
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            // 탄알 생성
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
            // 생성된 탄알이 player를 보게 회전
            bullet.transform.LookAt(target);
            // 한번 만들어낸 후에는 간격이 랜덤으로 설정됨
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
