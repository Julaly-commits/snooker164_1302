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

    [SerializeField]
    private GameObject BallLine;

    [SerializeField]
    private GameObject cam;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraBehindCueBall();
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
            xInput = 0.1f;

        else 
            xInput = 0f;

        if(Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();
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

        BallLine.SetActive(false);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f , 30f , -42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);

    }

    private void RotateBall()
    {
        if(cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f , xInput , 0f));
    }

    private void StopBall()
    {
       Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = Vector3.zero;

        BallLine.SetActive(true);
        CameraBehindCueBall();

    }
    private void CameraBehindCueBall()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f , 7f , -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }
}
