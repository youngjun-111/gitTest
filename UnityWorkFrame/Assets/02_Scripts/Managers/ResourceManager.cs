using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    //랩핑
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/ {path}");//경로만 지정해주면 범용적으로 사용가능함

        if(prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //Object를 붙이지 않으면 재귀하려고 할거라서
        return Object.Instantiate(prefab, parent);
    }

    //랩핑해본것일 뿐 실제로는 필요없다.
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
