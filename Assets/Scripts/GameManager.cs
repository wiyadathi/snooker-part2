using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int playerScore;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] ballPositions;

    [SerializeField] private GameObject cueBall;
    [SerializeField] private GameObject ballLine;

    [SerializeField] private float xInput;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        //set balls on the table
        SetBalls(BallColors.White, 0);
        SetBalls(BallColors.Red, 1);
        SetBalls(BallColors.Yellow, 2);
        SetBalls(BallColors.Green, 3);
        SetBalls(BallColors.Brown, 4);
        SetBalls(BallColors.Blue, 5);
        SetBalls(BallColors.Pink, 6);
        SetBalls(BallColors.Black, 7);
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();
    }

    void SetBalls(BallColors color, int pos)
    {
        GameObject ball = Instantiate(ballPrefab, 
                                    ballPositions[pos].transform.position, 
                                    Quaternion.identity);
        Ball b = ball.GetComponent<Ball>();
        b.SetColorAndPoint(color);
    }

    void RotateBall()
    {
        xInput = Input.GetAxis("Horizontal");
        cueBall.transform.Rotate(new Vector3(0f,xInput/10, 0f));
    }
}
