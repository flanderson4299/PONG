using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private int playerScore;
    private int opponentScore;
    public Text playerText;
    public Text opponentText;
    public Ball ball;

    public Text results;
    public GameObject resultScreen;
    //public GameObject ballObj;

    public int PlayerScore
    {
        get { return playerScore; }
        //set { playerScore = value; }
    }

    public int OpponentScore
    {
        get { return opponentScore; }
        //set { opponentScore = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        resultScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerText.text = playerScore.ToString();
        opponentText.text = opponentScore.ToString();

        if (ball.PlayerScored)
        {
            playerScore++;
            ball.Reset();
        }

        if (ball.OpponentScored)
        {
            opponentScore++;
            ball.Reset();
        }

        if (playerScore == 7)
        {
            results.text = "You Won! :)";
            resultScreen.SetActive(true);
        }
        else if(opponentScore == 7)
        {
            results.text = "You Lost! :(";
            resultScreen.SetActive(true);
        }
    }
}
