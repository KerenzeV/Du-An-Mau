using Assets.Khoa.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject InfoCanvas;
    [SerializeField] GameObject fisnishCanvas;

    private StorageHelper StorageHelper;
    private GameDataPlayedSC2 played;

    private void Start()
    {
        StorageHelper = new StorageHelper();
        StorageHelper.LoadDataSC2();
        played = StorageHelper.played;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InfoCanvas.SetActive(false);
            var score = FindObjectOfType<UIbyKhoa>().GetScore();
            //luu thanh tich nguoi choi 
            var gamedata = new GameDataSC2()
            {
                score = score,
                timePlayed = DateTime.Now.ToString("yyyy-MM-dd")
                
            }; 
            played.plays.Add(gamedata);
            StorageHelper.SaveDataSC2();

            //tai du lieu trong file hien thi len bang thanh tich
            fisnishCanvas.SetActive(true);
        }
    }
}
