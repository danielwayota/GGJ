using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICounter : MonoBehaviour
{
    public Text targetLabel;

    public void Write(int amount)
    {
        this.targetLabel.text = amount.ToString();
    }
}
