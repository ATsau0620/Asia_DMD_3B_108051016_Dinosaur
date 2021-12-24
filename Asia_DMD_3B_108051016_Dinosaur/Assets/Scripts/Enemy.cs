using UnityEngine;


public class Enemy : MonoBehaviour
{
    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("���ʳt��")]
    public float speed = 1.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;

    #endregion

    #region �ƥ�


    private void OnDrawGizmos()
    {
        //���w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //ø�s�ߤ���(���ߡB�ؤo)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);
    }

    private void Update()
    {
        CheckTaragetInArea();
    }

    #endregion

    #region ��k
    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺
    /// </summary>
    private void CheckTaragetInArea() 
    {
        //2D ���z.�л\����(���ߡA�ؤo�A����)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit) print(hit.name);
    }

    #endregion

}
