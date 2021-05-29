using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

    public float speed, col_radius;
    public int eat_count, life;
	public LayerMask collidables;

	void Update() {
		movement();
		check_collisions();
	}

	void movement() {
		float x, y;
		Vector2 target;

		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");
		target = new Vector2(x, y).normalized * speed * Time.deltaTime;

		transform.Translate(target);
	}

	void check_collisions() {
		Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, col_radius, collidables);

		foreach (var col in cols) {
			switch (col.gameObject.tag) {
				case "bullet":
					var bullet = col.GetComponent<bullet>();
					life -= bullet.damage;

					Destroy(col.gameObject);

					if (life <= 0) death();
					break;
			}
		}
	}

	// INCOMPLETE Animation / son de mort
	void death() => Destroy(gameObject);
}
