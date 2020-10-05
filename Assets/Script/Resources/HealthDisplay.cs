using RPG.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Health health;
    private void Awake()
    {
        health = GameObject.FindWithTag("Player").GetComponent<Health>();
    }
    void Update()
    {
        GetComponent<Text>().text = string.Format("{0:0}%", health.GetPercentage());
    }
}
