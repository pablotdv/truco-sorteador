using Microsoft.EntityFrameworkCore;

namespace TrucoData
{
    public class TrucoService
    {
        private readonly TrucoContext _context;

        public TrucoService(TrucoContext context)
        {
            _context = context;
        }

        public void OrdenarTrios()
        {
            // Recuperar a lista de trios do banco de dados
            var trios = _context.Trios.Where(a => a.Sortear).ToList();

            // Embaralhar a lista de trios usando Fisher-Yates shuffle
            Random rng = new Random();
            int n = trios.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = trios[k];
                trios[k] = trios[n];
                trios[n] = value;
            }

            // Atualizar a ordem dos trios embaralhados
            int ordem = 0;
            foreach (var trio in trios)
            {
                trio.Ordem = ordem++;
            }

            // Salvar as alterações no banco de dados
            _context.SaveChanges();
        }

        public void GerarJogos(int etapa, int rodadas)
        {
            // Fetch all existing trios
            var trios = _context.Trios.Where(a => a.Sortear).OrderBy(a => a.Ordem).ToList();
            int numTrios = trios.Count;

            if (numTrios < 2)
            {
                throw new Exception("Não há trios suficientes para gerar os jogos.");
            }

            int numero = 0;
            // Generate the games            
            for (int round = 0; round < rodadas; round++)
            {
                numTrios = trios.Count;
                if (trios.Count % 2 != 0)
                {
                    trios.Add(new Trio { Nome = "Folga", Ordem = int.MaxValue });
                    trios = trios.OrderBy(a => a.Ordem).ToList();
                    numTrios++;
                }
                for (int i = 0; i < numTrios / 2; i++)
                {
                    var trioA = trios[i];
                    var trioB = trios[numTrios - i - 1];
                    numero++;

                    _context.Jogos.Add(new Jogo
                    {
                        JogoId = Guid.NewGuid(),
                        Numero = numero,
                        Etapa = etapa,
                        Data = DateTime.Now.AddDays(round),
                        Rodada = round + 1,
                        TrioAId = trioA.TrioId,
                        TrioBId = trioB.Nome.Equals("Folga") ? null : trioB.TrioId,
                    });
                    _context.SaveChanges();
                    // checar se jogo é duplicado
                    //if (trioA.Nome != "Folga" && trioB.Nome != "Folga")
                    //{
                    //    var jogoDuplicado = _context.Jogos
                    //        .Where(j => (j.TrioAId == trioA.TrioId && j.TrioBId == trioB.TrioId) || (j.TrioAId == trioB.TrioId && j.TrioBId == trioA.TrioId))
                    //        .ToList();
                    //    if (jogoDuplicado.Count > 1)
                    //    {
                    //        // excluir todos os jogos da etapa
                    //        _context.Jogos.RemoveRange(_context.Jogos.Where(j => j.Etapa == etapa));
                    //        _context.SaveChanges();
                    //        ReordenarTrios();
                    //        GerarJogos(etapa, rodadas);
                    //    }
                    //}
                }

                trios = this.ReordenarTrios();
            }
        }

        private List<Trio> ReordenarTrios()
        {
            var triosOrdenados = _context.Trios.Where(a => a.Sortear).OrderBy(t => t.Ordem).ToList();

            int primeiraOrdem = triosOrdenados.First().Ordem;

            for (int i = 0; i < triosOrdenados.Count - 1; i++)
            {
                triosOrdenados[i].Ordem = triosOrdenados[i + 1].Ordem;
            }

            triosOrdenados.Last().Ordem = primeiraOrdem;

            _context.SaveChanges();

            return _context.Trios.Where(a => a.Sortear).OrderBy(a => a.Ordem).ToList();
        }
    }
}
