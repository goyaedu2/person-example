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
    /// �����͸� �ҷ����� �޼���
    /// </summary>  
    /// <param name="office">������</param>
    /// <param name="index">�������� �ε���</param>
    public void SetData(Office office, int index)
    {
        dataIndex = index;
        addressInputField.text = office.���θ��ּ�;
        nameInputField.text = office.�繫�Ҹ�;
        registInputField.text = office.�Ű���;
        numberInputField.text = office.����.ToString();
        businessInputField.text = office.��������;
        phoneInputField.text = office.��ȭ��ȣ;
    }

    /// <summary>
    /// ���� ��ư Ŭ���� ������ �޼���
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

        // ������Ʈ
        if (this.updateData != null)
        {
            this.updateData(office, dataIndex);
        }
    }

    /// <summary>
    /// �ݱ� ��ư Ŭ���� ������ �޼���
    /// </summary>
    public void OnClickCloseButton()
    {
        Destroy(gameObject);
    }
}
