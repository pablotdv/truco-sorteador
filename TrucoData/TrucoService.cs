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

        public void SortearTrios()
        {
            var random = new Random();
            var trios = _context.Trios.Where(a => a.Sortear).ToList();

            // Embaralhamento utilizando o algoritmo Fisher-Yates
            int n = trios.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = trios[i];
                trios[i] = trios[j];
                trios[j] = temp;
            }

            // Atribuir a nova ordem aos trios
            for (int i = 0; i < trios.Count; i++)
            {
                trios[i].Ordem = i;
            }

            _context.SaveChanges();
        }


        public void GerarJogos(int etapa, int rodadas)
        {
            // Fetch all existing trios
            var trios = _context.Trios
                .Where(a => a.Sortear)
                .OrderBy(a => a.Ordem)
                .ToList();
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
                        Rodada = round + 1,
                        TrioAId = trioA.TrioId,
                        TrioBId = trioB.Nome.Equals("Folga") ? null : trioB.TrioId,
                    });
                }
                trios = this.ReordenarTrios();
            }
            _context.SaveChanges();
        }

        private List<Trio> ReordenarTrios()
        {
            var triosOrdenados = _context.Trios
                .Where(a => a.Sortear)
                .OrderBy(t => t.Ordem)
                .ToList();

            // Guarda o primeiro trio para mover para o final depois
            var primeiroTrio = triosOrdenados.First();

            // Remove o primeiro trio e adiciona no final
            triosOrdenados.Remove(primeiroTrio);
            triosOrdenados.Add(primeiroTrio);

            // Reatribui as ordens
            for (int i = 0; i < triosOrdenados.Count; i++)
            {
                triosOrdenados[i].Ordem = i;
            }

            _context.SaveChanges();

            return _context.Trios.Where(a => a.Sortear).OrderBy(a => a.Ordem).ToList();
        }

    }
}
