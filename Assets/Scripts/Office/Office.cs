using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Office
{
    public string ���θ��ּ�;
    public string �繫�Ҹ�;
    public string �Ű���;
    public int ����;
    public string ��������;
    public string ��ȭ��ȣ;
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