using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionPanel : MonoBehaviour
{
    public ActionLogic actionLogic;
    public GameHandler gameHandler;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private void Awake()
    {

    }
    // Start is called before the  first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void button4Click()
    {
        Debug.Log("Button 4 Clicked in PAP");
        this.gameHandler.playerEndTurn();
    }
}
