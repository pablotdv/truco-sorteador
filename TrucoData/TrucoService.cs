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
            var trios = (_context.Trios.ToList()).OrderBy(a => Guid.NewGuid());

            int ordem = 0;
            foreach (var trio in trios)
            {
                trio.Ordem = ordem++;
            }
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
                    trios.Add(new Trio { Nome = "Folga" });
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
                }

                trios = this.ReordenarTrios();
            }
        }

        private List<Trio> ReordenarTrios()
        {
            var triosOrdenados = _context.Trios.OrderBy(t => t.Ordem).ToList();

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
