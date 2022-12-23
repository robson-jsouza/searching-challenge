using SearchingChallenge.Interfaces;

namespace SearchingChallenge
{
    public class Buraco : IBuraco
    {
        public int ObterQuantidadeBuracos(int[,] matriz, int linhas, int colunas)
        {
            int buracos = 0;

            // horizontal
            buracos += ObterBuracosNaHorizontal(matriz, linhas, colunas);

            // vertical
            buracos += ObterBuracosNaVertical(matriz, linhas, colunas);

            return buracos;
        }

        public int ObterBuracosNaHorizontal(int[,] matriz, int linhas, int colunas)
        {
            // percorrer cada posição e ver as próximas pra frente e pra trás até encontrar um número '1'
            // incrementar quantidade de buracos e marcar posições visitadas
            int sequenciaZeros = 0;
            int buracos = 0;
            List<Posicao> visitados = new List<Posicao>();
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    var posicaoInicial = new Posicao { I = i, J = j };
                    if (visitados.Contains(posicaoInicial))
                        continue;

                    var valor = matriz[i, j];

                    if (valor == 1)
                    {
                        if (sequenciaZeros > 1)
                            buracos++;

                        sequenciaZeros = 0;
                        visitados.Add(new Posicao { I = i, J = j });
                        continue;
                    }
                    else if (valor == 0)
                    {
                        sequenciaZeros++;
                        sequenciaZeros += BuscaVizinhosHorizontal(matriz, posicaoInicial, linhas, colunas, visitados, DirecaoEnum.ParaFrente);
                        sequenciaZeros += BuscaVizinhosHorizontal(matriz, posicaoInicial, linhas, colunas, visitados, DirecaoEnum.ParaTras);
                    }
                }
            }

            return buracos;
        }

        public int ObterBuracosNaVertical(int[,] matriz, int linhas, int colunas)
        {
            // percorrer cada posição e ver as próximas pra frente e pra trás até encontrar um número '1'
            // incrementar quantidade de buracos e marcar posições visitadas
            int sequenciaZeros = 0;
            int buracos = 0;
            for (int i = 0; i < colunas; i++)
            {
                for (int j = 0; j < linhas; j++)
                {
                    if (matriz[j, i] == 1)
                    {
                        if (sequenciaZeros > 1)
                            buracos++;

                        sequenciaZeros = 0;
                        continue;
                    }

                    sequenciaZeros++;
                }
            }

            return buracos;
        }

        public int BuscaVizinhosHorizontal(int[,] matriz, Posicao posicaoAtual, int linhas, int colunas, List<Posicao> visitados, DirecaoEnum direcao)
        {
            int sequenciaZeros = 0;

            if (direcao == DirecaoEnum.ParaFrente)
            {
                // TODO: isso deveria ir para uma função
                int i = posicaoAtual.I;
                int j = posicaoAtual.J;
                j = j + 1 > colunas - 1 ? 0 : j + 1;
                i = j == 0 ? (i + 1 > linhas - 1 ? 0 : i + 1) : i;
                posicaoAtual = new Posicao { I = i, J = j };
                sequenciaZeros += BuscaVizinhosHorizontalParaFrente(matriz, posicaoAtual, linhas, colunas, visitados);
            }
            else if (direcao == DirecaoEnum.ParaTras)
            {
                // TODO: isso deveria ir para uma função
                int i = posicaoAtual.I;
                int j = posicaoAtual.J;
                j = j - 1 < 0 ? colunas - 1 : j - 1;
                i = j == colunas - 1 ? (i - 1 < 0 ? linhas - 1 : i - 1) : i;
                posicaoAtual = new Posicao { I = i, J = j };
                sequenciaZeros += BuscaVizinhosHorizontalParaTras(matriz, posicaoAtual, linhas, colunas, visitados);
            }

            return sequenciaZeros;
        }

        public int BuscaVizinhosHorizontalParaFrente(int[,] matriz, Posicao posicaoAtual, int linhas, int colunas, List<Posicao> visitados)
        {
            int sequenciaZeros = 0;
            int i = posicaoAtual.I;
            int j = posicaoAtual.J;
            var posicaoInicial = new Posicao { I = i, J = j };

            do
            {
                for (int indice = j; indice < colunas; indice++)
                {
                    var valor = matriz[i, indice];
                    CalculaSequenciaDeZeros(valor, ref sequenciaZeros, visitados, posicaoInicial);

                    if (valor == 1)
                        return sequenciaZeros;

                    j = j + 1 > colunas - 1 ? 0 : j + 1;
                    i = j == 0 ? (i + 1 > linhas - 1 ? 0 : i + 1) : i;
                    posicaoInicial = new Posicao { I = i, J = j };
                }

                //posicaoInicial.J = posicaoInicial.J + 1 > colunas - 1 ? 0 : posicaoInicial.J + 1;
                //posicaoInicial.I = posicaoInicial.J == 0 ? (posicaoInicial.I + 1 > linhas - 1 ? 0 : posicaoInicial.I + 1) : posicaoInicial.I;
                //i = i + 1 == linhas ? 0 : i + 1;
                //j = 0;
                //posicaoInicial = new Posicao { I = i, J = j };
            } while (!visitados.Any(v => v.I == posicaoInicial.I && v.J == posicaoInicial.J));

            return sequenciaZeros;
        }

        public int BuscaVizinhosHorizontalParaTras(int[,] matriz, Posicao posicaoAtual, int linhas, int colunas, List<Posicao> visitados)
        {
            int sequenciaZeros = 0;
            int i = posicaoAtual.I;
            int j = posicaoAtual.J;
            var posicaoInicial = new Posicao { I = i, J = j };

            do
            {
                for (int indice = j; indice >= 0; indice--)
                {
                    var valor = matriz[i, indice];
                    CalculaSequenciaDeZeros(valor, ref sequenciaZeros, visitados, posicaoInicial);

                    if (valor == 1)
                        return sequenciaZeros;

                    j = j - 1 < 0 ? colunas - 1 : j - 1;
                    i = j == colunas - 1 ? (i - 1 < 0 ? linhas - 1 : i - 1) : i;
                    posicaoInicial = new Posicao { I = i, J = j };
                }

                //posicaoInicial.J = posicaoInicial.J - 1 < 0 ? colunas - 1 : posicaoInicial.J - 1;
                //posicaoInicial.I = posicaoInicial.J == colunas - 1 ? (posicaoInicial.I - 1 < 0 ? linhas - 1 : posicaoInicial.I - 1) : posicaoInicial.I;
                //i = i - 1 == -1 ? linhas - 1 : i - 1;
                //j = colunas - 1;
                //posicaoInicial = new Posicao { I = i, J = j };
            } while (!visitados.Any(v => v.I == posicaoInicial.I && v.J == posicaoInicial.J));

            return sequenciaZeros;
        }

        private void CalculaSequenciaDeZeros(int valor, ref int sequenciaZeros, List<Posicao> visitados, Posicao posicao)
        {
            if (valor == 0)
                sequenciaZeros++;

            visitados.Add(posicao);
        }
    }
}
