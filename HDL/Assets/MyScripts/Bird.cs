using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	tk2dSpriteAnimator anim;
	//游戏状态
	public static bool isPlay = true;
	public static float f_moveSpeed=2.5f;//小鸟移动速度
	//相应声音对象
	public AudioSource as_Audio;
	public AudioClip ac_fly;
	public AudioClip ac_die;
	public AudioSource as_point;
	public GUISkin gs;
	//实时分数及最高分数
	private int i_score = 0,i_maxScore=0,a=0;
	private Vector3 v;
	//小鸟朝向的方向标识
	private int rotaEuler=1;
	// Use this for initialization
	void Start () {
		anim = GetComponent<tk2dSpriteAnimator>();
		//获取存储的最高分数
		i_maxScore=PlayerPrefs.GetInt ("maxScore",0);
		v = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,Screen.height,0f));
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (this.rigidbody.velocity.y);
		if (isPlay) {
			//控制小鸟不超出屏幕上方
			if (this.renderer.bounds.max.y>v.y) {
				this.transform.localPosition=new Vector3(this.transform.localPosition.x,
				                                         v.y-this.renderer.bounds.size.y/2,
				                                         0f);		
			}
			//获取实时分数
			i_score = GetScore ();
			//向上添加一个速度
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				addForce();
			}
			//移动端检测屏幕触发
			foreach (Touch touch in Input.touches) {
				if (touch.phase==TouchPhase.Began)
				{
					addForce();
				}
			}
			//获取小鸟的垂直速度方向
			if(this.rigidbody.velocity.y>0)
			{
				Debug.Log(this.transform.localRotation);
				rotaEuler=1;
			}
			else
			{
				Debug.Log(this.transform.localRotation);
				rotaEuler=-1;
			}
			this.transform.localRotation=Quaternion.Euler(new Vector3(0, 0, rotaEuler*20));
		}

	}
	//添加垂直向上的速度
	void addForce()
	{
		as_Audio.clip=ac_fly;
		as_Audio.Play();
		this.rigidbody.velocity=new Vector3(0f,4f,0f);
	}
	//检测碰撞
	void OnCollisionEnter(Collision collision){
		if(isPlay)
		{
			as_Audio.clip=ac_die;
			as_Audio.Play();
			isPlay = false;
			anim.Stop ();
		}

	}
	//绘制GUI界面~~~超简单的....NGUI和GUI都了解下...
	void OnGUI()
	{
		GUI.skin = gs;
		GUI.Label (new Rect(0,0,Screen.width,40),"你的成绩:"+i_score+" 历史最高:"+i_maxScore);
		if (!Bird.isPlay) {
			if(PlayerPrefs.GetInt ("maxScore")<i_score)
			{
				PlayerPrefs.SetInt ("maxScore",i_score);
			}
			
			if(GUI.Button (new Rect(Screen.width/4,Screen.height/2-Screen.width/20,Screen.width/2,Screen.width/10),"再来一次"))
			{
				Application.LoadLevel("Level01");
				Bird.isPlay=true;
			}
			if (GUI.Button (new Rect(Screen.width/4,Screen.height/2-Screen.width/20+Screen.width/10+5,Screen.width/2,Screen.width/10),"返回菜单"))
			{
				Application.LoadLevel("Main");
			}
		}
		
	}
	//获取即时分数
	int GetScore()
	{
		if (a != i_score) {
			as_point.Play();
			a=i_score;
		}
		i_score = (int)((this.transform.position.x-6.5)/3.5);
		return i_score < 0 ? 0 : i_score;;
	}
}
//---