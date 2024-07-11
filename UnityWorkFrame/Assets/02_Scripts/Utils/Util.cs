using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Util
{
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
                            // T FindChild<T>
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    // �ֻ��� �θ�, �̸��� ������ �ʰ� �� Ÿ�Կ��� �ش��ϸ� ���� ( ���۳�Ʈ �̸� ),
    // ��������� ���, �ڽĸ� ã������ �ڽ��� �ڽĵ� ã�� ����
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false)
        where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false) // ���� �ڽĸ�
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else    // �ڽ��� �ڽı���
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {   // �̸��� ����ְų� ���� ã������ �̸��� ���ٸ�
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    // ���ӿ�����Ʈ(go)�� �ش� ������Ʈ�� ������ T ������Ʈ �߰�
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }

        return component;
    }
}
