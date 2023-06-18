using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClickHandler : MonoBehaviour
{
    public GameObject popupWindow;
    public static bool isPopupOpen = false; //Thêm biến lưu trữ toàn cục
    void Start()
    {
        popupWindow.SetActive(false);
    }
    public void OnMouseDown()
    {
        if (popupWindow)
        {
            if (popupWindow.activeSelf)
            {
                // Đóng cửa sổ pop-up và gán giá trị null cho popupWindow.
                popupWindow.SetActive(false);
                isPopupOpen = false;
                //popupWindow = null;
            }
            else
            if (!isPopupOpen) //Kiểm tra cửa sổ pop-up có được hiển thị hay chưa
            {
                {
                    // Nếu popupWindow chưa hiển thị, tiếp tục hiển thị như cũ.
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("window");
                        popupWindow.SetActive(true);
                        Vector2 mousePosition = Input.mousePosition;
                        Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(mousePosition);
                        RectTransform rt = popupWindow.GetComponent<RectTransform>();
                        rt.anchorMin = viewportPoint;
                        rt.anchorMax = viewportPoint;
                        rt.anchoredPosition = Vector2.zero;
                        isPopupOpen = true;
                    }
                }
            }
        }
    }
    public void ClosePopup()
    {
        popupWindow.SetActive(false);
        isPopupOpen = false; //Đặt biến isPopupOpen thành false.
    }
}
