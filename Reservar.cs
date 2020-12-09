using System;
using System.Collections.Generic;

class Reservar{
  string nome;
  int bloco;
  int unidade;
  int hora;

  public string Nome{
    get{return nome;}
    set{nome = value;}
  }

  public int Bloco{
    get{return bloco;}
    set{bloco = value;}
  }

  public int Unidade{
    get{return unidade;}
    set{unidade = value;}
  }

  public int Hora{
    get{return hora;}
    set{hora = value;}
  }

  public Reservar(string n, int b, int u, int h){
    nome = n;

    if(b > 0 & b < 5){
      bloco = b;
    } else{
      throw new Exception("O bloco informado não existe!");
    }

    unidade = u;

    if(h > 5 & h < 23){
      hora = h;
    } else{
      throw new Exception("A hora informada está não pode ser reservada!");
    }
  }

}