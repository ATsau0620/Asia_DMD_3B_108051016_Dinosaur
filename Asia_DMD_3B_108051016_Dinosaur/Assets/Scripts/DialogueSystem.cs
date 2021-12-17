
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/// <summary>
/// 對話系統
/// 將需要輸出的文字利用打字效果呈現
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("畫布對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("完成對話圖示")]
    public GameObject goTip;
    [Header("對話按鍵")]
    public KeyCode keyDialogue = KeyCode.Mouse0;

    private void Start()
    {
        //StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect(string[] contents)
    {
        //更換名稱快捷鍵 ctrl+ R R 
        //測試用
        //string test1 = "哈囉，你好~";
        //string test2 = "第二段對話~";
        //string[] contents = { test1, test2 }; 

        goDialogue.SetActive(true);       //顯示對話物件

        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";            //清除上次對話內容 
            goTip.SetActive(false);
            
            for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]);
                textContent.text += contents[j][i];  //疊加對話內容的文字
                yield return new WaitForSeconds(interval);
            }

            goTip.SetActive(true);

            while(!Input.GetKeyDown(keyDialogue))
            {
                yield return null; 
            }
        }

        goDialogue.SetActive(false);
    }

}
