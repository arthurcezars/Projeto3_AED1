using System;
using System.Collections.Generic;
using System.IO;

class MainClass {

  public static void Main (string[] args) {
    int teste = 1;
    bool verificando;
    int aux;
    string morador;
    int bloco, apartamento, hora;

    Reservar rv = new Reservar("nome", 1, 1003, 6);
    List<Reservar> lista = new List<Reservar>();

    while(teste == 1){
      try{
        Console.WriteLine("Digite 1 - para fazer uma reserva / 2 - para encerrar / 3 - para mostrar as reservas já feitas");
        aux = int.Parse(Console.ReadLine());
        Console.Clear();

        if(aux == 1){
          Console.Write("Informe o nome do morador: ");
          morador = Console.ReadLine();
          Console.Write("Informe o bloco do morador: ");
          bloco = int.Parse(Console.ReadLine());
          Console.Write("Informe o apartamento do morador: ");
          apartamento = int.Parse(Console.ReadLine());
          Console.Write("Informe a hora que deseja reservar (6 as 22): ");
          hora = int.Parse(Console.ReadLine());

          verificando = false;
          for(int i = 0; i < lista.Count; i++){
            if(lista[i].Hora == hora){
            verificando = true;
            }
          }

          if(verificando == true){
            Console.WriteLine("Esse horario já esta reservado!");
          }else{
            rv = new Reservar(morador, bloco, apartamento, hora);
            lista.Add(rv);
            Console.WriteLine("Hora reservada!\nAperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
          }

        }else{
          if(aux == 2){
          teste = 2;
          }else{
            if(aux == 3){
              for(int i = 0; i < lista.Count; i++){
              Console.WriteLine("Morador: {0} / Bloco: {1} / Unidade: {2} / Hora: {3}", lista[i].Nome, lista[i].Bloco, lista[i].Unidade, lista[i].Hora);
              }
              Console.WriteLine("Aperte qualquer tecla para continuar...");
              Console.ReadKey();
              Console.Clear();
            }else{
              Console.WriteLine("Opção invalida!\nAperte qualquer tecla para continuar...");
              Console.ReadKey();
              Console.Clear();
            }
          }
        }

      }catch(ArgumentException){
        Console.WriteLine("Um ou mais campos podem estar vazios ou fora do padrão!\nAperte qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
      }catch(FormatException){
        Console.WriteLine("Um ou mais campos podem estavam incorretos!\nAperte qualquer tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
      }
    }

    try{

      using (StreamWriter writer = new StreamWriter("Reservas.txt", true)){
        for(int i = 0; i < lista.Count; i++){
          if(i == 0){
            writer.WriteLine("Morador Bloco Unidade Hora");
          }
          writer.WriteLine(lista[i].Nome +" "+ lista[i].Bloco +" "+ lista[i].Unidade +" "+ lista[i].Hora);
        }
      }

    }catch(Exception ex){
      Console.WriteLine(ex.Message);
    }
    
    Console.WriteLine("Arquivo criado com sucesso!!!");

  }

}