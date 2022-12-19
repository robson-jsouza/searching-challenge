using SearchingChallenge;

namespace SearchChallengeTests
{
    [TestClass]
    public class BuracoTests
    {
        [TestMethod]
        public void EncontraDoisBuracosVerticalHorizontalTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];

            // 0   1   1   1   1
            // 0   1   1   0   1
            // 0   0   0   1   1
            // 1   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 0;
            matriz[1, 4] = 1;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 0;
            matriz[2, 3] = 1;
            matriz[2, 4] = 1;

            matriz[3, 0] = 1;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeBuracos = buraco.ObterQuantidadeBuracos(matriz, linhas, colunas);

            Assert.AreEqual(2, quantidadeBuracos);
        }

        [TestMethod]
        public void EncontraUmBuracoHorizontalTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];

            // 0   1   1   1   1
            // 0   1   1   0   1
            // 0   0   0   1   1
            // 1   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 0;
            matriz[1, 4] = 1;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 0;
            matriz[2, 3] = 1;
            matriz[2, 4] = 1;

            matriz[3, 0] = 1;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeBuracos = buraco.ObterBuracosNaHorizontal(matriz, linhas, colunas);

            Assert.AreEqual(2, quantidadeBuracos);
        }

        [TestMethod]
        public void EncontraUmBuracoVerticalTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];

            // 0   1   1   1   1
            // 0   1   1   0   1
            // 0   0   0   1   1
            // 1   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 0;
            matriz[1, 4] = 1;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 0;
            matriz[2, 3] = 1;
            matriz[2, 4] = 1;

            matriz[3, 0] = 1;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeBuracos = buraco.ObterBuracosNaVertical(matriz, linhas, colunas);

            Assert.AreEqual(1, quantidadeBuracos);
        }

        [TestMethod]
        public void EncontraSequenciaZerosHorizontalParaFrenteTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];
            int i = 2;
            int j = 0;
            var posicaoAtual = new Posicao { I = i, J = j };
            List<Posicao> visitados = new List<Posicao>()
            {
                // linha 1
                new Posicao { I = 0, J = 0, },
                new Posicao { I = 0, J = 1, },
                new Posicao { I = 0, J = 2, },
                new Posicao { I = 0, J = 3, },
                new Posicao { I = 0, J = 4, },
                // linha 2
                new Posicao { I = 1, J = 0, },
                new Posicao { I = 1, J = 1, },
                new Posicao { I = 1, J = 2, },
                new Posicao { I = 1, J = 3, },
                new Posicao { I = 1, J = 4, },
            };

            // 0   1   1   1   1
            // 0   1   1   1   0
            // 0   0   1   1   1
            // 1   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 1;
            matriz[1, 4] = 0;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 1;
            matriz[2, 3] = 1;
            matriz[2, 4] = 1;

            matriz[3, 0] = 1;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeZeros = buraco.BuscaVizinhosHorizontal(matriz, posicaoAtual, linhas, colunas, visitados, DirecaoEnum.ParaFrente);

            Assert.AreEqual(2, quantidadeZeros);
        }

        [TestMethod]
        public void EncontraSequenciaZerosHorizontalParaFrenteFinalizandoNaPrimeiraPosicaoJaVisitadaDaMatrizTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];
            int i = 2;
            int j = 0;
            var posicaoAtual = new Posicao { I = i, J = j };
            // a primeira posição (0, 0) não está como visitada para testar o algoritmo tendo que ir verificar a próxima linha no caso de ser
            // a última e ter como próxima a primeira linha da matriz
            List<Posicao> visitados = new List<Posicao>
            {
                // linha 1
                new Posicao { I = 0, J = 0, },
                new Posicao { I = 0, J = 1, },
                new Posicao { I = 0, J = 2, },
                new Posicao { I = 0, J = 3, },
                new Posicao { I = 0, J = 4, },
                // linha 2
                new Posicao { I = 1, J = 0, },
                new Posicao { I = 1, J = 1, },
                new Posicao { I = 1, J = 2, },
                new Posicao { I = 1, J = 3, },
                new Posicao { I = 1, J = 4, },
            };

            // 0   1   1   1   1
            // 0   1   1   1   0
            // 0   0   0   0   0
            // 0   0   0   0   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 1;
            matriz[1, 4] = 0;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 0;
            matriz[2, 3] = 0;
            matriz[2, 4] = 0;

            matriz[3, 0] = 0;
            matriz[3, 1] = 0;
            matriz[3, 2] = 0;
            matriz[3, 3] = 0;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeZeros = buraco.BuscaVizinhosHorizontal(matriz, posicaoAtual, linhas, colunas, visitados, DirecaoEnum.ParaFrente);

            Assert.AreEqual(10, quantidadeZeros);
        }

        [TestMethod]
        public void EncontraSequenciaZerosHorizontalParaFrenteFinalizandoNaPrimeiraPosicaoAindaNaoVisitadaDaMatrizTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];
            int i = 2;
            int j = 0;
            var posicaoAtual = new Posicao { I = i, J = j };
            List<Posicao> visitados = new List<Posicao>
            {
                // linha 1
                new Posicao { I = 0, J = 1, },
                new Posicao { I = 0, J = 2, },
                new Posicao { I = 0, J = 3, },
                new Posicao { I = 0, J = 4, },
                // linha 2
                new Posicao { I = 1, J = 0, },
                new Posicao { I = 1, J = 1, },
                new Posicao { I = 1, J = 2, },
                new Posicao { I = 1, J = 3, },
                new Posicao { I = 1, J = 4, },
            };

            // 0   1   1   1   1
            // 0   1   1   1   0
            // 0   0   0   0   0
            // 0   0   0   0   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 1;
            matriz[0, 2] = 1;
            matriz[0, 3] = 1;
            matriz[0, 4] = 1;

            matriz[1, 0] = 0;
            matriz[1, 1] = 1;
            matriz[1, 2] = 1;
            matriz[1, 3] = 1;
            matriz[1, 4] = 0;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 0;
            matriz[2, 3] = 0;
            matriz[2, 4] = 0;

            matriz[3, 0] = 0;
            matriz[3, 1] = 0;
            matriz[3, 2] = 0;
            matriz[3, 3] = 0;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeZeros = buraco.BuscaVizinhosHorizontal(matriz, posicaoAtual, linhas, colunas, visitados, DirecaoEnum.ParaFrente);

            Assert.AreEqual(11, quantidadeZeros);
        }

        [TestMethod]
        public void EncontraSequenciaZerosHorizontalParaTrasFinalizandoNaUltimaPosicaoJaVisitadaDaMatrizTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];
            int i = 2;
            int j = 0;
            var posicaoAtual = new Posicao { I = i, J = j };
            List<Posicao> visitados = new List<Posicao>
            {
                // linha 1
                new Posicao { I = 2, J = 1, },
                new Posicao { I = 2, J = 2, },
                new Posicao { I = 2, J = 3, },
                new Posicao { I = 2, J = 4, },
                // linha 2
                new Posicao { I = 3, J = 0, },
                new Posicao { I = 3, J = 1, },
                new Posicao { I = 3, J = 2, },
                new Posicao { I = 3, J = 3, },
                new Posicao { I = 3, J = 4, },
            };

            // 0   0   0   0   0
            // 0   0   0   0   0
            // 0   0   1   0   0
            // 0   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 0;
            matriz[0, 2] = 0;
            matriz[0, 3] = 0;
            matriz[0, 4] = 0;

            matriz[1, 0] = 0;
            matriz[1, 1] = 0;
            matriz[1, 2] = 0;
            matriz[1, 3] = 0;
            matriz[1, 4] = 0;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 1;
            matriz[2, 3] = 0;
            matriz[2, 4] = 0;

            matriz[3, 0] = 0;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeZeros = buraco.BuscaVizinhosHorizontal(matriz, posicaoAtual, linhas, colunas, visitados, DirecaoEnum.ParaTras);

            Assert.AreEqual(11, quantidadeZeros);
        }

        [TestMethod]
        public void EncontraSequenciaZerosHorizontalParaTrasFinalizandoNaUltimaPosicaoAindaNaoVisitadaDaMatrizTest()
        {
            int linhas = 4;
            int colunas = 5;
            int[,] matriz = new int[4, 5];
            int i = 2;
            int j = 0;
            var posicaoAtual = new Posicao { I = i, J = j };
            // a última posição (0, 0) não está como visitada para testar o algoritmo tendo que ir verificar a próxima linha no caso de ser
            // a primeira e ter como próxima a última linha da matriz
            List<Posicao> visitados = new List<Posicao>
            {
                // linha 1
                new Posicao { I = 2, J = 1, },
                new Posicao { I = 2, J = 2, },
                new Posicao { I = 2, J = 3, },
                new Posicao { I = 2, J = 4, },
                // linha 2
                new Posicao { I = 3, J = 0, },
                new Posicao { I = 3, J = 1, },
                new Posicao { I = 3, J = 2, },
                new Posicao { I = 3, J = 3, },
            };

            // 0   0   0   0   0
            // 0   0   0   0   0
            // 0   0   1   0   0
            // 0   1   1   1   0

            matriz[0, 0] = 0;
            matriz[0, 1] = 0;
            matriz[0, 2] = 0;
            matriz[0, 3] = 0;
            matriz[0, 4] = 0;

            matriz[1, 0] = 0;
            matriz[1, 1] = 0;
            matriz[1, 2] = 0;
            matriz[1, 3] = 0;
            matriz[1, 4] = 0;

            matriz[2, 0] = 0;
            matriz[2, 1] = 0;
            matriz[2, 2] = 1;
            matriz[2, 3] = 0;
            matriz[2, 4] = 0;

            matriz[3, 0] = 0;
            matriz[3, 1] = 1;
            matriz[3, 2] = 1;
            matriz[3, 3] = 1;
            matriz[3, 4] = 0;

            var buraco = new Buraco();
            var quantidadeZeros = buraco.BuscaVizinhosHorizontal(matriz, posicaoAtual, linhas, colunas, visitados, DirecaoEnum.ParaTras);

            Assert.AreEqual(12, quantidadeZeros);
        }

        // TODO: fazer pra frente e pra tras na vertical
    }
}