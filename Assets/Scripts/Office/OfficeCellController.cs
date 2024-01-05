using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OfficeCellController : MonoBehaviour
{
    [SerializeField] TMP_Text officeName;
    [SerializeField] TMP_Text businessType;
    [SerializeField] TMP_Text phoneNumber;

    private void Awake()
    {
        officeName.text = "";
        businessType.text = "";
        phoneNumber.text = "";
    }

    public void SetData(string officeName, string businessType, string phoneNumber)
    {
        this.officeName.text = officeName;
        this.businessType.text = businessType;
        this.phoneNumber.text = phoneNumber;
    }
}
