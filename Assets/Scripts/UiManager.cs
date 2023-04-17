using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UiManager : MonoBehaviour
{
  
    public Block[] Blocks;
    public JBlock[] Jblocks;
    public JBlock[] ReturnBlocks;


    void Awake()
    {
        string filePath = "Assets/Files/Data.txt";
        StreamReader reader = new StreamReader(filePath);
        string Jdata = reader.ReadToEnd();
        reader.Close();
        ReturnBlocks = new JBlock[Blocks.Length];
        ReturnBlocks = JsonHelper.FromJson<JBlock>(Jdata);
       

     for(int i = 0; i < Blocks.Length; i++)
        {
            JBlock jb = ReturnBlocks[i];
            Blocks[i].row = jb.row;
            Blocks[i].col = jb.col;
            Blocks[i].isVisible = jb.isVisible;
            Debug.Log(jb.isVisible);
        }
    }


    public void OnSave()
    {
        // Allocating memory for array
        Jblocks = new JBlock[Blocks.Length];

        // Creating Serializable Objects
        for (int i =0; i < Blocks.Length; i++)
        {
           
            Block b = Blocks[i];
            JBlock jb = new JBlock(b.row, b.col, b.isVisible);
            Jblocks[i] = jb;
        }
        // Conversion to Json
        string Jdata = JsonHelper.ToJson(Jblocks);

        // File Creation and Writing to file
        string filePath = "Assets/Files/Data.txt";
        StreamWriter writer = new StreamWriter(filePath, false);
        writer.Write(Jdata);
        writer.Close();
        
    }
}
[System.Serializable]
public class JBlock
{
    public int row;
    public int col;
    public bool isVisible;

    public JBlock(int row, int col, bool isVisible)
    {
        this.row = row;
        this.col = col;
        this.isVisible = isVisible;
    }
}