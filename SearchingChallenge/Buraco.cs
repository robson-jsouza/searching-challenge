namespace SearchingChallenge
{
    public class Buraco
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
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    if (matriz[i, j] == 1)
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
    }
}
