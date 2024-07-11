using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10f;


    bool _moveToDest = false;
    Vector3 _destPos;

    UI_Button uiPopup;
    //float wait_run_ratio = 0;

    void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Managers.UI.ClosePopupUI(uiPopup);
        }
        for(int i = 0; i < 5; i++)
        {
            Managers.UI.ShowPopupUI<UI_Button>();
        }
        uiPopup = Managers.UI.ShowPopupUI<UI_Button>();
    }
    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }

    PlayerState _state = PlayerState.Idle;


    void Update()
    {
        switch (_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Idle:
                UpdateIdle();
                break;
        }

    void UpdateDie()
        {
            //�ƹ��͵� ���ϰ�
        }
    void UpdateMoving()
        {
            if (_moveToDest)
            {
                Vector3 dir = _destPos - transform.position;//����
                if (dir.magnitude < 0.0001f)//�Ÿ� distance
                {
                    _moveToDest = false;
                }
                else
                {
                    float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

                    
                    transform.position += dir.normalized * moveDist;
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
                }
                Animator anim = GetComponent<Animator>();
                anim.SetFloat("speed", _speed);
            }
        }
    void UpdateIdle()
        {
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("speed", 0);
        }
        //if (_moveToDest)
        //{
        //    wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10f * Time.deltaTime);
        //    Animator anim = GetComponent<Animator>();
        //    anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //    anim.Play("RUN");
        //}
        //else
        //{
        //    wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10f * Time.deltaTime);
        //    Animator anim = GetComponent<Animator>();
        //    anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //    anim.Play("WAIT");
        //}
    }
void OnKeyboard()
    {
        //��,��, ��,�� �̵�
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            // == ����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);

            //������ ���������� �����θ� �����ߴµ�..
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);

            //Ʈ��������Ʈ(������ǥ)�� ���������� �ٲ���
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            // == ����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);

            //transform.Translate(Vector3.back * Time.deltaTime * _speed);

            //Ʈ���� ����Ʈ(������ǥ)�� ���������� �ٲ���
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            // == ����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);

            //transform.Translate(Vector3.left *Time.deltaTime * _speed);

            //Ʈ���� ����Ʈ(������ǥ)�� ���������� �ٲ���
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            // == ����
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);

            //transform.Translate(Vector3.right * Time.deltaTime * _speed);

            //Ʈ���� ����Ʈ(������ǥ)�� ���������� �ٲ���
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        _moveToDest = false;//Ŭ�� ������� �̵� �Ұ�
    }


    void OnMouseClicked(Define.MouseEvent evt)
    {
        //Press�ϰ��� �۵� �ȵǰԲ�(�׳� �ӽ÷� ó���� �� �ְ�..)
        //������ ����� ����ϰ� �ʹٸ� ����
        if (evt != Define.MouseEvent.Click)
            return;
        if (_state == PlayerState.Die)
            return;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1f);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Ground")))
        {
            _destPos = hit.point;//Ŭ���� ������ �������� ����
            _state = PlayerState.Moving;
            _moveToDest = true; //Ŭ�� ������� �̵� ���� �ϰ�.
        }

    }

}
