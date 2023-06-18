using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienText : MonoBehaviour
{
    public GameController gameController;
    private TMP_Text alienTextCount;
    void Start()
    {
        alienTextCount = GetComponent<TMP_Text>();
        UpdateAlienCountDisplay();
    }
    private void Update()
    {
        UpdateAlienCountDisplay();
    }

    private void UpdateAlienCountDisplay()
    {
        alienTextCount.text = "" + (gameController.GetTotalMaxEnemyCount() - gameController.GetTotalDefeatEnemy());
    }
}
