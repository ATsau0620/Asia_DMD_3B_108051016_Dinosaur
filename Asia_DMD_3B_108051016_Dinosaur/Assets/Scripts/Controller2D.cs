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
    [Header("檢查地板尺寸與位移")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    [Header("動畫參數 : 走路與跳躍")]
    public string parameterWalk = "開關走路";
    public string paramterJump = "開關跳躍";

    #endregion

    #region  欄位:私人
    private Animator ani;
    /// <summary>
    /// 鋼體元件 Rigidbody 2D
    /// </summary>
    private Rigidbody2D rig;

    //將私人欄位顯示在屬性版上
    [SerializeField]


    private bool isGround;
    #endregion

    #region 事件
    /// <summary>
    /// 繪製圖示
    /// 在 Unity 繪製輔助用的圖示
    /// 線條、射線、圖形、圖形、方形、扇形、圖片
    /// 圖示 Gizmos 類別
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1.決定圖示顏色
        Gizmos.color = new Color(1, 0, 0.2f, 0.3f);
        // 2.決定繪製圖形
        // transform.position 此物件的世界座標
        Gizmos.DrawSphere(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius);
    }
    private void Start()
    {
        //鋼體欄位 = 取得元件<2D 鋼體>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
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

    private void Update()
    {
        Flip();
        CheckGround();
        Jamp();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 1.玩家是否有按移動按鍵 左右方向間或A、D
    /// 2.物件移動行為(API)
    /// </summary>
    private void Move()
    {
        // h 值 =指定為 輸入軸向(水平軸) - 水平軸代表左右鍵與AD      
        float h = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值:" + h);

        //剛體元件.加速度 = 新 二維向量(h 值 * 移動速度, 0);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        //
        ani.SetBool(parameterWalk, h != 0);
    
    }

    /// <summary>
    /// 翻面
    /// h 值 小於0 : 角度 Y 180
    /// h 值 大於0 : 角度 Y 0
    /// </summary>
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        //如果 h 值小於0 左 : 角度 Y 180
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        //如果 h  值大於0 右 : 角度 Y 0
        else if (h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }

    }

    /// <summary>
    /// 檢查是否在地板
    /// </summary>
    private void CheckGround()
    {
        //碰撞資訊 = 2D 物理,覆蓋圖層(中心點,半徑,圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
            transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);

        // print("碰到的物件名稱:" + hit.name);

        isGround = hit;

        ani.SetBool(paramterJump, !isGround);

    }
    private void Jamp()
    {
        //如果角色在地板上 並且 按下指定按鍵
        if (isGround && Input.GetKeyDown(keyjump))
        {
            //剛體,添加推力(二維向量)
            rig.AddForce(new Vector2(0, jump));    
        }

     }
    #endregion




}

