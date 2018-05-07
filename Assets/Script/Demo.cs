using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {

    public AudioSource pAudio;
    public GameObject objBg;
    public GameObject objNote;

    public Vector3[] vecFromArr;
    public Vector3[] vecToArr;

    public float fInterval;

    private float fTime;
    private int nIdx;
    private CTBLInfo.ST_NoteInfo pNoteInfo;
	// Use this for initialization
	void Start () {
        CTBLInfo.Inst.Init();
        pAudio.Play();
        nIdx = 1;
        pNoteInfo = CTBLInfo.Inst.GetNoteInfo(nIdx);
	}
	
	// Update is called once per frame
	void Update () {
        fTime += Time.deltaTime;
        if (pNoteInfo != null)
        {
            if(fTime >= pNoteInfo.fTime - fInterval)
            {
                for(int i = 0; i < pNoteInfo.nNum; i ++)
                {
                    GameObject pNote = GameObject.Instantiate(objNote) as GameObject;
                    pNote.transform.SetParent(objBg.transform);
                    TweenPosition pTP = pNote.GetComponent<TweenPosition>();
                    TweenScale pTS = pNote.GetComponent<TweenScale>();

                    pNote.transform.rotation = Quaternion.Euler(new Vector3(0,0,pNoteInfo.listDir[i] * 90));

                    pTP.duration = fInterval;
                    pTS.duration = fInterval;
                    
                    if(pNoteInfo.nNum > 1)
                    {
                        pNote.transform.localPosition = vecFromArr[i];
                        pTP.from = vecFromArr[i];
                        pTP.to = vecToArr[i];
                    }
                    else
                    {
                        pNote.transform.localPosition = vecFromArr[pNoteInfo.nSide];
                        pTP.from = vecFromArr[pNoteInfo.nSide];
                        pTP.to = vecToArr[pNoteInfo.nSide];
                    }

                    pTS.enabled = true;
                    pTP.enabled = true;

                    pNote.SetActive(true);
                }
                nIdx++;
                pNoteInfo = CTBLInfo.Inst.GetNoteInfo(nIdx);
            }
        }
	}
}
