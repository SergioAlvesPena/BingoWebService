using BingoWS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using BingoWS.Data;
using BingoWS.Repositories;

namespace BingoWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BingoController : ControllerBase
    {
        public static List<int> ChosenNumbers = new List<int>();
        private readonly CartelaRepository _repository;
        Random random = new Random();

        public BingoController(CartelaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Card")]
        public ActionResult<string> CreateGame()
        {
            Cartela cartela = new Cartela();
            cartela.CartelaDeNumeros = new List<List<int>>();
            int number;
            for (int i = 0; i < 5; i++)
            {
                List<int> linha = new List<int>();
                for (int j = 0; j < 5; j++)
                {
                    number = random.Next(1, 100);
                    if (!linha.Contains(number))
                    {
                        linha.Add(number);
                    }
                    else 
                    {
                        i--;
                        break;
                    }
                }
                cartela.CartelaDeNumeros.Add(linha);
            }
            cartela.Id = Guid.NewGuid();

            _repository.Create(cartela);


            return JsonSerializer.Serialize(cartela);
        }

        [HttpGet("Rodada")]
        public ActionResult<Guid> Rodada() 
        {
            int numero = random.Next(1, 100);
            while (ChosenNumbers.Contains(numero)) 
            {
                numero = random.Next(1, 100);
            }

            var cartelas = _repository.GetAll().Result;

            foreach (Cartela cartela in cartelas) 
            {
                foreach (List<int> linha in cartela.CartelaDeNumeros) 
                {
                    if (linha.Contains(numero)) 
                    {
                        int indice = linha.IndexOf(numero);
                        linha[indice] = 0;
                        _repository.Update(cartela);
                    }

                }
            }

            var vencedor = _repository.GetAll().Result;

            foreach (Cartela jogador in vencedor) 
            {
                foreach (List<int> linha in jogador.CartelaDeNumeros) 
                {
                    if (!linha.Any(o => o != linha[0])) 
                    {
                        return jogador.Id;
                    }
                }
            }

            return Guid.Empty;
        }
    }
}
