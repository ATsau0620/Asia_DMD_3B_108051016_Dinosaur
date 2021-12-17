using UnityEngine;

/// <summary>
/// NPC 行為
/// 偵測目標進入碰撞區
/// 顯示對話系統
/// </summary>
public class NPC : MonoBehaviour
{
    [Header("對話資料")]
    public DataDialogue dataDialogue;
    [Header("對話系統")]
    public DialogueSystem dialogueSystem;

}
