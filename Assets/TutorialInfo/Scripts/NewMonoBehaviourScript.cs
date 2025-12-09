using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    ParticleSystem ps;
    public Gradient MyGradient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ps.Play();
        }
        SetColor();
    }
    void SetColor()
    {
        float t = Mathf.Sin(Time.time) * 0.5f * 0.5f;
        ps.startColor = MyGradient.Evaluate(t);
    }
}
