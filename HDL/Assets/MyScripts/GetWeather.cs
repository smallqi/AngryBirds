using UnityEngine;
using System.Collections;
using LitJson;

public class GetWeather : MonoBehaviour {
	string strWeatherURL = "http://api.map.baidu.com/telematics/v3/weather?location=重庆&output=json&ak=640f3985a6437dad8135dae98d775a09";

	// Use this for initialization
	void Start () {
		StartCoroutine (SendMessage());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	{
//		"error":0,
//		"status":"success",
//		"date":"2014-04-01",
//		"results":[
//		   {
//			"currentCity":"\u91cd\u5e86",
//			"weather_data":[
//			   {
//				"date":"\u5468\u4e8c(\u4eca\u5929, \u5b9e\u65f6\uff1a14\u2103)",
//				"dayPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/day\/xiaoyu.png",
//				"nightPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/night\/xiaoyu.png",
//				"weather":"\u5c0f\u96e8",
//				"wind":"\u5fae\u98ce",
//				"temperature":"14\u2103"
//			   },
//			   {
//				"date":"\u5468\u4e09",
//				"dayPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/day\/xiaoyu.png",
//				"nightPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/night\/xiaoyu.png",
//				"weather":"\u5c0f\u96e8",
//				"wind":"\u5fae\u98ce",
//				"temperature":"19 ~ 15\u2103"
//			   },
//			   {
//				"date":"\u5468\u56db",
//				"dayPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/day\/yin.png",
//				"nightPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/night\/yin.png",
//				"weather":"\u9634",
//				"wind":"\u5fae\u98ce",
//				"temperature":"20 ~ 14\u2103"
//			   },
//			   {
//				"date":"\u5468\u4e94",
//				"dayPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/day\/duoyun.png",
//				"nightPictureUrl":"http:\/\/api.map.baidu.com\/images\/weather\/night\/duoyun.png",
//				"weather":"\u591a\u4e91",
//				"wind":"\u5fae\u98ce",
//				"temperature":"22 ~ 15\u2103"
//			   }
//			   ]
//		   }
//		   ]
//	}
	IEnumerator SendMessage()
	{
		WWW _w = new WWW (strWeatherURL);
		yield return _w;
		JsonData tJd = JsonMapper.ToObject(_w.text);
		Debug.Log(tJd["status"]);
		Debug.Log(tJd["results"].Count);
	}
}
