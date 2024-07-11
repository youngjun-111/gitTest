using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    int _order = 10;//Ȥ�� �𸣴ϱ� ������ �ΰ� ���� �����Ұ� �ִٸ� 10���� ���� ���� �˾��� �� �ְ� ��.
    //���� �������� ��� �˾��� ���� ���� ��������ϱ� ������
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject { name = "@UI_Root" };
            }

            return root;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //�˾� UI�� �������ִ� �Լ�(�Ű������� Ÿ���� �̸� �������� �ʰ�, ��� �� ����)
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        //T�� �ƹ� T�� �޴°� �ƴ϶� ������ UI�˾��� ��ӹ޴� �ַ� ������
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");//�˾� ����
        T popup = Util.GetOrAddComponent<T>(go);//���۳�Ʈ�� �پ����� �ʴٸ� �߰�
        _popupStack.Push(popup);
        //GameObject root = GameObject.Find("@UI_Root");
        //if(root == null)
        //{
        //    root = new GameObject { name = "@UI_Root" };
        //}
        go.transform.SetParent(Root.transform);

        return popup;
    }

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        //T�� �ƹ� T�� �޴°� �ƴ϶� ������ UI�˾��� ��ӹ޴� �ַ� ������
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;
        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");//�˾� ����
        T sceneUI = Util.GetOrAddComponent<T>(go);//���۳�Ʈ�� �پ����� �ʴٸ� �߰�
        _sceneUI = sceneUI;
        //GameObject root = GameObject.Find("@UI_Root");
        //if (root == null)
        //{
        //    root = new GameObject { name = "@UI_Root" };
        //}
        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)//Stack�� �ƹ��͵� ������ �׳� ����
            return;
        
        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }
    public void ClosePopupUI(UI_Popup popup)//�����Ұ��� ������ �� ������ ���� �����ϰ� ������ �� �ִ�.
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }
        ClosePopupUI();
    }
    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        //ĵ�ٽ� ����
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        //�������� ������ ScreenSpaceOverlay(�̰�츸 ���õǱ� ������)
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //ĵ���� �ȿ� ĵ������ ��ø�ؼ� ���� �� �� �θ� � ���� ������ �ڽ��� ������ �� ���� ������ ��������
        //overrideSorting�� ���� Ȥ�ö� ��øĵ������ �ڽ� ĵ������ �ִ��� �θ� ĵ������ � ���� ������
        //���� �� ���� ���� ������ �Ҷ� true
        canvas.overrideSorting = true;
        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;

        }else//�˾��̶� ������� �Ϲ� UI
        {
            canvas.sortingOrder = 0;
        }
    }
}
