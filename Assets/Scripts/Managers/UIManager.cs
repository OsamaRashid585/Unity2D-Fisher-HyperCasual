using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Slider SpeedBooster;
    public static int _playerKillScore;
    public TextMeshProUGUI _playerKillScoreTXT;

    public TextMeshProUGUI _playerKillScoreTXTL;

    public static int YellowFishAIScore;
    public TextMeshProUGUI YellowFishAIScoreTXT;

    public static int GreenFishAIScore;
    public TextMeshProUGUI GreenFishAIScoreTXT;

    public static int DarkGreenFishAIScore;
    public TextMeshProUGUI DarkGreenFishAIScoreTXT;

    public static int GrayFishAIScore;
    public TextMeshProUGUI GrayFishAIScoreTXT;


    //GameOver screen leaderbord

    public TextMeshProUGUI _playerKillScoreTXTEND;
    public TextMeshProUGUI YellowFishAIScoreTXTEND;
    public TextMeshProUGUI GreenFishAIScoreTXTEND;
    public TextMeshProUGUI DarkGreenFishAIScoreTXTEND;
    public TextMeshProUGUI GrayFishAIScoreTXTEND;

    private void Awake()
    {
        _playerKillScore = 0;
        YellowFishAIScore = 0;
        GreenFishAIScore = 0;
        DarkGreenFishAIScore = 0;
        GrayFishAIScore = 0;
    }
    void Update()
    {
        SpeedBooster.value = Player._speedBoostValue;

        UpDateOnScreenLeaderBoard();
        UpDateGameOverLeaderBoard();
    }

    private void UpDateOnScreenLeaderBoard()
    {
        _playerKillScoreTXT.text = _playerKillScore.ToString();

        //lederBoard
        _playerKillScoreTXTL.text = "Player            " + _playerKillScore.ToString();
        YellowFishAIScoreTXT.text = "Yellow            " + YellowFishAIScore.ToString();
        GreenFishAIScoreTXT.text = "Green            " + GreenFishAIScore.ToString();
        DarkGreenFishAIScoreTXT.text = "Dark Green     " + DarkGreenFishAIScore.ToString();
        GrayFishAIScoreTXT.text = "Gray                 " + GrayFishAIScore.ToString();
    }

    private void UpDateGameOverLeaderBoard()
    {
        //GameOver screen leaderbord
        _playerKillScoreTXTEND.text = _playerKillScore.ToString();
        YellowFishAIScoreTXTEND.text = YellowFishAIScore.ToString();
        GreenFishAIScoreTXTEND.text = GreenFishAIScore.ToString();
        DarkGreenFishAIScoreTXTEND.text = DarkGreenFishAIScore.ToString();
        GrayFishAIScoreTXTEND.text = GrayFishAIScore.ToString();
    }
}
