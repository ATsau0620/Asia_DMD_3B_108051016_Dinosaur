
using UnityEngine;
using System.Collections;  //引用、系統、集合 包含協同程序

public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());           //啟動協同程序(協同程序))
        StartCoroutine(TestWithLoop());
    }

    // 定義協同程序
    // 傳回類型 IEnumerator 
    private IEnumerator Test()
    {
        print("這是第一段文字訊息~");
        yield return new WaitForSeconds(1);
        print("這是第二段文字訊息~");
        yield return new WaitForSeconds(3);
        print("又等了三秒鐘..."); 
    }

    private IEnumerator TestWithLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            print("數字:" + i);
            yield return new WaitForSeconds(0.5f); 

        }
    }

}
