
using UnityEngine;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    [Header("對話間隔"), Range(0, 1)]
    public float interval = 0.3f;

    private void Start()
    {
        StartCoroutine(TypeEffect());
    }
    private IEnumerator TypeEffect()
    {
        string test = "哈囉，你好~";

        for (int i = 0; i < test.Length; i++) 
        {
            print(test[i]);
            yield return new WaitForSeconds(interval);
        }

    }

}
