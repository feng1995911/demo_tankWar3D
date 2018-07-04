using System;
using UnityEngine;
using System.Collections.Generic;
using GameFramework;
using GameMain;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool clickToMove = false;
    [SerializeField]
    private List<string> clickableTags = new List<string>();
    [SerializeField]
    private float runSpeed = 2;
    [SerializeField]
    private float backpedalSpeed = 1;
    [SerializeField]
    private float turnSpeed = 3;
    [SerializeField]
    private float gravity = 20;
    [SerializeField]
    private float slopeLimit = 55;
    [SerializeField]
    private float fallThreshold = 10;
    [SerializeField]
    private float antiBunny = 0.75f;

	private bool m_controllable = true;
	private float m_speed = 0;
	private Vector3 m_velocity = Vector3.zero;
	private float m_fall_start = 0;
	private float m_input_x = 0;
	private float m_input_y = 0;
	private float m_input_s = 0;
	private float m_rotation = 0;
	private Vector3 m_last_position = Vector3.zero;
	private float m_animation_speed = 1;
	private float m_move_speed = 0;
	private Vector3 m_wanted_position = Vector3.zero;
	private Vector3 m_last_wanted_position = Vector3.zero;
	private float m_last_distance = 0;

	private CharacterController m_controller;

    public event Action<Vector3> OnMove;
    public event Action OnIdle;


    public Vector3 Velocity
	{
		get { return m_velocity; }
		set { m_velocity = value; }
	}

	public float InputX
	{
		get { return m_input_x; }
	}

	public float InputY
	{
		get { return m_input_y; }
	}

	public float InputS
	{
		get { return m_input_s; }
	}

	public float Rotation
	{
		get { return m_rotation; }
	}

	public float FallPosition
	{
		get { return m_fall_start; }
		set { m_fall_start = value; }
	}

	public bool Controllable
	{
		get { return m_controllable; }
		set { m_controllable = value; }
	}

	public void Init(CharacterController cc)
	{
	    if (cc == null)
	    {
	        Log.Error("Init playerController fail. CharacterController is null.");
            return;
	    }
		m_controller = cc;

		m_controller.slopeLimit = slopeLimit;
		m_wanted_position = transform.position;
	}

	void Update()
	{		
		if(m_controllable)
		{
			if(clickToMove)
			{
				if(Input.GetMouseButton(0))
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit[] hits = Physics.RaycastAll(ray);

					foreach(RaycastHit hit in hits)
					{
						bool done = false;

						foreach(string tag in clickableTags)
						{
							if(hit.transform.CompareTag(tag))
							{
								m_wanted_position = hit.point;
								m_last_distance = Vector3.Distance(transform.position, m_wanted_position);
								done = true;
								break;
							}
						}

						if(done)
						{
							break;
						}
					}
				}
			}
		}
		
	}

    void FixedUpdate()
    {
        m_animation_speed = 1;
        float input_modifier = (m_input_x != 0.0f && m_input_y != 0.0f) ? 0.7071f : 1.0f;

        if (m_controllable)
        {
            m_input_x = GameEntry.Input.GetAxis(Constant.Input.HorizontalAxis);
            m_input_y = GameEntry.Input.GetAxis(Constant.Input.VerticalAxis);
        }

        if (m_input_s != 0)
        {
            m_input_x = m_input_s;
        }

        if (m_input_x != 0 && m_input_s == 0)
        {
            transform.Rotate(new Vector3(0, m_input_x * (turnSpeed / 2.0f), 0));
            m_rotation = m_input_x;
            m_input_x = 0;
        }
        else
        {
            m_rotation = 0;
        }

        //if (m_input_x > 0)
        //{
        //    transform.localEulerAngles = new Vector3(0, 90, 0);
        //}
        //else if(m_input_x < 0)
        //{
        //    transform.localEulerAngles = new Vector3(0, -90, 0);
        //}
        //else
        //{
        //    transform.localEulerAngles = Vector3.zero;
        //}

        if (m_input_y < 0)
        {
            m_speed = backpedalSpeed;
        }
        else
        {
            m_speed = runSpeed;
        }

        if (clickToMove)
        {
            if (m_last_wanted_position != m_wanted_position)
            {
                float d = Vector3.Distance(transform.position, m_wanted_position);

                if (d > m_last_distance)
                {
                    d = 0;
                }
                else
                {
                    m_last_distance = d;
                }

                if (d >= 0.1f)
                {
                    transform.LookAt(new Vector3(m_wanted_position.x, transform.position.y, m_wanted_position.z));
                    m_input_y = Mathf.Clamp(d/2f, 0, 1);
                }
                else
                {
                    m_last_wanted_position = m_wanted_position;
                    m_input_y = 0;
                }
            }
        }

        m_velocity = new Vector3(m_input_x*input_modifier, -antiBunny, m_input_y*input_modifier);
        //m_velocity = transform.TransformDirection(m_velocity);

        //m_move_speed = (transform.position - m_last_position).magnitude;
        //m_last_position = transform.position;

        if (Mathf.Abs(m_input_x) > 0.01f || Mathf.Abs(m_input_y) > 0.01f)
        {
            //m_velocity.y -= gravity*Time.deltaTime;
            //m_controller.Move(m_velocity*Time.deltaTime);
            OnMove?.Invoke(m_velocity*Time.deltaTime);
        }
        else
        {
            OnIdle?.Invoke();
        }

    }
}