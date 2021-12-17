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
    [Header("觸發對話的對象")]
    public string target = "小恐龍";

    //觸發開始事件
    // 1.兩個物件都要有Collider 2D
    // 2.兩個物件要有一個有 Rigibody 2D
    // 3.兩個物件要有一個勾 Is Trigger 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialogueSystem.StartDialogue(dataDialogue.dialogues);

        }
     }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialogueSystem.StopDialogue();
        }
       

    }
}
