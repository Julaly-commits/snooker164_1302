using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameManager[] ballPosition;

    [SerializeField]
    private GameManager ballPrefad;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(Ballcolor.Red, 1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void SetBall(Ballcolor col, int i)
    {
      GameObject obj = Instantiate(ballPrefad, ballPosition[i].transform.position, Quaternion.identity);

        Ball b =obj.GetComponent<Ball>();
        b.SetcolorAndPoint(col);

    }
}
