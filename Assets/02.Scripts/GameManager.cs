using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] obstacles;

    public float spawnDelay;    // 스폰되는 시간 간격
    private float spawnTimer;   // 스폰하기 위한 타이머(시간을 재기 위한 변수)
    public bool isSpawning;     // 스폰을 하기 위한 변수, true면 스폰 되고, false면 스폰이 되지 않는다.
    private int spawnTracker;  // 어떤 장애물을 스폰할지 픽하기 위한 변수 ( 0 : 선인장1, 1: 선인장2, 2: 선인장3, 3 : 선인장4, 4 : 익룡 )

    public int mainScore;      // 실제로 게임 도중 1씩 더해질 int형 변수
    public TextMeshProUGUI mainScore_text;         // 게임 화면의 우측 상단의 ScoreText

    void Start()
    {
        spawnTimer = spawnDelay;
    }

    void Update()
    {
        if(isSpawning.Equals(true))  // true일 때 스폰 시작
        {
            spawnTimer -= Time.deltaTime;       // 딜레이 시간을 잰다

            if(spawnTimer < 0)      // 타이머의 값이 점점 빠져서 0보다 작게 되면
            {
                spawnTimer = spawnDelay;  // 다시 타이머의 시간을 스폰되는 시간으로 리셋

                spawnTracker = Random.Range(0, obstacles.Length); // 선인장일지, 익룡이 나올지 정한다

                if (spawnTracker.Equals(4))  // 4가 나와서 익룡이 걸렸다면
                {
                    int randPoint = 2 + Random.Range(0, 3);  // spawnPoints중에서 배열의 index번호가 2부터 익룡 포인트기 때문에 2를 더한다( Randmom.Range(0,3)하면 나올 수 있는 수는 0,1,2 중에 1개가 나온다)

                    Instantiate(obstacles[spawnTracker], spawnPoints[randPoint].position, spawnPoints[randPoint].rotation); // 정해진 포인트에서 생성 ( 포인트는 spawnPoints배열의 인덱스번호 2,3,4 중에 1개가 정해질 것이다)
                }
                else if(spawnTracker.Equals(0))
                {
                    Instantiate(obstacles[spawnTracker], spawnPoints[spawnTracker].position, spawnPoints[spawnTracker].rotation); // spawnPoints배열 중에 인덱스 번호 0번의 위치에서 생성
                }
                else
                {
                    Instantiate(obstacles[spawnTracker], spawnPoints[1].position, spawnPoints[1].rotation); // spawnPoints 배열의 인덱스 번호 1번의 위치에서 생성
                }
            }
        }
    }
}
