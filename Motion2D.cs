using UnityEngine;
using System.Collections;

/// <summary>
/// Make motion for Game object in 2D.
/// </summary>
public class Motion2D {

	/// <summary>
	/// Linear motion.
	/// </summary>
	/// <param name="gameObj">Game object.</param>
	/// <param name="velocity">Velocity vector magnitude.</param>
	/// <param name="alpha">Angle between velocity vector and Obj's x directory in degree.</param>
	public static void Linear(GameObject gameObj, float velocity, float alpha) {

		float rad = alpha * Mathf.PI / 180;

		float Vx = velocity * Mathf.Cos(rad);
		float Vy = velocity * Mathf.Sin(rad);

		float t = Time.fixedDeltaTime;

		Vector2 vector = new Vector2(Vx * t, Vy * t);

		gameObj.transform.Translate(vector);
	}

	/// <summary>
	/// Rotate.
	/// </summary>
	/// <param name="gameObj">Game object.</param>
	/// <param name="omega">Angula velocity in rad/s.</param>
	public static void Rotate(GameObject gameObj, float omega) {

		float t = Time.fixedDeltaTime;

		gameObj.transform.Rotate(Vector3.forward * omega * t);
	}




	/// <summary>
	/// Periodic fluctuations.
	/// </summary>
	/// <param name="gameObj">Game object.</param>
	/// <param name="position">Equilibria position.</param>
	/// <param name="vertical">true: Vertical, false: Horizontal.</param>
	/// <param name="A">Amilitude.</param>
	/// <param name="f">Frequence in Hz.</param>
	/// <param name="phi">Initial phase in Degree.</param>
	public static void Periodic(GameObject gameObj, Vector2 position, bool vertical, float A, float f, float phi) {
	
		float x0 = gameObj.transform.position.x;
		float y0 = gameObj.transform.position.y;
	
		float X = position.x;
		float Y = position.y;
	
		float t = Time.fixedTime;
	
		float x, y;
		if (vertical) {
			x = x0;
			y = Y + A * Mathf.Sin(2 * Mathf.PI * f * t + phi * Mathf.PI / 180);
		} else {
			x = X + A * Mathf.Sin(2 * Mathf.PI * f * t + phi * Mathf.PI / 180);
			y = y0;
		}
	
		Vector2 vector = new Vector2(x - x0, y - y0);
	
		gameObj.transform.Translate(vector);
	}


	//	public static void Periodic(GameObject gameObj, Vector2 position, float alpha, float A, float f, float phi) {
	//
	//		float x0 = gameObj.transform.position.x;
	//		float y0 = gameObj.transform.position.y;
	//
	//		float X = position.x;
	//		float Y = position.y;
	//
	//		float t = Time.fixedTime;
	//
	//		float x, y;
	//		if (alpha > 0) {
	//			x = x0;
	//			y = Y + A * Mathf.Sin(2 * Mathf.PI * f * t + phi * Mathf.PI / 180);
	//		} else {
	//			x = X + A * Mathf.Sin(2 * Mathf.PI * f * t + phi * Mathf.PI / 180);
	//			y = y0;
	//		}
	//
	//		Vector2 vector = new Vector2(x - x0, y - y0);
	//
	//		gameObj.transform.Translate(vector);
	//	}




	/// <summary>
	/// Run and catch.
	/// </summary>
	/// <param name="tom">Tom.</param>
	/// <param name="jerry">Jerry.</param>
	/// <param name="velocityTom">Tom's velocity.</param>
	public static void RunAndCatch(GameObject tom, GameObject jerry, float velocityTom) {

		float xTom = tom.transform.position.x;
		float yTom = tom.transform.position.y;

		float xJerry = jerry.transform.position.x;
		float yJerry = jerry.transform.position.y;

		Vector2 flowVec = new Vector2(xJerry - xTom, yJerry - yTom);

		float radius = Mathf.Atan2(flowVec.y, flowVec.x);

		float vx = velocityTom * Mathf.Cos(radius);
		float vy = velocityTom * Mathf.Sin(radius);

		float t = Time.fixedDeltaTime;

		Vector2 tranVec = new Vector2(vx * t, vy * t);

		tom.transform.Translate(tranVec);
	}

	public static void CircleMotion() {
		
	}




	//	public static bool InTriangle(GameObject gameObj, GameObject pos1, GameObject pos2, GameObject pos3) {
	//
	//		float xO = gameObj.transform.position.x;
	//		float yO = gameObj.transform.position.y;
	//
	//		float xA = pos1.transform.position.x;
	//		float yA = pos1.transform.position.y;
	//
	//		float xB = pos2.transform.position.x;
	//		float yB = pos2.transform.position.y;
	//
	//		float xC = pos3.transform.position.x;
	//		float yC = pos3.transform.position.y;
	//
	//		Vector2 OA = new Vector2(xA - xO, yA - yO);
	//		Vector2 OB = new Vector2(xB - xO, yB - yO);
	//		Vector2 OC = new Vector2(xC - xO, yC - yO);
	//
	//		float AOB = Vector2.Angle(OA, OB);
	//		float AOC = Vector2.Angle(OA, OC);
	//		float BOC = Vector2.Angle(OB, OC);
	//
	//		float OABC = AOB + AOC + BOC;
	//
	//		if (OABC > 359.9f) {
	//			return true;
	//		}
	//
	//		return false;
	//	}

	public static bool InTriangle(GameObject gameObj, GameObject[] pos) {

		float xO = gameObj.transform.position.x;
		float yO = gameObj.transform.position.y;

		float xA = pos[0].transform.position.x;
		float yA = pos[0].transform.position.y;

		float xB = pos[1].transform.position.x;
		float yB = pos[1].transform.position.y;

		float xC = pos[2].transform.position.x;
		float yC = pos[2].transform.position.y;

		Vector2 OA = new Vector2(xA - xO, yA - yO);
		Vector2 OB = new Vector2(xB - xO, yB - yO);
		Vector2 OC = new Vector2(xC - xO, yC - yO);

		float AOB = Vector2.Angle(OA, OB);
		float AOC = Vector2.Angle(OA, OC);
		float BOC = Vector2.Angle(OB, OC);

		float OABC = AOB + AOC + BOC;

		if (OABC == 360) {
			return true;
		}

		return false;
	}

}

