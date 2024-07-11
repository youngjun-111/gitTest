using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : UI_Popup
{
    [SerializeField]
    Text _text;

    int _score = 0;

    //����� UI�̸��� enum���� ����(�ʿ� �� �߰�)
    //��ư�� ��ưenum���� ���� �ؽ�Ʈ�� �ؽ�Ʈenum���� ����
    enum Buttons
    {
        PointButton,
    }
    enum Texts
    {
        PointText,
        ScoreText,
    }
    enum Images
    {
        Image,
    }
    enum GameObjects
    {
        TestObject,
    }



    void Start()
    {
       Init();
    }
    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));




        //�̺κ��� UI_Base���� �Լ����·� ����� �ش�.
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });



        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.Image).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"���� : {_score}";
    }

    //������Ʈ�� �������� �Լ� ����(UI_Base�� �̵�)
    //Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();//Type�� using System�ʿ�
    //void Bind<T>(Type type)where T : UnityEngine.Object
    //{
    //    string[] names = Enum.GetNames(type);

    //    UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
    //    _objects.Add(typeof(T), objects);

    //    for(int i =0; i < names.Length; i++)
    //    {
    //        //�Ʒ� Util���� ���� �Լ��� �̿��� ó��
    //        if(typeof(T) == typeof(GameObject))
    //        {
    //            objects[i] = Util.FindChild(gameObject, names[i], true);
    //        }else
    //        {
    //            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
    //        }
    //        //��ã���ְ� �ִ��� üũ
    //        if(objects[i] == null)
    //        {
    //            Debug.Log($"Failed to bind({names[i]})");
    //        }
    //    }
    //}
    //T Get<T>(int idx) where T : UnityEngine.Object
    //{
    //    UnityEngine.Object[] objects = null;

    //    if (_objects.TryGetValue(typeof(T), out objects) == false)//���� ������ �׳� ����
    //        return null;

    //    return objects[idx] as T;//�������� �ε��� ��ȣ�� ������ ������ T�� ĳ���� ����
    //}
    //Text GetText(int idx) { return Get<Text>(idx); }
    //Button GetButton(int idx) { return Get<Button>(idx); }
    //Image GetImage(int idx) { return Get<Image>(idx); }


    void Update()
    {

    }


}
