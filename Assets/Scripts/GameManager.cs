using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text baseHealthTxt;


    public void UpdateBaseHealthTxt(int currentBaseHealth)
    {
        baseHealthTxt.text = currentBaseHealth.ToString();
    }
}
