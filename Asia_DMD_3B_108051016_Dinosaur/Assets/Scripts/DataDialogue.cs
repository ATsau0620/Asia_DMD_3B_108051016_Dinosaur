using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//建立專案內的選單(menuName = "選單名稱") 資料夾/子資料
[CreateAssetMenu( menuName = "ATSAU/對話資料")]
/// <summary>
/// 對話資料
/// 保存NPC跟玩家的對話資料
/// </summary>
/// Scriptable Object 腳本化物件:將程式資料化儲存至 Project 內的物件 
public class DataDialogue : ScriptableObject
{
    //TextAres (最小行數, 最大行數) - 僅限 string
    [Header("對話內容"), TextArea(3, 5)]
    public string[] dialogues;
}
