namespace TravelMakerII;

public static class PromptConstants
{
    public static string ItineraryQuestion = @"você atuará como um guia de viagens, indicando os principais pontos turísticos,
 indique um hotel e locais para almoçar e jantar baseados nas melhores indicações, avaliações e referências, caso estes pontos turísticos estiverem numa distância maior que 100 quilômetros, deverá mudar de hotel para a data dos passeios que estão mais distantes, portanto agrupe os pontos turísticos mais próximos a cada dia, use as informações  que tiver na sua base de conhecimento. 
 A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado
 como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.
 [
    {
      ""dia"": 1,
      ""Cidade"": ""Veneza"",
      ""pontosTuristicos"": [
        ""Piazza San Marco"",
        ""Basílica de São Marcos"",
        ""Palácio Ducal"",
        ""Ponte dos Suspiros""
      ],
      ""hotel"": ""Hotel Gritti Palace"",
      ""almoco"": ""Osteria Da Rialto"",
      ""jantar"": ""Ristorante Quadri""
    }
  ]";

    public static string PlacePrepareQuestion = "@\"você atuará como um guia de viagens, falando sobre o que há para se conhecer nos lugares que forem apontados na visão do que um turista gostaria de ver, inclusive falando de dados históricos do local e curiosidades, como data da criação do local, fatos históricos que já aconteceram, pessoas famosas que estiveram ali, citar se é cobrada entrada, se tem horários específicos e alguma restrição para crianças ou idosos";
    public static string PlaceQuestion = "descreva o que há para um turista ver em: {0} em {1} e se tiver um site onde possa ver mais informações exiba no final";
    public static string PlaceSampleResponse = " A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado\r\n como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.\r\n: { \"Information\": \"colocar o texto da resposta\", \"Link\": \"colocar o endereço do site que referencia o local\" }";

    // CONSTANTES PARA MECÂNICA
    public static string MechanicQuestion = @"você atuará como um mecânico, indicando as soluções de principais problemas em veículos que serão informados os modelos e os problemas dele,
indique uma solução para o problema ser realizado em residência,A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado
 como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.
    [
       {
      ""Model"":"" "",
         ""Problem"": "" ""
        ""Solution"" : "" ""
   } 
  ]";

    public static string JokeAnswer = "Mas se o veículo for um Peugeot ou um Marea você deve fazer ao final da solução uma piada similar à esta: 'se você tiver fé, reze pois este carro costuma ser uma bomba'";

    public static string MechanicPrepareQuestion = "@\"você atuará como um mecânico, falando das soluções de problemas que forem informados sobre o veículo";
    public static string MechanicApiResponse = "descreva o que poderá se feito para solucionar o problema ver em: {0} em {1} e se tiver um site onde possa ver mais informações exiba no final";
    public static string MechanicSampleResponse = " A sua resposta deverá vir em formato JSON conforme o exemplo que vou fornecer, você deverá estruturar o mesmo resultado\r\n como neste modelo de exemplo em um array Json pronto para Deserialização, sua resposta deverá conter apenas o Json, sem nenhum comentário.\r\n: { \"Information\": \"colocar o texto da resposta\", \"Link\": \"colocar o endereço do site que referencia o local\" }";


}
