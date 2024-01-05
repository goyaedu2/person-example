using System;
using System.Collections;
using System.Collections.Generic;
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