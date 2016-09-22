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
	/// <param name="alpha">Angle between velocity vector and Ox axis in degree.</param>
	public static void LinearMotion(GameObject gameObj, float velocity, float alpha) {

		float radius = alpha * Mathf.PI / 180;

		float vx = velocity * Mathf.Cos(radius);
		float vy = velocity * Mathf.Sin(radius);

		float t = Time.fixedDeltaTime;

		Vector2 vector = new Vector2(vx * t, vy * t);

		gameObj.transform.Translate(vector);
	}

	/// <summary>
	/// Periodic fluctuations.
	/// </summary>
	/// <param name="gameObj">Game object.</param>
	/// <param name="position">Equilibria's position.</param>
	/// <param name="vertical">Vertical.</param>
	/// <param name="A">Amilitude.</param>
	/// <param name="f">Frequence.</param>
	/// <param name="phi">Initial phase in radius.</param>
	public static void PeriodicFluctuations(GameObject gameObj, Vector2 position, bool vertical, float A, float f, float phi) {

		float x0 = gameObj.transform.position.x;
		float y0 = gameObj.transform.position.y;

		float X = position.x;
		float Y = position.y;

		float t = Time.fixedTime;

		float x, y;
		if (vertical) {
			x = x0;
			y = Y + A * Mathf.Sin(2 * Mathf.PI * f * t + phi);
		} else {
			x = X + A * Mathf.Sin(2 * Mathf.PI * f * t + phi);
			y = y0;
		}

		Vector2 vector = new Vector2(x - x0, y - y0);

		gameObj.transform.Translate(vector);
	}

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


}
