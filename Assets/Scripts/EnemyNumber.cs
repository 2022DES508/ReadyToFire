using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyNumber : MonoBehaviour
{
    private Text enemyNumText;

    private void Start()
    {
        enemyNumText = GetComponent<Text>(); 
    }

    private void Update()
    {
        enemyNumText.text = GameManager.GM.enemyCounter.ToString(); 
    }
}
