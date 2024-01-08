using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Office
{
    public string 도로명주소;
    public string 사무소명;
    public string 신고구분;
    public int 연번;
    public string 영업구분;
    public string 전화번호;

    public Office() : this("", "", "", 0, "", "") { }

    public Office(string address, string name, string regist, int number, string business, string phone)
    {
        this.도로명주소 = address;
        this.사무소명 = name;
        this.신고구분 = regist;
        this.연번 = number;
        this.영업구분 = business;
        this.전화번호 = phone;
    }

    public Office(string name) : this("", name, "", 0, "", "") { }
}

public class OfficeData
{
    public int currentCount;
    public Office[] data;
    public int matchCount;
    public int page;
    public int perPage;
    public int totalCount;
}