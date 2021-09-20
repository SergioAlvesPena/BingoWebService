using BingoWS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BingoWS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BingoController : ControllerBase
    {
        public static List<int> ChosenNumbers = new List<int>();
        Random random = new Random();

        public BingoController()
        {
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
            cartela.Id = random.Next(1, 100);

            return JsonSerializer.Serialize(cartela);
        }

        [HttpGet("GetNumber")]
        public ActionResult<int> GetRandomNumber() 
        {
            int number = random.Next(1, 100);
            while (ChosenNumbers.Contains(number)) 
            {
                number = random.Next(1, 100);
            }
            return number;
        }
    }
}
