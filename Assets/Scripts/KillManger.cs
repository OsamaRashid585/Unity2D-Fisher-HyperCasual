using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManger : MonoBehaviour
{
    #region
    private static KillManger _instance;
    public  static KillManger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<KillManger>();
            }

            return _instance;
        }
    }
    #endregion
    public GameObject[] heads;
    public GameObject[] Tooths;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
