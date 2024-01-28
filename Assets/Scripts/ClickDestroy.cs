using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    public void finishClick()
    {
        Destroy(this.gameObject);
    }
}
