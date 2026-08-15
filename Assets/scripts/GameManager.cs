using UnityEngine;
using System;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPosition;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

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
        RotateBall();

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0f;
    }

 

    private void SetBall(Ballcolor col, int i)
    {
      GameObject obj = Instantiate(ballPrefab, ballPosition[i].transform.position, Quaternion.identity);

        Ball b =obj.GetComponent<Ball>();
        b.SetcolorAndPoint(col);

    }

    private void ShootBall()
    {
        Rigidbody rd =cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
    }

    private void RotateBall()
    {
        if(cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f , xInput , 0f));
    }
}
