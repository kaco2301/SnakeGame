//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class Joystick : MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
//{

//    [SerializeField]
//    Image backImg;
//    Image stick;
//    Vector3 input;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void OnPointerDown(PointerEventData data)
//    {
//        OnDrag(data);
//    }

//    public void OnPointerUp(PointerEventData data)
//    {
//        input = Vector3.zero;
//        stick.rectTransform.anchoredPosition = input;
//    }

//    public void OnDrag(PointerEventData data)
//    {
//        var rect = backImg.rectTransform;
//        var camera = data.pressEventCamera;
//        var dataPos = data.position;
//        Vector3 pos;

//        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, dataPos,camera,out pos))
//        {

//        }
//    }
//}
