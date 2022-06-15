using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public bool isDraw;

    private void OnEnable()
    {
        if (GameManager.GM == null)
            GameManager.GM = this; 
    }

}
