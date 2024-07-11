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

    //사용할 UI이름을 enum으로 생성(필요 시 추가)
    //버튼은 버튼enum으로 관리 텍스트는 텍스트enum으로 관리
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




        //이부분을 UI_Base에서 함수형태로 만들어 준다.
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });



        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.Image).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }

    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        GetText((int)Texts.ScoreText).text = $"점수 : {_score}";
    }

    //컴포넌트에 연결해줄 함수 형태(UI_Base로 이동)
    //Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();//Type은 using System필요
    //void Bind<T>(Type type)where T : UnityEngine.Object
    //{
    //    string[] names = Enum.GetNames(type);

    //    UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
    //    _objects.Add(typeof(T), objects);

    //    for(int i =0; i < names.Length; i++)
    //    {
    //        //아래 Util에서 만든 함수를 이용해 처리
    //        if(typeof(T) == typeof(GameObject))
    //        {
    //            objects[i] = Util.FindChild(gameObject, names[i], true);
    //        }else
    //        {
    //            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
    //        }
    //        //잘찾아주고 있는지 체크
    //        if(objects[i] == null)
    //        {
    //            Debug.Log($"Failed to bind({names[i]})");
    //        }
    //    }
    //}
    //T Get<T>(int idx) where T : UnityEngine.Object
    //{
    //    UnityEngine.Object[] objects = null;

    //    if (_objects.TryGetValue(typeof(T), out objects) == false)//값이 없으면 그냥 리턴
    //        return null;

    //    return objects[idx] as T;//오브젝츠 인덱스 번호를 추출한 다음에 T로 캐스팅 해줌
    //}
    //Text GetText(int idx) { return Get<Text>(idx); }
    //Button GetButton(int idx) { return Get<Button>(idx); }
    //Image GetImage(int idx) { return Get<Image>(idx); }


    void Update()
    {

    }


}
