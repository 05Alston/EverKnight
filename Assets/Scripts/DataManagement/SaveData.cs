using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
    public static void SaveState(PlayerHealth playerHealth, PlayerAttack playerAttack, PlayerMovement playerMovement, AllyAttack allyAttack)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path =  Application.persistentDataPath + "/player.pog";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data data = new Data(playerHealth, playerAttack, playerMovement, allyAttack);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadState()
    {
        string path = Application.persistentDataPath + "/player.pog";

        if (!File.Exists(path))
            return null;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        Data data = formatter.Deserialize(stream) as Data;
        stream.Close();
        return data;
    }
}
