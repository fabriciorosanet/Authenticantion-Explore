using Authentication_Explore.Entities;

namespace Authentication_Explore.Interfaces;

public interface IAlunoService
{
    Aluno RetornarAluno(int id);
    int CriarAluno(Aluno dadosAluno);
    List<Aluno> RetorarAlunos();
}