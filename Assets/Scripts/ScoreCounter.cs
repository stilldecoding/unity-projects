using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] PlayerMovement playerscript;
    [SerializeField] GameObject player;
    PlayerMovement script;
    TextMeshProUGUI mytextmeshpro;
    void Start()
    {

        script = player.GetComponent<PlayerMovement>();
        mytextmeshpro = GetComponent<TextMeshProUGUI>();
        mytextmeshpro.text = "= 0";
    }

    void Update()
    {
        changeScore();
    }

    void changeScore()
    {
        int score = playerscript.GetCoinCount();
        mytextmeshpro.text = "= " + score.ToString();
    }
}
