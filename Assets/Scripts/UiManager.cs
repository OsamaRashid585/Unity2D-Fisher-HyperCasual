using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static int _playerKillScore;
    public TextMeshProUGUI _plaerKillScoreTXT;
    public Slider SpeedBooster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpeedBooster.value = Player._speedBoostValue;
        _plaerKillScoreTXT.text = _playerKillScore.ToString();
    }
}
