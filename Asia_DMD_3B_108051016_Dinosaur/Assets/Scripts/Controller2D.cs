using UnityEngine;

/// <summary>
/// 控制器:2D橫向卷軸版本
/// </summary>
public class Controller2D : MonoBehaviour
{
   

    #region 欄位:公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;
    #endregion


    /// <summary>
    /// 鋼體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    private void Start()
    {
        //鋼體欄位 = 取得元件<2D 鋼體>()
        rig = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// Update 約 60 FPS
    /// 固定更新事件:50 FPS
    /// 處理物理行為
    /// </summary>
    private void FixedUpdate()
    {
        Move();
    }
    #region 方法
    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向間或A、D
    /// 2.物件移動行為(API)
    /// </summary>
    private void Move()
    {
        // h 值 =指定為 輸入軸向(水平軸) - 水平軸代表左右鍵與AD      
        float h = Input.GetAxis("Horizontal");
        print("玩家左右按鍵值:" + h);
    }

    #endregion




}

