using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CTBLInfo
{
    #region Instance

    private CTBLInfo() { }
    private static CTBLInfo m_Instance = null;
    public static CTBLInfo Inst
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new CTBLInfo();
            }
            return m_Instance;
        }
    }
    #endregion

    protected bool m_bInited = false;

    public void Init()
    {
        if (!m_bInited)
        {

            LoadTBL("TBL/Note", LoadNoteInfo);

            m_bInited = true;
        }
    }

    public void LoadTBL(string szPath, DelegateLoadTBL dlg)
    {
        CTBLLoader loader = new CTBLLoader();
        loader.LoadFromFile(szPath);

        if (dlg != null)
        {
            dlg(loader);
        }
    }

    public void LoadTBLAbsolutePath(string szPath, DelegateLoadTBL dlg)
    {
        CTBLLoader loader = new CTBLLoader();
        loader.LoadFromFileabAolutePath(szPath);

        if (dlg != null)
        {
            dlg(loader);
        }
    }

    public void LoadTBLByContent(string szContent, DelegateLoadTBL dlg)
    {
        CTBLLoader loader = new CTBLLoader();
        loader.LoadFromFileContent(szContent);

        if (dlg != null)
        {
            dlg(loader);
        }
    }

    public delegate void DelegateLoadTBL(CTBLLoader loader);

    #region DATA

    public class ST_NoteInfo
    {
        public int nID;
        public float fTime;
        public int nNum;
        public int nSide;
        public List<int> listDir = new List<int>();
    }

    protected Dictionary<int, ST_NoteInfo> m_dicNoteInfo = new Dictionary<int, ST_NoteInfo>();

    public void LoadNoteInfo(CTBLLoader loader)
    {
        for (int i = 0; i < loader.GetLineCount(); i++)
        {
            loader.GotoLineByIndex(i);

            ST_NoteInfo pInfo = new ST_NoteInfo();
            pInfo.nID = loader.GetIntByName("id");
            pInfo.fTime = loader.GetFloatByName("Time");
            pInfo.nNum = loader.GetIntByName("Number");
            pInfo.nSide = loader.GetIntByName("Side");

            string[] strArray = loader.GetStringByName("Dir").Split('|');
            for (int j = 0; j < strArray.Length; j++)
            {
                pInfo.listDir.Add(int.Parse(strArray[j]));
            }

            m_dicNoteInfo.Add(pInfo.nID, pInfo);
        }
    }

    public ST_NoteInfo GetNoteInfo(int id)
    {
        ST_NoteInfo outValue = null;
        if (m_dicNoteInfo.TryGetValue(id, out outValue))
        {

        }
        return outValue;
    }

    #endregion
}

