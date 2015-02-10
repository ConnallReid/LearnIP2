using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {


	public float jumpHeight=100f;
	public float angleLeft=-270f;
	public float angleRight=270f;
	 bool rightWay;

	bool hasJumped;
	bool standing;
	bool doubleJump=false;
	bool wallJump=false ;
	public Transform sightStart, sightEnd;
 	



	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {

		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
		if (absVelY < .2f) {
			standing = true;
		} else {
			standing = false;
		}

		hasJumped = Input.GetKeyDown ("up");

		if(transform.localScale.x==1){
			rightWay =true;
		}else if(transform.localScale.x==-1){
			rightWay=false;
		}
	}

	void FixedUpdate(){

		wallJump =Physics2D.Linecast(sightStart.position,sightEnd.position,1<< LayerMask.NameToLayer ("Wall"));
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
	
	if(hasJumped){
		hasJumped =false;
	if(standing){
		rigidbody2D.AddForce(Vector2.up*jumpHeight);
		doubleJump=true;
	}else if(wallJump&& rightWay){
		rigidbody2D.AddForce (new Vector2(angleLeft,jumpHeight));
		this.transform.localScale= new Vector3((transform.localScale.x==1)?-1:1,1,1);
	}else if(wallJump && rightWay == false){
		rigidbody2D.AddForce (new Vector2(angleRight,jumpHeight));
		this.transform.localScale= new Vector3((transform.localScale.x==1)?-1:1,1,1);
	}else if(doubleJump){
		rigidbody2D.AddForce(Vector2.up*jumpHeight);
		doubleJump = false;
	}
				
}
}
}
