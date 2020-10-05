using RPG.Combat;
using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour
{
    Fighter fighter;
    private void Awake()
    {
        fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
    }
    void Update()
    {
        if (fighter.GetTarget() == null) {

            GetComponent<Text>().text = "N/A";
            return;
        }
        Health health = fighter.GetTarget();
        GetComponent<Text>().text = string.Format("{0:0}%", health.GetPercentage());
    }
}
