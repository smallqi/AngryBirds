using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {
	public UISprite uisprite;
	public UILabel uitext;
	public float skillCD;
	private float cdTmp;
	private bool isFlag=false;
	private int f_tmp=0;
	private string str="";
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(isFlag)
		{
			uitext.enabled=true;
			f_tmp+=1;
			uisprite.fillAmount -= Time.deltaTime/skillCD;
			if(uisprite.fillAmount<=0)
			{
				isFlag=false;
				uisprite.fillAmount=1;
				f_tmp=0;
				uitext.enabled=false;
				Debug.Log ("EndTime"+Time.time.ToString());
			}
			cdTmp=skillCD-f_tmp*Time.deltaTime;
			if(cdTmp<0)
				cdTmp=0;
			if(cdTmp>1)
				str="0";
			else if(cdTmp<1&&cdTmp>=0)
				str="0.0";
			uitext.text=cdTmp.ToString(str);

		}

	}
	void OnClick()
	{
		Debug.Log ("BeginTime"+Time.time.ToString());
		isFlag = true;
	}
}
