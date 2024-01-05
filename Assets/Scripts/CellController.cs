using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text phoneText;
    [SerializeField] Text addressText;

    private void Awake()
    {
        nameText.text = "";
        phoneText.text = "";
        addressText.text = "";
    }

    void Start()
    {
        
    }
    
    /// <summary>
    /// Dictinary 데이터를 전달하는 메서드
    /// </summary>
    /// <param name="data">Name, Phone, Address 정보가 들어간 Dictionary</param>
    public void SetData(Dictionary<string, string> data)
    {
        nameText.text = data["Name"];
        phoneText.text = data["Phone"];
        addressText.text = data["Address"];
    }
}
