using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorSalvamento : MonoBehaviour {

    public EstadoSalvamento estado;

    public static GerenciadorSalvamento Instancia { get; set; }

    private void Awake () {
        if (Instancia == null)
            Instancia = this;
        else {
            Destroy (this.gameObject);
            return;
        }
        DontDestroyOnLoad (this.gameObject);
        Carregar ();
    }

    public void Salvar () {
        PlayerPrefs.SetString ("salva", Ajudante.Serializar<EstadoSalvamento> (estado));
        Debug.Log ("Jogo salvo!");
    }

    public void Carregar () {
        if (PlayerPrefs.HasKey ("salva")) {
            estado = Ajudante.Desserializar<EstadoSalvamento> (PlayerPrefs.GetString ("salva"));
            Debug.Log ("Jogo carregado!");
        } else {
            estado = new EstadoSalvamento ();
            Salvar ();
            Debug.Log ("Nenhum arquivo de salvamento... Novo arquivo criado");
        }
    }
}