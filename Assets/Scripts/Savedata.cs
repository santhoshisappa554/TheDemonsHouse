using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Savedata : MonoBehaviour
{
    public string GameName;
    public string PlayerName;
    public string Gender;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetData()
    {
        BinaryFormatter binaryFormater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Details.file";
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        /*bw.Write("Game Name: " + GameName);
        print("\n");
        bw.Write("Player Name : " + PlayerName);
        bw.Write("Player Gender : " + Gender);*/
        binaryFormater.Serialize(fs, "Game Name: " + GameName);
        binaryFormater.Serialize(fs, "Player Name : " + PlayerName);
        binaryFormater.Serialize(fs, "Player Gender : " + Gender);



        bw.Close();
        fs.Close();
    }
    public void GetData()
    {
        BinaryFormatter binaryFormater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Details.file";
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        //br.ReadString();
        binaryFormater.Deserialize(fs);
        br.Close();
        fs.Close();
    }
}