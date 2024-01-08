using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using System;

public delegate void CreateData(Office office);

public class CreatePanelController : MonoBehaviour
{
    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField registInputField;
    [SerializeField] TMP_InputField numberInputField;
    [SerializeField] TMP_InputField businessInputField;
    [SerializeField] TMP_InputField phoneInputField;

    // 1. delegate
    public CreateData createData;

    // 2. Action
    public Action<Office> createDataAction;

    void Awake()
    {
        addressInputField.text = "";
        nameInputField.text = "";
        registInputField.text = "";
        numberInputField.text = "";
        businessInputField.text = "";
        phoneInputField.text = "";
    }

    /// <summary>
    /// 저장 버튼 클릭시 실행할 메서드
    /// </summary>
    public void OnClickSaveButton()
    {
        Office office = new Office(
                addressInputField.text,
                nameInputField.text,
                registInputField.text,
                int.Parse(numberInputField.text),
                businessInputField.text,
                phoneInputField.text);

        // 1. delegate
        if (this.createData != null)
        {
            this.createData(office);
        }

        // 2. Action
        if (this.createDataAction != null)
        {
            this.createDataAction(office);
        }
    }

    /// <summary>
    /// 닫기 버튼 클릭시 실행할 메서드
    /// </summary>
    public void OnClickCloseButton()
    {
        Destroy(gameObject);
    }
}
