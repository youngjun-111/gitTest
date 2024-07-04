using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    GameObject prefab;
    GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        //prefab = Resources.Load<GameObject>("prefabs/Cube");
        //cube = Instantiate(prefab);

        cube = Managers.resource.Instantiate("Cube");

        Destroy(cube, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
