using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerSide;

    private GameManager gameManager;

	public void SetSpace()
    {
        if(gameManager.playerMove == true)
        {
            buttonText.text = gameManager.GetPlayerSide();
            button.interactable = false;
            gameManager.EndTurn();
        }
    }

    public void SetGameManagerReference(GameManager manager)
    {
        gameManager = manager;
    }

}
