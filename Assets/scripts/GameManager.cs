using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(Ballcolor.Red, 1);
        SetBall(Ballcolor.Yellow, 2);
        SetBall(Ballcolor.Green, 3);
        SetBall(Ballcolor.Brown, 4);
        SetBall(Ballcolor.Blue, 5);
        SetBall(Ballcolor.Pink, 6);
        SetBall(Ballcolor.Black, 7);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void SetBall(Ballcolor col, int i)
    {
      GameObject obj = Instantiate(ballPrefab, ballPosition[i].transform.position, Quaternion.identity);

        Ball b =obj.GetComponent<Ball>();
        b.SetcolorAndPoint(col);

    }
}
