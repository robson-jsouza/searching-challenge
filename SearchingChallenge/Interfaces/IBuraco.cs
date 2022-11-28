namespace SearchingChallenge.Interfaces
{
    public interface IBuraco
    {
        int ObterQuantidadeBuracos(int[,] matriz, int linhas, int colunas);

        int ObterBuracosNaHorizontal(int[,] matriz, int linhas, int colunas);

        int ObterBuracosNaVertical(int[,] matriz, int linhas, int colunas);
    }
}