using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;

    //��ǥ�� �Է��� üũ�� ������ ������ �Է��� ������ �װ��� �̺�Ʈ�� ���ĸ� ���ִ� �������� ����(������ ����)
    //�̷��� �ϸ� �÷��̾� ��Ʈ�ѷ��� 100���� �ǵ� 1000���� �ǵ� �� �������� �ѹ����� üũ�ذ����� �� �̺�Ʈ�� �����ϴ¹������ ���� �� ����.
    //�̷��� �����ϸ� �� ���� ���� ��� Ű���� �Է��� �޾Ҵ��� ã�Ⱑ ����� ������ �ؼҵȴ�.

    public void OnUpdate()
    {
        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();
        if(MouseAction != null)
        {
            //�������� ���
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }else //Ŭ���� ��� (���࿡ �ѹ��̶� �������� ������ click �̶�� �̺�Ʈ �߻�)
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }


        //�̰� ������ ������? ������? ������? ������? �� �ƴ϶� �� �ȴ������� ��� �����ϰ� �ִٰ� ������ �� ������! �ϴ°�
        //�ȴ����� ���������� ���������� ���� ������
        //if (Input.anyKey == false)
        //    return;

        ////�۵� ����ϻ�
        //if (KeyAction != null)
        //    KeyAction.Invoke();

        //�ϳ��� Form�� �ٸ� thread���� �����ϰ� �� ��쿡 ������ Form�� �浹�� �� �� �ִ�.
        //�� �� invoke�� ����Ͽ� �����Ϸ��� �ϴ� �޼ҵ��� �븮��(delegate)�� �����Ű�� �ȴ�.

    }
}
