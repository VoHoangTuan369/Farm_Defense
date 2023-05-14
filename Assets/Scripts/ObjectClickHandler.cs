using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClickHandler : MonoBehaviour
{
    public GameObject popupWindow;
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
                //popupWindow = null;
            }
            else
            {
                // Nếu popupWindow chưa hiển thị, tiếp tục hiển thị như cũ.
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("window");
                    Instantiate(popupWindow, this.gameObject.transform.position, Quaternion.identity);
                    Vector2 mousePosition = Input.mousePosition;
                    Vector2 viewportPoint = Camera.main.ScreenToViewportPoint(mousePosition);
                    RectTransform rt = popupWindow.GetComponent<RectTransform>();
                    rt.anchorMin = viewportPoint;
                    rt.anchorMax = viewportPoint;
                    rt.anchoredPosition = Vector2.zero;
                    popupWindow.SetActive(true);
                }
            }
        }
    }
}
