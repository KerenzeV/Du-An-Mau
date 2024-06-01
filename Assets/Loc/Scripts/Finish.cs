using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Loc.Scripts;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject informationCanvas;
    [SerializeField] GameObject finishCanvas;
    [SerializeField] GameObject row;

    private StorageHelper storgeHelper;
    private GameDataPlayed played;



    private void Start()
    {
        storgeHelper = new StorageHelper();
        storgeHelper.LoadData();
        played = storgeHelper.played;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            informationCanvas.SetActive(false);
            var score = FindObjectOfType<GameController>(gameObject).GetScore();
            // Save Info Player

            var gameData = new GameData()
            {
                score = score,
                timePlayed = DateTime.Now.ToString("yyyy-MM-dd")
            };
            played.plays.Add(gameData);
            storgeHelper.SaveData();

            // Download Info Upload ScoreBoard
            storgeHelper.LoadData();
            played = storgeHelper.played;
            Debug.Log("Count: "+ played.plays.Count);

            // Show top 5 -> Short 

            played.plays.Sort((x, y) => y.score.CompareTo(x.score));
            var plays = played.plays.GetRange(0,Math.Min(5,played.plays.Count));    


            //Show ScoreBoard
            for (int i = 0; i < plays.Count; i++)
            {
                var rowInstance = Instantiate(row,row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i+1).ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].score.ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = plays[i].timePlayed;
                rowInstance.SetActive(true);
            }


            // End Show
            finishCanvas.SetActive(true);
        }
    }
}
