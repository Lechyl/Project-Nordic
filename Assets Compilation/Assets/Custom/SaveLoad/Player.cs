using System.Collections;
using System.Collection.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int level; 
    public int health;

    public void SavePlayer () {
        
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer () {
        
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}