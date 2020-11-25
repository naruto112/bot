﻿using System;
using System.Net;
using Newtonsoft.Json;

namespace Bot.MegaSena.Json
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informa o número do concurso:");
            string numeroDoConcurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(numeroDoConcurso))
            {
                numeroDoConcurso = "2103";
            }

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage//p=concurso="+ numeroDoConcurso +"?timestampAjax=1606181790133";
            string json;

            using (WebClient wc = new WebClient())
            {
                wc.Headers["Cookie"] = "security=true";
                json = wc.DownloadString(url);
            }

            Resultado resultadoDaMegaSena = JsonConvert.DeserializeObject<Resultado>(json);

            Console.WriteLine(resultadoDaMegaSena.localSorteio);

            Console.ReadKey();
        }
    }
}
