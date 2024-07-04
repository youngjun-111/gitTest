using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //����
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/ {path}");//��θ� �������ָ� ���������� ��밡����

        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //Object�� ������ ������ ����Ϸ��� �ҰŶ�
        return Object.Instantiate(prefab, parent);
    }

    //�����غ����� �� �����δ� �ʿ����.
    public void Destroy(GameObject go)
    {
        if(go == null)
        {
            return;

            Object.Destroy(go);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
