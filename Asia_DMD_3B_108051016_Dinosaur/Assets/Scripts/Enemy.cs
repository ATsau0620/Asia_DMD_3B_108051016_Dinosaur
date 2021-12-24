using UnityEngine;


public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;

    #endregion

    #region 事件


    private void OnDrawGizmos()
    {
        //指定圖示顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //繪製立方體(中心、尺寸)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);
    }

    private void Update()
    {
        CheckTaragetInArea();
    }

    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    private void CheckTaragetInArea() 
    {
        //2D 物理.覆蓋盒型(中心，尺寸，角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);
    }

    #endregion

}
