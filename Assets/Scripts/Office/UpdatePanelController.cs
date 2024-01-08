using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using System;

public delegate void UpdateData(Office office, int index);

public class UpdatePanelController : MonoBehaviour
{
    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] TMP_InputField registInputField;
    [SerializeField] TMP_InputField numberInputField;
    [SerializeField] TMP_InputField businessInputField;
    [SerializeField] TMP_InputField phoneInputField;

    // 1. delegate
    public UpdateData updateData;

    private int dataIndex;

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
    /// 데이터를 불러오는 메서드
    /// </summary>  
    /// <param name="office">데이터</param>
    /// <param name="index">데이터의 인덱스</param>
    public void SetData(Office office, int index)
    {
        dataIndex = index;
        addressInputField.text = office.도로명주소;
        nameInputField.text = office.사무소명;
        registInputField.text = office.신고구분;
        numberInputField.text = office.연번.ToString();
        businessInputField.text = office.영업구분;
        phoneInputField.text = office.전화번호;
    }

    /// <summary>
    /// 저장 버튼 클릭시 실행할 메서드
    /// </summary>
    public void OnClickUpdateButton()
    {
        Office office = new Office(
                addressInputField.text,
                nameInputField.text,
                registInputField.text,
                int.Parse(numberInputField.text),
                businessInputField.text,
                phoneInputField.text);

        // 업데이트
        if (this.updateData != null)
        {
            this.updateData(office, dataIndex);
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
