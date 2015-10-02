using UnityEngine;
using System.Collections;

public class AmazingCube_Rotation : MonoBehaviour 
{
	private Vector2 sensitivity;
    private Touch MyTouch;
    public bool Clicked;
    private bool Touched;
    void Start()//Inicialização das variáveis.
	{
        if(Application.platform == RuntimePlatform.Android)
        {
            MyTouch = Input.GetTouch(0);
        }
        Touched = false;
        Clicked = false;
        sensitivity = new Vector2(400f, 400f);
	}
	void Update () //Rotina de update personalizada.
    {
        Preferences();
        if (Application.platform == RuntimePlatform.Android) //Verifica em qual plataforma o jogo está rodando(Mobile ou PC) para que a função correta seja chamada.
        {
            MobileRotation();
        }
        else
        {
            PCRotation();
        }   
	}
    void Preferences()//Preferências relacionadas à rotação do cubo.
    {
        if (!Clicked && !Touched) //Verifica se há clique ou touch, se não, faz o cubo ter uma leve rotação.
        {
            transform.Rotate(0.01f, 0.01f, 0.01f);
        }
    }
    void MobileRotation()//Preferências de rotação para Mobile.
    {
        Touched = MyTouch.tapCount > 0 ? true : false; //Verifica se a tela está sendo tocada ou não.
        if(Touched)//Se tocado, permite a rotação.
        {
            transform.Rotate(Input.GetTouch(0).deltaPosition.y * sensitivity.y * Time.deltaTime, Input.GetTouch(0).deltaPosition.x * sensitivity.x * Time.deltaTime, 0f, Space.World);
            transform.Rotate(0f, 0f, ((Input.GetTouch(1).deltaPosition.y * sensitivity.y * Time.deltaTime) + (Input.GetTouch(1).deltaPosition.x * sensitivity.x * Time.deltaTime)) / 2, Space.World);
        }
    }
    void PCRotation()//Preferências de rotação para PC.
    {
        if (Input.GetMouseButtonDown(1))//Verificação para saber se o mouse está pressionado ou não.
        {
            Clicked = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Clicked = false;
        }
        if (Clicked)//Verificação para ver se o mouse está pressionado. Se sim, permite a rotação.
        {
            transform.Rotate((Input.GetAxis("Mouse Y") * sensitivity.y * Time.deltaTime), (Input.GetAxis("Mouse X") * -sensitivity.x * Time.deltaTime), 0, Space.World);
        }
    }
}
