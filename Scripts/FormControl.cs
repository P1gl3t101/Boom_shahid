using UnityEngine;
using System.Collections;

public class FormControl : MonoBehaviour {

	private AudioSource sound;
	private Animator anim;
	private SpriteRenderer ren;

	void Start () 
	{
		anim = GetComponent<Animator>();
		sound = GetComponent<AudioSource>();
		ren = GetComponent<SpriteRenderer>();
		ren.sortingOrder = 4; // Поверх "подбитой" фигуры
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) // левая или правая кнопка мыши
		{
			GameControl.hit = true;
			anim.enabled = true;
			gameObject.layer = 3; // Новый слой объекта Ignore Raycast
			ren.sortingOrder = 1;
			sound.Play();
			transform.parent = null; // Объект больше не дочерний 
            SpecialEffectsHelper.Instance.Explosion(transform.position);
		}
	}

	void Die() // Для аниматора
	{

       
        Destroy(gameObject);

	}
}
