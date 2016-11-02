using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;
    private string computerSide;
    public bool playerMove = true;
    public float delay = 1;
    float timer = 0;
    private int value;
    private int moveCount = 0;
    private int computerMoveCount = 0;
    public GameObject endGameUI;
    public Text endGameText;
    public Text turnText;

    void Awake()
    {
        Screen.SetResolution(300, 360, false);
        SetGameManagerReferenceOnButtons();
        playerSide = "X";
        computerSide = "O";
    }

    void Update()
    {
        if(playerMove == false)
        {
            turnText.text = "[ Computer's Turn ]";
            turnText.color = new Color(0.9f, 0.6f, 0.6f);
            timer += delay * Time.deltaTime;
            if (timer >= delay)
            {
                GetComputerValue();

                if (buttonList[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                    timer = 0;
                    computerMoveCount++;
                }
            }
        }
        else
        {
            turnText.color = new Color(0.92f, 0.92f, 0.92f);
            turnText.text = "[ Your Turn ]";
        }            
    }

    void SetGameManagerReferenceOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameManagerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public string GetComputerSide()
    {
        return computerSide;
    }
    /*
    public void SetStartingSide(string startSide)
    {
        playerSide = startSide;
        if(playerSide == "X")
        {
            computerSide = "O";
        }
        else
        {
            computerSide = "X";
        }
    }
    */
    public void EndTurn()
    {
        bool hasAllBoxesdUsedUp = true;
        for (int i = 0; i < buttonList.Length; i++)
        {
            if (buttonList[i].GetComponentInParent<Button>().interactable)
                hasAllBoxesdUsedUp = false;
        }

        //Player
        //Horizontal
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver("player");
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver("player");
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver("player");
        }
        //Vertical
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver("player");
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver("player");
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver("player");
        }
        //Angled
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver("player");
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver("player");
        }

        //Computer
        //Horizontal
        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            GameOver("computer");
        }
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            GameOver("computer");
        }
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver("computer");
        }
        //Vertical
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver("computer");
        }
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            GameOver("computer");
        }
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver("computer");
        }
        //Angled
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver("computer");
        }
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver("computer");
        }
        else if (hasAllBoxesdUsedUp)
            GameOver("draw");

        moveCount++;
        ChangeSides();
    }

    void ChangeSides()
    {
        playerMove = (playerMove == true) ? false : true;
    }

    void GetComputerValue()
    {
        if(computerMoveCount == 0)
        {
            /*
            if (buttonList[8].text == playerSide && buttonList[0].GetComponentInParent<Button>().interactable)
                value = 0;
            else if (buttonList[6].text == playerSide && buttonList[2].GetComponentInParent<Button>().interactable)
                value = 2;
            else if (buttonList[2].text == playerSide && buttonList[6].GetComponentInParent<Button>().interactable)
                value = 6;
            else if (buttonList[0].text == playerSide && buttonList[8].GetComponentInParent<Button>().interactable)
                value = 8;
                */
            if (buttonList[4].GetComponentInParent<Button>().interactable)
                value = 4;
        }
        //If player picks corner during 2nd move
        else if (computerMoveCount == 1 && buttonList[4].text != playerSide &&
            (buttonList[0].text == playerSide || buttonList[2].text == playerSide || buttonList[6].text == playerSide || buttonList[8].text == playerSide)
            &&(buttonList[1].text != playerSide && buttonList[3].text != playerSide && buttonList[5].text != playerSide && buttonList[7].text != playerSide))
        {
            if (buttonList[0].text == playerSide && buttonList[2].text == playerSide && buttonList[1].GetComponentInParent<Button>().interactable)
                value = 1;
            else if (buttonList[0].text == playerSide && buttonList[6].text == playerSide && buttonList[3].GetComponentInParent<Button>().interactable)
                value = 3;
            else if (buttonList[0].text == playerSide && buttonList[8].text == playerSide)
                value = (Random.Range(0, 2) == 1) ? 1 : 3;
            else if (buttonList[2].text == playerSide && buttonList[6].text == playerSide)
                value = (Random.Range(0, 2) == 1) ? 5 : 7;
            else if (buttonList[2].text == playerSide && buttonList[8].text == playerSide && buttonList[5].GetComponentInParent<Button>().interactable)
                value = 5;
            else if (buttonList[6].text == playerSide && buttonList[8].text == playerSide && buttonList[7].GetComponentInParent<Button>().interactable)
                value = 7;
        }
        //Winning:
        //Top row
        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].GetComponentInParent<Button>().interactable)
        {
            value = 2;
        }
        else if (buttonList[0].text == computerSide && buttonList[1].GetComponentInParent<Button>().interactable && buttonList[2].text == computerSide)
        {
            value = 1;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            value = 0;
        }
        //Mid row
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].GetComponentInParent<Button>().interactable)
        {
            value = 5;
        }
        else if (buttonList[3].text == computerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[5].text == computerSide)
        {
            value = 4;
        }
        else if (buttonList[3].GetComponentInParent<Button>().interactable && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            value = 3;
        }
        //Bottom Row
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }
        else if (buttonList[6].text == computerSide && buttonList[7].GetComponentInParent<Button>().interactable && buttonList[8].text == computerSide)
        {
            value = 7;
        }
        else if (buttonList[6].GetComponentInParent<Button>().interactable && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            value = 6;
        }

        //Left Column
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].GetComponentInParent<Button>().interactable)
        {
            value = 6;
        }
        else if (buttonList[0].text == computerSide && buttonList[3].GetComponentInParent<Button>().interactable && buttonList[6].text == computerSide)
        {
            value = 3;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            value = 0;
        }
        //Mid Column
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].GetComponentInParent<Button>().interactable)
        {
            value = 7;
        }
        else if (buttonList[1].text == computerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[7].text == computerSide)
        {
            value = 4;
        }
        else if (buttonList[1].GetComponentInParent<Button>().interactable && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            value = 1;
        }
        //Right Column
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }
        else if (buttonList[2].text == computerSide && buttonList[5].GetComponentInParent<Button>().interactable && buttonList[8].text == computerSide)
        {
            value = 5;
        }
        else if (buttonList[2].GetComponentInParent<Button>().interactable && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            value = 2;
        }

        //Backwards Angle
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }
        else if (buttonList[0].text == computerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[8].text == computerSide)
        {
            value = 4;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            value = 0;
        }
        //Forwards Angle
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].GetComponentInParent<Button>().interactable)
        {
            value = 6;
        }
        else if (buttonList[2].text == computerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[6].text == computerSide)
        {
            value = 4;
        }
        else if (buttonList[2].GetComponentInParent<Button>().interactable && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            value = 2;
        }

        //Blocking:
        //Top row
        else if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].GetComponentInParent<Button>().interactable)
        {
            value = 2;
        }
        else if (buttonList[0].text == playerSide && buttonList[1].GetComponentInParent<Button>().interactable && buttonList[2].text == playerSide)
        {
            value = 1;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            value = 0;
        }
        //Mid row
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].GetComponentInParent<Button>().interactable)
        {
            value = 5;
        }
        else if (buttonList[3].text == playerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[5].text == playerSide)
        {
            value = 4;
        }
        else if (buttonList[3].GetComponentInParent<Button>().interactable && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            value = 3;
        }
        //Bottom Row
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }
        else if (buttonList[6].text == playerSide && buttonList[7].GetComponentInParent<Button>().interactable && buttonList[8].text == playerSide)
        {
            value = 7;
        }
        else if (buttonList[6].GetComponentInParent<Button>().interactable && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            value = 6;
        }

        //Left Column
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].GetComponentInParent<Button>().interactable)
        {
            value = 6;
        }
        else if (buttonList[0].text == playerSide && buttonList[3].GetComponentInParent<Button>().interactable && buttonList[6].text == playerSide)
        {
            value = 3;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            value = 0;
        }
        //Mid Column
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].GetComponentInParent<Button>().interactable)
        {
            value = 7;
        }
        else if (buttonList[1].text == playerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[7].text == playerSide)
        {
            value = 4;
        }
        else if (buttonList[1].GetComponentInParent<Button>().interactable && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            value = 1;
        }
        //Right Column
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }
        else if (buttonList[2].text == playerSide && buttonList[5].GetComponentInParent<Button>().interactable && buttonList[8].text == playerSide)
        {
            value = 5;
        }
        else if (buttonList[2].GetComponentInParent<Button>().interactable && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            value = 2;
        }

        //Backwards Angle
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].GetComponentInParent<Button>().interactable)
        {
            value = 8;
        }else if (buttonList[0].text == playerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[8].text == playerSide)
        {
            value = 4;
        }
        else if (buttonList[0].GetComponentInParent<Button>().interactable && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            value = 0;
        }
        //Forwards Angle
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].GetComponentInParent<Button>().interactable)
        {
            value = 6;
        }
        else if (buttonList[2].text == playerSide && buttonList[4].GetComponentInParent<Button>().interactable && buttonList[6].text == playerSide)
        {
            value = 4;
        }else if (buttonList[2].GetComponentInParent<Button>().interactable && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            Debug.Log("done");
            value = 2;
        }

        //if nothing of the above executes, pick corner or random the value:
        else
        {
            if (buttonList[0].GetComponentInParent<Button>().interactable)
                value = 0;
            else if (buttonList[2].GetComponentInParent<Button>().interactable)
                value = 2;
            else if (buttonList[6].GetComponentInParent<Button>().interactable)
                value = 6;
            else if (buttonList[8].GetComponentInParent<Button>().interactable)
                value = 8;
            else
                value = Random.Range(0, buttonList.Length);
            Debug.Log("else pick corner or random");
        }
            
    }

    void GameOver(string winner)
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        StartCoroutine(GameOver2(winner));
    }

    IEnumerator GameOver2(string winner)
    {
        yield return new WaitForSeconds(0.5f);
        endGameUI.SetActive(true);
        if (winner.Equals("player"))
            endGameText.text = "YOU WIN!";
        else if (winner.Equals("computer"))
            endGameText.text = "YOU LOST!";
        else
            endGameText.text = "WOW! DRAW!";
    }

}
