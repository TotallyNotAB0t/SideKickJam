using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    [Serializable]
    public class questJson
    {
        public string[] earlyfood;
        public string[] earlymoney;
        public string[] earlylooks;
        public string[] earlyreputation;
        public string[] midfood;
        public string[] midmoney;
        public string[] midlooks;
        public string[] midreputation;
        public string[] latefood;
        public string[] latemoney;
        public string[] latelooks;
        public string[] latereputation;
    }

    public TextAsset textJSON;
    [Serializable]
    public class Player
    {
        public string name;
        public int health;
        public int mana;
    }
    
    [Serializable]
    public class PlayerList
    {
        public Player[] player;
    }

    public PlayerList myPlayerList = new PlayerList();

    private void Start()
    {
        myPlayerList = JsonUtility.FromJson<PlayerList>(textJSON.text);
    }
}
