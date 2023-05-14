using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectButton : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public GameObject popupWindow;
    public void OnClick()
    {
        if (ObjectToDestroy != null)
        {
            Destroy(popupWindow);
            Destroy(ObjectToDestroy);
        }

        //Destroy(this.gameObject);
    }
}
