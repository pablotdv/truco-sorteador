using Microsoft.EntityFrameworkCore;
using System.Linq;
using TrucoData;

namespace TrucoTestes
{
    public class TrucoServiceTests
    {
        private readonly TrucoService _service;
        private readonly TrucoContext _context;

        public TrucoServiceTests()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string databasePath = System.IO.Path.Combine(appDataPath, "TrucoApp", "truco.db");

            // Ensure the directory exists
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(databasePath));

            // Set up DbContext with the path to the database file in AppData
            DbContextOptions<TrucoContext> options = new DbContextOptionsBuilder<TrucoContext>()
                .UseSqlite($"Data Source={databasePath}")
                .Options;

            _context = new TrucoContext(options);
            _service = new TrucoService(_context);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        [Fact]
        public async Task Test1()
        {
            // Arrange
            await _context.Database.EnsureCreatedAsync();
            await _context.Database.EnsureDeletedAsync();
            await _context.Trios.AddAsync(new Trio { TrioId = Guid.NewGuid(), Nome = "Trio 1", Entidade = "Entidade 1" });
            await _context.Trios.AddAsync(new Trio { TrioId = Guid.NewGuid(), Nome = "Trio 2", Entidade = "Entidade 2" });
            await _context.Trios.AddAsync(new Trio { TrioId = Guid.NewGuid(), Nome = "Trio 3", Entidade = "Entidade 3" });
            await _context.Trios.AddAsync(new Trio { TrioId = Guid.NewGuid(), Nome = "Trio 4", Entidade = "Entidade 4" });
            await _context.SaveChangesAsync();

            // Act
            _service.GerarJogos(1, 3);

            // Assert 
            var jogos = await _context.Jogos.ToListAsync();
            Assert.Equal(6, jogos.Count);

            var rodadas = jogos.GroupBy(j => j.Rodada);
            Assert.Equal(3, rodadas.Count());

            var jogosPorRodada = rodadas.Select(r => r.Count());
            Assert.All(jogosPorRodada, j => Assert.Equal(2, j));

            var jogosRepetidosLado = jogos.GroupBy(j => new { j.TrioAId, j.TrioB }).Where(g => g.Count() > 1);
            Assert.Empty(jogosRepetidosLado);
        }

        //[Theory]
        //[MemberData(nameof(TriosData))]
        [Fact]
        public async Task Test2()
        {
            // Arrange
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
            int trios = 19;

            for (int i = 1; i <= trios; i++)
            {
                _context.Trios.Add(new Trio { TrioId = Guid.NewGuid(), Nome = $"Trio {i}", Entidade = $"Entidade {i}", Sortear = i != 19, Ordem = 0 });
            }
            await _context.SaveChangesAsync();
            _service.OrdenarTrios();

            // Act
            _service.GerarJogos(1, 3);

            var trios19 = await _context.Trios.Where(t => t.Nome == "Trio 19").FirstOrDefaultAsync();
            trios19.Sortear = true;
            // maior ordem
            var ordem = await _context.Trios.MaxAsync(t => t.Ordem);
            trios19.Ordem = ordem + 1;
            await _context.SaveChangesAsync();
            _service.GerarJogos(2, 3);

            //var trio10 = await _context.Trios.Where(t => t.Nome == "Trio 10").FirstOrDefaultAsync();
            //trio10.Sortear = false;
            //var trio11 = await _context.Trios.Where(t => t.Nome == "Trio 11").FirstOrDefaultAsync();
            //trio11.Sortear = false;            
            //await _context.SaveChangesAsync();            
            // _service.GerarJogos(3, 3);

            //var trio2 = await _context.Trios.Where(t => t.Nome == "Trio 2").FirstOrDefaultAsync();
            //trio2.Sortear = false;
            //var trio3 = await _context.Trios.Where(t => t.Nome == "Trio 3").FirstOrDefaultAsync();
            //trio3.Sortear = false;
            //var trio9 = await _context.Trios.Where(t => t.Nome == "Trio 9").FirstOrDefaultAsync();
            //trio9.Sortear = false;
            //await _context.SaveChangesAsync();
            //_service.GerarJogos(4, 3);

            // Assert 
            var jogos = await _context.Jogos.ToListAsync();

            var jogosRepetidos = jogos
                .GroupBy(j =>
                {
                    var ids = new List<Guid?> { j.TrioAId, j.TrioBId };
                    ids.Sort(); // Isso ordena os Guids
                    return new { MinId = ids[0], MaxId = ids[1] };
                })
                .Where(g => g.Count() > 1);


            Assert.Empty(jogosRepetidos);


            var resultado = (from t1 in _context.Trios
                             from jogo in _context.Jogos
                             where t1.TrioId == jogo.TrioAId || t1.TrioId == jogo.TrioBId
                             from t2 in _context.Trios
                             where (t1.TrioId == jogo.TrioAId ? jogo.TrioBId : jogo.TrioAId) == t2.TrioId
                             group new { t1, t2 } by new { TrioA = t1.Nome, TrioB = t2.Nome } into g
                             select new
                             {
                                 Trio = g.Key.TrioA,
                                 Adversario = g.Key.TrioB,
                                 NumeroDeJogos = g.Count()
                             }).ToList();

            Assert.All(resultado, resultado => Assert.Equal(1, resultado.NumeroDeJogos));
        }


        public static IEnumerable<object[]> TriosData()
        {
            for (int i = 3; i <= 200; i++)
            {
                yield return new object[] { i };
            }
        }

        [Theory]
        [MemberData(nameof(TriosData))]
        public async Task Test3(int trios)
        {
            // Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            for (int i = 1; i <= trios; i++)
            {
                _context.Trios.Add(new Trio { TrioId = Guid.NewGuid(), Nome = $"Trio {i}", Entidade = $"Entidade {i}" });
            }
            await _context.SaveChangesAsync();

            int rodadas = 3;  // N�mero fixo de rodadas
            int jogosEsperados = (int)Math.Ceiling(trios / 2.0) * rodadas;

            // Act
            _service.GerarJogos(1, 3);

            // Assert 
            var jogosGerados = await _context.Jogos.ToListAsync();
            Assert.Equal(jogosEsperados, jogosGerados.Count);

            var rodadasGeradas = jogosGerados.GroupBy(j => j.Rodada);
            Assert.Equal(3, rodadasGeradas.Count());

            var jogosPorRodada = rodadasGeradas.Select(r => r.Count());
            Assert.All(jogosPorRodada, j => Assert.Equal(Math.Ceiling(trios / 2.0), j));

            var jogosRepetidos = jogosGerados
                .GroupBy(j =>
                {
                    var ids = new List<Guid?> { j.TrioAId, j.TrioBId };
                    ids.Sort(); // Isso ordena os Guids
                    return new { MinId = ids[0], MaxId = ids[1] };
                })
                .Where(g => g.Count() > 1);
            Assert.Empty(jogosRepetidos);
        }

    }
}