using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    // gameovertext는 실시간으로 내용이 변경될 필요가 없으므로 게임오브젝트로 선언함
    public GameObject gameovertext;
    public TextMeshProUGUI timetext;
    public TextMeshProUGUI recordtext;

    private float survivetime;
    private bool isGameover; // 게임이 끝났는가?

    // Start is called before the first frame update
    void Start()
    {
        survivetime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            // 1초에 1씩 증가하게 됨
            survivetime += Time.deltaTime;
            // 초단위로 끊어서 표현
            timetext.text = "Time : " + (int)survivetime;
        }
    }
}
