using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {

    // URL para a qual você deseja enviar o JSON
    private static string urlS= "https://api-casa-do-tatu.onrender.com/register";
    private static string urlSTest= "https://api-casa-do-tatu.onrender.com/";
    private static string urlSLogin= "https://api-casa-do-tatu.onrender.com/login";
    Uri url = new Uri(urlS);
    Uri urlTest = new Uri(urlSTest);
    Uri urlLogin = new Uri(urlSLogin);
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_Text status;


    // Os dados que você deseja enviar como JSON
    

    void Start () {
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(urlTest))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    status.text = webRequest.downloadHandler.text;
                    break;
            }
        }
            
    }
    public void Cadastrar()
    {
        if(username.text == null || password.text == null || email.text == null || username.text == "" || password.text == "" || email.text == "")
        {
            status.text = "Erro! dados inválidos";
            return;
        }
        var user = new UserData();
        user.username = username.text;
        user.email = email.text;
        user.password = password.text;
        if (!IsValidEmail(user.email))
        {
            status.text = "Erro! Email inválido";
            return;
        }
        else if (!IsStrongPassword(user.password))
        {
            status.text = "Erro! Senha fraca";
            return;
        }
        string data = JsonUtility.ToJson(user);
        StartCoroutine(SendJsonCadastrar(data));
    }

    IEnumerator SendJsonCadastrar(string data)
    {
        // Converta os dados para JSON
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(data);
        Debug.Log("json " + data);
        Debug.Log("" + bodyRaw);
        yield return new WaitForSeconds(1);
        Debug.Log("CAbou");
        
        // Crie a solicitação HTTP POST
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Envie a solicitação e espere a resposta
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            string message = request.downloadHandler.text;
            string success = "register sucessful";
            string error = "Username already exists";
            Debug.Log(request.downloadHandler.text);
            if (message.Contains(success))
            {
                Debug.Log("Cadastrado");
                SceneManager.LoadScene("Tela de Fases");
            }
            else
            {
                status.text = "Usuário já cadastrado";
                status.color = Color.red;
            }
        }
        
    }
    public void Login()
    {
        if (username.text == null || password.text == null || email.text == null || username.text == "" || password.text == "" || email.text == "")
        {
            status.text = "Erro! dados inválidos";
            return;
        }
        var user = new UserData();
        user.username = username.text;
        user.email = email.text;
        user.password = password.text;
        if (!IsValidEmail(user.email))
        {
            status.text = "Erro! Email inválido";
            return;
        }
        else if(!IsStrongPassword(user.password))
        {
            status.text = "Erro! Senha fraca";
            return;
        }
        
        
        string data = JsonUtility.ToJson(user);
        StartCoroutine(SendJsonLogin(data));
    }

    IEnumerator SendJsonLogin(string data)
    {
        // Converta os dados para JSON
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(data);
        Debug.Log("json " + data);
        Debug.Log("" + bodyRaw);
        yield return new WaitForSeconds(1);
        Debug.Log("CAbou");

        // Crie a solicitação HTTP POST
        UnityWebRequest request = new UnityWebRequest(urlLogin, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Envie a solicitação e espere a resposta
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            string message = request.downloadHandler.text;
            string success = "logged in";
            string error = "cant find this account or wrong credentials";
            Debug.Log(request.downloadHandler.text);
            if (message.Contains(success))
            {
                Debug.Log("Logado");
                SceneManager.LoadScene("Tela de Fases");
            }
            else
            {
                status.text = "Credenciais inválidas ou não foi possivel encontrar sua conta";
                status.color = Color.red;
            }
        }

    }
    public static bool IsValidEmail(string email)
    {
        // Definir o padrão de expressão regular para endereços de e-mail
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        // Criar um objeto Regex com o padrão definido
        Regex regex = new Regex(pattern);

        // Verificar se o endereço de e-mail corresponde ao padrão
        if (regex.IsMatch(email))
        {
            return true;
        }
        return false;
    }
    public static bool IsStrongPassword(string password)
    {
        // Definir o padrão de expressão regular para senhas fortes
        string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+])[0-9a-zA-Z!@#$%^&*()_+]{8,}$";

        // Criar um objeto Regex com o padrão definido
        Regex regex = new Regex(pattern);

        // Verificar se a senha corresponde ao padrão
        if (regex.IsMatch(password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public class UserData
    {
        public string username;
        public string password;
        public string email;
    }
}
