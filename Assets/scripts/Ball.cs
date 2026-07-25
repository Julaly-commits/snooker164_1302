using UnityEngine;
using UnityEngine.EventSystems;
public enum Ballcolor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;

    [SerializeField]
    private Ballcolor color;

    [SerializeField]
    private MeshRenderer rd;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);

    }

    void Awake()
    {
        rd = GetComponent<MeshRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetcolorAndPoint(Ballcolor col)
    {
        switch (col)
        {
            case Ballcolor.White:
                point = 0;
                rd.material.color = Color.white;
                break;

            case Ballcolor.Red:
                point = 1;
                rd.material.color = Color.red;
                break;

            case Ballcolor.Yellow:
                point = 2; 
                rd.material.color = Color.yellow;
                break;

            case Ballcolor.Green:
                point = 3;
                rd.material.color = Color.green;
                break;

            case Ballcolor.Brown:
                point = 4;
                rd.material.color = Color.brown;
                break;

            case Ballcolor.Blue:
                point = 5;
                rd.material.color = Color.blue;
                break;

            case Ballcolor.Pink: 
                point = 6;
                rd.material.color = Color.pink;
                break;

            case Ballcolor.Black:
                point = 7;
                rd.material.color = Color.black;
                break;

        }
}
