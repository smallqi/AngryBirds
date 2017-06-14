using UnityEngine;
using System.Collections.Generic;

public class Init : MonoBehaviour {
	//动态生成地图地板 障碍物
	public Transform t_floor;
	public Transform t_barrier;
	//地板和障碍物的下一个坐标
	private Vector3 floorNextPos,barrierNextPos;
	//队列 存放生成的障碍物和地板,以便后面重复使用,更快更方便
	private Queue<Transform> floorQueue,barrierQueue;
	private int i_index=0;
	private int i_numOfObject=2;
	private float f_spriteX;

	void Awake()
	{
		tk2dSprite sprite = t_floor.GetComponent<tk2dSprite>();
		f_spriteX= sprite.GetUntrimmedBounds().size.x*t_floor.localScale.x;
		if(Bird.isPlay){
			//设置初始位置
			floorQueue = new Queue<Transform>(i_numOfObject);
			barrierQueue = new Queue<Transform>(4);
			barrierNextPos= transform.localPosition;
			barrierNextPos.z=0f;
			barrierNextPos.x=10f;
			floorNextPos = transform.localPosition;
			floorNextPos.z=0f;
			floorNextPos.y=-4f;
			//初始化地面
			for(i_index=0;i_index<i_numOfObject;i_index++){
				Transform tf=(Transform)Instantiate (t_floor);
				tf.localPosition=floorNextPos;
				tf.tag="floor";
				//横向X轴平移
				floorNextPos.x+=f_spriteX;
				floorQueue.Enqueue(tf);//加入队列中
			}
			//障碍物
			for(i_index=0;i_index<4;i_index++)
			{
				barrierNextPos.y=Random.Range(-6f,-2.5f);
				Transform tf=(Transform)Instantiate (t_barrier);
				tf.localPosition=barrierNextPos;
				tf.tag="barrier";
				barrierNextPos.x+=3.5f;
				barrierQueue.Enqueue(tf);
			}
		}
	}
	// Use this for initialization
	void Start () {

	}

	void Update () {
		if(Bird.isPlay)
		{
			//判断地板是否在当前位置后面一定偏移量,若是,则把最后面一个移动到前面
			if (floorQueue.Peek().localPosition.x +f_spriteX< transform.position.x)
			{
				Transform o = floorQueue.Dequeue();
				o.localPosition = floorNextPos;
				floorNextPos.x += f_spriteX;
				floorQueue.Enqueue(o);
			}
			//障碍物跟地板原理一样,只是Y轴要随机一个高度,使通道看起来不再一个高度
			if (barrierQueue.Peek().localPosition.x +5< transform.position.x)
			{
				barrierNextPos.y=Random.Range(-6f,-2.5f);
				Transform o = barrierQueue.Dequeue();
				o.localPosition = barrierNextPos;
				barrierNextPos.x += 3.5f;
				barrierQueue.Enqueue(o);
			}
		}
	}

}
