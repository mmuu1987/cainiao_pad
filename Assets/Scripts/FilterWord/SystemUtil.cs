﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemUtil
{
    /// <summary>
    /// 判断是否非法字符
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsInvaild(string str)
    {
        string source = Filter(str);
        return str != source;
    }

    /// <summary>
    /// 把非法字符变成*号
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Filter(string str)
    {
        filterWord.SourceText = str;
        return filterWord.Filter('*');
    }

    public static FilterWord filterWord
    {
        get
        {
            if (null == m_FilterWord)
            {
                m_FilterWord = new FilterWord();
            }
            return m_FilterWord;
        }
    }

    private static FilterWord m_FilterWord;
}
