using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;

    //Ÿ��(�÷��̾�) ���� ������ �Ÿ�
    [SerializeField]
    Vector3 _delta = new Vector3(0f, 6f, -5f);
    //Ÿ��
    [SerializeField]
    GameObject _player = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //������Ʈ���� �ʰ� ����
    private void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            //�÷��̾�� ī�޶� �������� ���̸� �߻�(�÷��̾���ġ, ī�޶���ġ, out hit,����, �浹 ������ ���̾�)
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;//�Ÿ��� 0.8�� ���ؼ� �ٿ���
                transform.position = _player.transform.position + _delta.normalized * dist;//ī�޶��� ��ġ ����
            }else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);
            }
        }
    }
    //���߿� ���ͺ並 �ڵ�� �����ϰ� �ʹٸ� �̷������� �Լ��� ����� �ȴ�.
    //(������ �����ϵ���, �Ǵ� VR���� �̵� ��� �����ϵ��� ó���ϸ� �ȴ�.)
    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }

    //ī�޶��� �þ߰� ���ܵǾ��� ��� ��߸� Ȯ�� �Ҽ� �ְ�

    void Update()
    {
        
    }
}
