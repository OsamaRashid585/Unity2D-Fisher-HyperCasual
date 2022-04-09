using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    #region SINGOLTON
    private static UpgradeManager _instance;
    public static UpgradeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UpgradeManager>();
            }

            return _instance;
        }
    }
    #endregion

    public GameObject[] Heads;
    public GameObject[] Tooths;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
